using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Content.Feats
{
    static class PolearmDancer
    {
        static readonly BlueprintWeaponType bardiche = Resources.GetBlueprint<BlueprintWeaponType>("b1cbf457fd471d148b39ae56667f405a");
        static readonly BlueprintWeaponType fauchard = Resources.GetBlueprint<BlueprintWeaponType>("7a40899c4defec94bb9c291bde74f1a8");
        static readonly BlueprintWeaponType glaive = Resources.GetBlueprint<BlueprintWeaponType>("7a14a1b224cd173449cb7ffc77d5f65c");
        static readonly BlueprintWeaponType javelin = Resources.GetBlueprint<BlueprintWeaponType>("a70cea34b275522458654beb3c53fe3f");
        static readonly BlueprintWeaponType longspear = Resources.GetBlueprint<BlueprintWeaponType>("fa2dd17cbde7d3f4aa918d467c30516e");
        static readonly BlueprintWeaponType shortspear = Resources.GetBlueprint<BlueprintWeaponType>("cf72040b79c99504785976b28d54b2b7");
        static readonly BlueprintWeaponType spear = Resources.GetBlueprint<BlueprintWeaponType>("4b289eccefe6d704093201e52eb6d123");
        static readonly BlueprintWeaponType trident = Resources.GetBlueprint<BlueprintWeaponType>("6ff66364e0a2c89469c2e52ebb46365e");

        public static void AddPolearmDancer()
        {
            var polearmdancer = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "PolearmDancer";
                bp.SetName("Polearm Dancer");
                bp.AssetGuid = new BlueprintGuid(new System.Guid("2bbeb475923e49f08c2f8e37b08dbf8e"));
                bp.SetDescription("You may use your Dexterity modifier instead of your Strength modifier on attack "
                    + "and damage rolls with spears and polearms.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
                bp.AddComponent(Helpers.Create<AttackStatReplacement>(c =>
                {
                    c.ReplacementStat = StatType.Dexterity;
                    c.m_WeaponTypes = new BlueprintWeaponTypeReference[]
                    {
                        bardiche.ToReference<BlueprintWeaponTypeReference>(),
                        fauchard.ToReference<BlueprintWeaponTypeReference>(),
                        glaive.ToReference<BlueprintWeaponTypeReference>(),
                        javelin.ToReference<BlueprintWeaponTypeReference>(),
                        longspear.ToReference<BlueprintWeaponTypeReference>(),
                        shortspear.ToReference<BlueprintWeaponTypeReference>(),
                        spear.ToReference<BlueprintWeaponTypeReference>(),
                        trident.ToReference<BlueprintWeaponTypeReference>()
                    };
                    c.CheckWeaponTypes = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Bardiche;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Fauchard;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Glaive;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Javelin;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Longspear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Shortspear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Spear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Trident;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<PrerequisiteStatValue>(c =>
                {
                    c.Stat = StatType.BaseAttackBonus;
                    c.Value = 1;
                }));
                bp.AddComponent(Helpers.Create<PrerequisiteStatValue>(c =>
                {
                    c.Stat = StatType.SkillMobility;
                    c.Value = 1;
                }));
            });

            Resources.AddBlueprint(polearmdancer);
            FeatUtil.AddAsFeat(polearmdancer);
        }
    }
}
