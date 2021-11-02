using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using LegendsGrimoire.Utilities;
using System;
using System.Linq;

namespace LegendsGrimoire.Content.Archetypes
{
    static class Dominator
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new Guid("f0574ff607cd413f87830a81d0d934d2"));

        static BlueprintFeature DominatorPierceImmunityAberration = CreatePierceImmunity("Aberration", MonsterUtil.CreatureTypes.Aberration, new BlueprintGuid(new Guid("06d6f9b76a864d388f837aa4934d7241")));
        static BlueprintFeature DominatorPierceImmunityAnimal = CreatePierceImmunity("Animal", MonsterUtil.CreatureTypes.Animal, new BlueprintGuid(new Guid("54d20ee9aeef49deb79de9344665de42")));
        static BlueprintFeature DominatorPierceImmunityConstruct = CreatePierceImmunity("Construct", MonsterUtil.CreatureTypes.Construct, new BlueprintGuid(new Guid("5927934ada954401932349d076e5409d")));
        static BlueprintFeature DominatorPierceImmunityDragon = CreatePierceImmunity("Dragon", MonsterUtil.CreatureTypes.Dragon, new BlueprintGuid(new Guid("709abf3398be40a49fde74e5ca5b2e23")));
        static BlueprintFeature DominatorPierceImmunityFey = CreatePierceImmunity("Fey", MonsterUtil.CreatureTypes.Fey, new BlueprintGuid(new Guid("04254c8a19bf45e48d5867b92b184e37")));
        static BlueprintFeature DominatorPierceImmunityMagicalBeast = CreatePierceImmunity("MagicalBeast", MonsterUtil.CreatureTypes.MagicalBeast, new BlueprintGuid(new Guid("13aa56ef02ce435eb8e42b6666a40e57")));
        static BlueprintFeature DominatorPierceImmunityMonstrousHumanoid = CreatePierceImmunity("MonstrousHumanoid", MonsterUtil.CreatureTypes.MonstrousHumanoid, new BlueprintGuid(new Guid("3267a81fbc9a4b72b3a2c4d251cf2aaa")));
        static BlueprintFeature DominatorPierceImmunityOutsider = CreatePierceImmunity("Outsider", MonsterUtil.CreatureTypes.Outsider, new BlueprintGuid(new Guid("4d21bf6e08ff43eb93e73d08a69da314")));
        static BlueprintFeature DominatorPierceImmunityPlant = CreatePierceImmunity("Plant", MonsterUtil.CreatureTypes.Plant, new BlueprintGuid(new Guid("e6a1b427053a420d85cca1aba4eaa3f1")));
        static BlueprintFeature DominatorPierceImmunityUndead = CreatePierceImmunity("Undead", MonsterUtil.CreatureTypes.Undead, new BlueprintGuid(new Guid("049e558e5e9641b992948b5cbf85075a")));
        static BlueprintFeature DominatorPierceImmunityVermin = CreatePierceImmunity("Vermin", MonsterUtil.CreatureTypes.Vermin, new BlueprintGuid(new Guid("2d5464d5c7cd44048419379e05b932fd")));
        static BlueprintFeature DominatorPierceImmunityAll = Helpers.Create<BlueprintFeature>(bp =>
        {
            bp.name = "DominatorPierceImmunityAll";
            bp.AssetGuid = new BlueprintGuid(new Guid("908bb521546a47ec9df6905d7241e4b9"));
            bp.SetName($"Pierce Immunity - All");
            bp.SetDescription("You are a master at manipulating minds. Your Enchantment spells can be cast on any creature, ignoring their immunities to mind-affecting, compulsion, "
                + "confusion, daze, fear, sleep, emotion and negative emotion effects.");
            bp.IsClassFeature = true;
            bp.Ranks = 1;
        });

        public static void AddDominator()
        {
            var DominatorFocus = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "DominatorFocus";
                bp.SetName("Dominator Focus");
                bp.AssetGuid = new BlueprintGuid(new Guid("bff0f10d9f824b82912ad98baa325244"));
                bp.SetDescription("A dominator bends other creatures to their will, as such they get a +2 bonus to the DC of spells "
                    + "they cast from the enchantment school.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.Groups = new FeatureGroup[] { };
                bp.AddComponent(Helpers.Create<IncreaseSpellSchoolDC>(c =>
                {
                    c.BonusDC = 2;
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.School = SpellSchool.Enchantment;
                }));
                bp.AddComponent(Helpers.Create<DominatorDomination>());
            });
            Resources.AddBlueprint(DominatorFocus);

            var DominatorBonusSpellKnown1 = CreateBonusSpellKnown(SpellUtil.Spells.Command, 1, new BlueprintGuid(new Guid("903a13b411b44c98864ad9d9821788de")));
            var DominatorBonusSpellKnown2 = CreateBonusSpellKnown(SpellUtil.Spells.HoldPerson, 2, new BlueprintGuid(new Guid("4ab3a32955b244159f097ae9c984fe84")));
            var DominatorBonusSpellKnown3 = CreateBonusSpellKnown(SpellUtil.Spells.OverwhelmingGrief, 3, new BlueprintGuid(new Guid("74b99b6a14fc4e97abe9c37f753b91f2")));
            var DominatorBonusSpellKnown4 = CreateBonusSpellKnown(SpellUtil.Spells.HoldMonster, 4, new BlueprintGuid(new Guid("77113b2626424da589c17cdd2df91a17")));
            var DominatorBonusSpellKnown5 = CreateBonusSpellKnown(SpellUtil.Spells.CommandGreater, 5, new BlueprintGuid(new Guid("fb4e4d928c214d62a89a8d2c91d51e22")));
            var DominatorBonusSpellKnown6 = CreateBonusSpellKnown(SpellUtil.Spells.HoldPersonMass, 6, new BlueprintGuid(new Guid("55980ab2c5274f6597cb08b7dbf91a70")));
            var DominatorBonusSpellKnown7 = CreateBonusSpellKnown(SpellUtil.Spells.Insanity, 7, new BlueprintGuid(new Guid("fd90f40ee0104290abd2a6d57dae243f")));
            var DominatorBonusSpellKnown8 = CreateBonusSpellKnown(SpellUtil.Spells.HoldMonsterMass, 8, new BlueprintGuid(new Guid("6f2e30eb60704c1ab3f47c6d55467106")));
            var DominatorBonusSpellKnown9 = CreateBonusSpellKnown(SpellUtil.Spells.OverwhelmingPresence, 9, new BlueprintGuid(new Guid("077a5e3cc3064ab09cca2cd8e591b7b7")));

            Resources.AddBlueprint(DominatorPierceImmunityAll);
            
            var DominatorArchetype = Helpers.Create<BlueprintArchetype>(bp =>
            {
                bp.name = "DominatorArchetype";
                bp.AssetGuid = AssetGuid;
                bp.LocalizedName = Helpers.CreateString("DominatorArchetype.Name", "Dominator");
                bp.LocalizedDescription = Helpers.CreateString("DominatorArchetype.Description", "");
                bp.RemoveFeatures = new LevelEntry[]
                {
                    new LevelEntry { Level = 1, Features = { FeatUtil.Selections.ArcanistExploitSelection }},
                    new LevelEntry { Level = 7, Features = { FeatUtil.Selections.ArcanistExploitSelection }},
                    new LevelEntry { Level = 13, Features = { FeatUtil.Selections.ArcanistExploitSelection }},
                    new LevelEntry { Level = 19, Features = { FeatUtil.Selections.ArcanistExploitSelection }},
                };
                bp.AddFeatures = new LevelEntry[]
                {
                    new LevelEntry { Level = 1, Features = { DominatorFocus } },
                    new LevelEntry { Level = 2, Features = { DominatorBonusSpellKnown1 } },
                    new LevelEntry { Level = 3, Features = { DominatorPierceImmunityAnimal, DominatorPierceImmunityVermin } },
                    new LevelEntry { Level = 4, Features = { DominatorBonusSpellKnown2 } },
                    new LevelEntry { Level = 5, Features = { DominatorPierceImmunityMagicalBeast, DominatorPierceImmunityMonstrousHumanoid } },
                    new LevelEntry { Level = 6, Features = { DominatorBonusSpellKnown3 } },
                    new LevelEntry { Level = 7, Features = { DominatorPierceImmunityPlant, DominatorPierceImmunityUndead } },
                    new LevelEntry { Level = 8, Features = { DominatorBonusSpellKnown4 } },
                    new LevelEntry { Level = 9, Features = { DominatorPierceImmunityFey } },
                    new LevelEntry { Level = 10, Features = { DominatorBonusSpellKnown5 } },
                    new LevelEntry { Level = 11, Features = { DominatorPierceImmunityOutsider } },
                    new LevelEntry { Level = 12, Features = { DominatorBonusSpellKnown6 } },
                    new LevelEntry { Level = 13, Features = { DominatorPierceImmunityAberration } },
                    new LevelEntry { Level = 14, Features = { DominatorBonusSpellKnown7 } },
                    new LevelEntry { Level = 15, Features = { DominatorPierceImmunityConstruct } },
                    new LevelEntry { Level = 16, Features = { DominatorBonusSpellKnown8 } },
                    new LevelEntry { Level = 17, Features = { DominatorPierceImmunityAll } },
                    new LevelEntry { Level = 18, Features = { DominatorBonusSpellKnown9 } },
                };
            });
            Resources.AddBlueprint(DominatorArchetype);

            ClassUtil.Classes.Arcanist.m_Archetypes = 
                ClassUtil.Classes.Arcanist.m_Archetypes.AppendToArray(DominatorArchetype.ToReference<BlueprintArchetypeReference>());
            ClassUtil.Classes.Arcanist.Progression.UIGroups = ClassUtil.Classes.Arcanist.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    DominatorFocus,
                    DominatorPierceImmunityAnimal,
                    DominatorPierceImmunityVermin,
                    DominatorPierceImmunityMagicalBeast,
                    DominatorPierceImmunityMonstrousHumanoid,
                    DominatorPierceImmunityPlant,
                    DominatorPierceImmunityUndead,
                    DominatorPierceImmunityFey,
                    DominatorPierceImmunityOutsider,
                    DominatorPierceImmunityAberration,
                    DominatorPierceImmunityConstruct,
                    DominatorPierceImmunityAll
                ),
                Helpers.CreateUIGroup(
                    DominatorBonusSpellKnown1,
                    DominatorBonusSpellKnown2,
                    DominatorBonusSpellKnown3,
                    DominatorBonusSpellKnown4,
                    DominatorBonusSpellKnown5,
                    DominatorBonusSpellKnown6,
                    DominatorBonusSpellKnown7,
                    DominatorBonusSpellKnown8,
                    DominatorBonusSpellKnown9
                )
            );
            Logger.LogPatch("Added", DominatorArchetype);
        }

        static BlueprintFeature CreateBonusSpellKnown(BlueprintAbility spell, int level, BlueprintGuid assetGuid)
        {
            var bonusSpellKnown = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = $"DominatorBonusSpellKnown{level}";
                bp.AssetGuid = assetGuid;
                bp.SetName(spell.Name);
                bp.SetDescription("At 2nd level, and every two levels thereafter, the dominator learns an additional spell.\n"
                    + $"{spell.Name}: {spell.Description}");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_Icon = spell.Icon;
                bp.AddComponent<AddKnownSpell>(c =>
                {
                    c.m_CharacterClass = ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>();
                    c.m_Spell = spell.ToReference<BlueprintAbilityReference>();
                    c.SpellLevel = level;
                });
            });
            Resources.AddBlueprint(bonusSpellKnown);
            return bonusSpellKnown;
        }

        static BlueprintFeature CreatePierceImmunity(string creatureType, BlueprintFeature creatureTypeFeature, BlueprintGuid assetGuid)
        {
            var pierceImmunity = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = $"DominatorPierceImmunity{creatureType}";
                bp.AssetGuid = assetGuid;
                bp.SetName($"Pierce Immunity - {creatureTypeFeature.Name}");
                bp.SetDescription("Your Enchantment spells can be cast on creatures regardless of type and pierce the immunity of creatures with the ");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
            });
            Resources.AddBlueprint(pierceImmunity);
            return pierceImmunity;
        }

        public static bool IsImmunityPierced(UnitEntityData caster, UnitEntityData target)
        {
            return (caster.HasFact(DominatorPierceImmunityAberration) && target.HasFact(MonsterUtil.CreatureTypes.Aberration))
                    || (caster.HasFact(DominatorPierceImmunityAnimal) && target.HasFact(MonsterUtil.CreatureTypes.Animal))
                    || (caster.HasFact(DominatorPierceImmunityConstruct) && target.HasFact(MonsterUtil.CreatureTypes.Construct))
                    || (caster.HasFact(DominatorPierceImmunityDragon) && target.HasFact(MonsterUtil.CreatureTypes.Dragon))
                    || (caster.HasFact(DominatorPierceImmunityFey) && target.HasFact(MonsterUtil.CreatureTypes.Fey))
                    || (caster.HasFact(DominatorPierceImmunityMagicalBeast) && target.HasFact(MonsterUtil.CreatureTypes.MagicalBeast))
                    || (caster.HasFact(DominatorPierceImmunityMonstrousHumanoid) && target.HasFact(MonsterUtil.CreatureTypes.MonstrousHumanoid))
                    || (caster.HasFact(DominatorPierceImmunityOutsider) && target.HasFact(MonsterUtil.CreatureTypes.Outsider))
                    || (caster.HasFact(DominatorPierceImmunityPlant) && target.HasFact(MonsterUtil.CreatureTypes.Plant))
                    || (caster.HasFact(DominatorPierceImmunityUndead) && target.HasFact(MonsterUtil.CreatureTypes.Undead))
                    || (caster.HasFact(DominatorPierceImmunityVermin) && target.HasFact(MonsterUtil.CreatureTypes.Vermin))
                    || (caster.HasFact(DominatorPierceImmunityAll));
        }
    }

    public class DominatorDomination : UnitFactComponentDelegate,
                                       //IBeforeRulebookEventTriggerHandler<RuleCastSpell>,
                                       //IBeforeRulebookEventTriggerHandler<RuleCanApplyBuff>,
                                       IGlobalSubscriber,
                                       ISubscriber,
                                       IInitiatorRulebookHandler<RuleCastSpell>, 
                                       IRulebookHandler<RuleCastSpell>,
                                       IInitiatorRulebookSubscriber

    {
        public void OnEventAboutToTrigger(RuleCastSpell evt)
        {
            Logger.Log("OnEventAboutToTrigger::Triggered - Rule Cast Spell");
        }

        public void OnEventDidTrigger(RuleCastSpell evt)
        {
            var context = evt.Context;
            if (context?.SpellSchool == SpellSchool.Enchantment)
            {
                var caster = context.Caster;
                var target = context.MainTarget?.Unit;
                if (target == null || caster == null) return;
                var isPiercedImmunity = Dominator.IsImmunityPierced(caster, target);

                if (isPiercedImmunity)
                {
                    context.RemoveSpellDescriptor(SpellDescriptor.Charm);
                    context.RemoveSpellDescriptor(SpellDescriptor.Compulsion);
                    context.RemoveSpellDescriptor(SpellDescriptor.Confusion);
                    context.RemoveSpellDescriptor(SpellDescriptor.Daze);
                    context.RemoveSpellDescriptor(SpellDescriptor.Emotion);
                    context.RemoveSpellDescriptor(SpellDescriptor.Fear);
                    context.RemoveSpellDescriptor(SpellDescriptor.MindAffecting);
                    context.RemoveSpellDescriptor(SpellDescriptor.NegativeEmotion);
                    context.RemoveSpellDescriptor(SpellDescriptor.Sleep);
                }
            }
        }
    }

    [HarmonyPatch(typeof(AbilityTargetHasNoFactUnless), "IsTargetRestrictionPassed")]
    [HarmonyPriority(Priority.Last)]
    static class AbilityTargetHasNoFactUnless_IsTargetRestrictionPassed_Patch
    {
        static void Postfix(AbilityTargetHasNoFactUnless __instance, UnitEntityData caster, TargetWrapper target, ref bool __result)
        {
            var blueprintAbility = __instance.OwnerBlueprint as BlueprintAbility;
            if (caster == null || target?.Unit == null || blueprintAbility == null) return;
            var spellComponent = blueprintAbility.GetComponents<SpellComponent>().FirstOrDefault();
            if (spellComponent?.School == SpellSchool.Enchantment)
                __result = Dominator.IsImmunityPierced(caster, target.Unit);
        }
    }

    [HarmonyPatch(typeof(AbilityTargetHasFact), "IsTargetRestrictionPassed")]
    [HarmonyPriority(Priority.Last)]
    static class AbilityTargetHasFact_IsTargetRestrictionPassed_Patch
    {
        static void Postfix(AbilityTargetHasFact __instance, UnitEntityData caster, TargetWrapper target, ref bool __result)
        {
            var blueprintAbility = __instance.OwnerBlueprint as BlueprintAbility;
            if (caster == null || target?.Unit == null || blueprintAbility == null) return;
            var spellComponent = blueprintAbility.GetComponents<SpellComponent>().FirstOrDefault();
            if (spellComponent?.School == SpellSchool.Enchantment)
                __result = Dominator.IsImmunityPierced(caster, target.Unit);
        }
    }
}
