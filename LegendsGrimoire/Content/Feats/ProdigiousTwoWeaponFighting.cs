using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using LegendsGrimoire.Components.Prerequisites;
using LegendsGrimoire.Utilities;
using System.Linq;

namespace LegendsGrimoire.Content.Feats
{
    static class ProdigiousTwoWeaponFighting
    {
        public static void AddProdigiousTwoWeaponFighting()
        {
            var TwoWeaponFighting = Resources.GetBlueprint<BlueprintFeature>("ac8aaf29054f5b74eb18f2af950e752d");
            var TwoWeaponFightingImproved = Resources.GetBlueprint<BlueprintFeature>("9af88f3ed8a017b45a6837eab7437629");
            var TwoWeaponFightingGreater = Resources.GetBlueprint<BlueprintFeature>("c126adbdf6ddd8245bda33694cd774e8");
            var DoubleSlice = Resources.GetBlueprint<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");

            var ProdigiousTwoWeaponFighting = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "ProdigiousTwoWeaponFighting";
                bp.AssetGuid = new BlueprintGuid(new System.Guid("8a82d38b459c47628a48e41680719ff5"));
                bp.SetName("Prodigious Two-Weapon Fighting");
                bp.SetDescription("You may fight with a one-handed weapon in your offhand as if it were a light weapon. In addition, " +
                    "you may use your Strength score instead of your Dexterity score for the purpose of qualifying for Two-Weapon Fighting " +
                    "and any feats with Two-Weapon Fighting as a prerequisite.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
                bp.AddComponent(Helpers.Create<PrerequisiteStatValue>(c => {
                    c.Stat = StatType.Strength;
                    c.Value = 13;
                }));
                bp.AddComponent(Helpers.Create<FeatureTagsComponent>(c => {
                    c.FeatureTags = FeatureTag.Attack | FeatureTag.Melee;
                }));
            });

            Resources.AddBlueprint(ProdigiousTwoWeaponFighting);
            FixTwoWeaponPrerequisites(TwoWeaponFighting, ProdigiousTwoWeaponFighting);
            FixTwoWeaponPrerequisites(TwoWeaponFightingImproved, ProdigiousTwoWeaponFighting);
            FixTwoWeaponPrerequisites(TwoWeaponFightingGreater, ProdigiousTwoWeaponFighting);
            FixTwoWeaponPrerequisites(DoubleSlice, ProdigiousTwoWeaponFighting);
            FeatUtil.AddAsFeat(ProdigiousTwoWeaponFighting);
        }
        private static void FixTwoWeaponPrerequisites(BlueprintFeature feature, BlueprintFeature prodigious)
        {
            var dexPrerequisite = feature.GetComponents<PrerequisiteStatValue>().FirstOrDefault(p => p.Stat == StatType.Dexterity);
            dexPrerequisite.Group = Prerequisite.GroupType.Any;
            var prerequisiteGroup = Helpers.Create<PrerequisiteGroup>(p => {
                p.Group = Prerequisite.GroupType.Any;
                p.Prerequisites.Add(Helpers.Create<PrerequisiteStatValue>(c => {
                    c.Stat = StatType.Strength;
                    c.Value = dexPrerequisite.Value;
                }));
                p.Prerequisites.Add(Helpers.Create<PrerequisiteFeature>(c => {
                    c.m_Feature = prodigious.ToReference<BlueprintFeatureReference>();
                }));
            });
            feature.AddComponent(prerequisiteGroup);
        }

        [HarmonyPatch(typeof(TwoWeaponFightingAttackPenalty), "OnEventAboutToTrigger")]
        static class TwoWeaponFightingAttackPenalty_OnEventAboutToTrigger
        {
            static bool Prefix(TwoWeaponFightingAttackPenalty __instance, RuleCalculateAttackBonusWithoutTarget evt)
            {
                var rule = evt.Reason.Rule;

                if (rule != null && rule is RuleAttackWithWeapon attack && !attack.IsFullAttack) return false;

                var maybeWeapon1 = evt.Initiator.Body.PrimaryHand.MaybeWeapon;
                var maybeWeapon2 = evt.Initiator.Body.SecondaryHand.MaybeWeapon;

                if (evt.Weapon == null
                    || maybeWeapon1 == null
                    || maybeWeapon2 == null
                    || maybeWeapon1.Blueprint.IsNatural
                    || maybeWeapon2.Blueprint.IsNatural
                    || maybeWeapon1 == evt.Initiator.Body.EmptyHandWeapon
                    || maybeWeapon2 == evt.Initiator.Body.EmptyHandWeapon
                    || (maybeWeapon1 != evt.Weapon && maybeWeapon2 != evt.Weapon))
                {
                    return false;
                }

                var rank = __instance.Fact.GetRank();
                var num1 = rank > 1 ? (evt.Initiator.HasFact(__instance.MythicBlueprint) ? 0 : -2) : -4;
                var num2 = rank > 1 ? (evt.Initiator.HasFact(__instance.MythicBlueprint) ? 0 : -2) : -8;
                var bonus = evt.Weapon == maybeWeapon1 ? num1 : num2;
                var partWeaponTraining = __instance.Owner.Get<UnitPartWeaponTraining>();
                var prodigiousTwoWeaponFighting = Resources.GetBlueprint<BlueprintFeature>("8a82d38b459c47628a48e41680719ff5");
                var isLight = ((bool)__instance.Owner.State.Features.EffortlessDualWielding && partWeaponTraining != null
                    && partWeaponTraining.IsSuitableWeapon(maybeWeapon2))
                    || evt.Initiator.HasFact(prodigiousTwoWeaponFighting);
                if (!maybeWeapon2.Blueprint.IsLight && !maybeWeapon1.Blueprint.Double && !maybeWeapon2.IsShield && !isLight)
                    bonus += -2;

                evt.AddModifier(bonus, __instance.Fact, ModifierDescriptor.UntypedStackable);

                return false;
            }
        }
    }
}
