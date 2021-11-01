using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;
using System;

namespace LegendsGrimoire.Content.Archetypes
{
    static class Dominator
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new Guid("f0574ff607cd413f87830a81d0d934d2"));
        public static BlueprintGuid DominatorBonusSpellKnown1AssetGuid = new BlueprintGuid(new Guid("903a13b411b44c98864ad9d9821788de"));
        public static BlueprintGuid DominatorBonusSpellKnown2AssetGuid = new BlueprintGuid(new Guid("4ab3a32955b244159f097ae9c984fe84"));
        public static BlueprintGuid DominatorBonusSpellKnown3AssetGuid = new BlueprintGuid(new Guid("74b99b6a14fc4e97abe9c37f753b91f2"));
        public static BlueprintGuid DominatorBonusSpellKnown4AssetGuid = new BlueprintGuid(new Guid("77113b2626424da589c17cdd2df91a17"));
        public static BlueprintGuid DominatorBonusSpellKnown5AssetGuid = new BlueprintGuid(new Guid("fb4e4d928c214d62a89a8d2c91d51e22"));
        public static BlueprintGuid DominatorBonusSpellKnown6AssetGuid = new BlueprintGuid(new Guid("55980ab2c5274f6597cb08b7dbf91a70"));
        public static BlueprintGuid DominatorBonusSpellKnown7AssetGuid = new BlueprintGuid(new Guid("fd90f40ee0104290abd2a6d57dae243f"));
        public static BlueprintGuid DominatorBonusSpellKnown8AssetGuid = new BlueprintGuid(new Guid("6f2e30eb60704c1ab3f47c6d55467106"));
        public static BlueprintGuid DominatorBonusSpellKnown9AssetGuid = new BlueprintGuid(new Guid("077a5e3cc3064ab09cca2cd8e591b7b7"));
        
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
            });
            Resources.AddBlueprint(DominatorFocus);

            var DominatorBonusSpellKnown1 = CreateBonusSpellKnown(SpellUtil.Spells.Command, 1, DominatorBonusSpellKnown1AssetGuid);
            var DominatorBonusSpellKnown2 = CreateBonusSpellKnown(SpellUtil.Spells.HoldPerson, 2, DominatorBonusSpellKnown2AssetGuid);
            var DominatorBonusSpellKnown3 = CreateBonusSpellKnown(SpellUtil.Spells.OverwhelmingGrief, 3, DominatorBonusSpellKnown3AssetGuid);
            var DominatorBonusSpellKnown4 = CreateBonusSpellKnown(SpellUtil.Spells.HoldMonster, 4, DominatorBonusSpellKnown4AssetGuid);
            var DominatorBonusSpellKnown5 = CreateBonusSpellKnown(SpellUtil.Spells.CommandGreater, 5, DominatorBonusSpellKnown5AssetGuid);
            var DominatorBonusSpellKnown6 = CreateBonusSpellKnown(SpellUtil.Spells.HoldPersonMass, 6, DominatorBonusSpellKnown6AssetGuid);
            var DominatorBonusSpellKnown7 = CreateBonusSpellKnown(SpellUtil.Spells.Insanity, 7, DominatorBonusSpellKnown7AssetGuid);
            var DominatorBonusSpellKnown8 = CreateBonusSpellKnown(SpellUtil.Spells.HoldMonsterMass, 8, DominatorBonusSpellKnown8AssetGuid);
            var DominatorBonusSpellKnown9 = CreateBonusSpellKnown(SpellUtil.Spells.OverwhelmingPresence, 9, DominatorBonusSpellKnown9AssetGuid);

            //remove exploit 1, 7, 13, 19

            //add spells known and overcome animal, magical beast, monstrous humanoid and vermin (Serpentine Bloodline Arcana)
            //add overcome undead (Undead Bloodline Arcana)
            //add overcome plant
            //add overcome construct

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
                    new LevelEntry { Level = 4, Features = { DominatorBonusSpellKnown2 } },
                    new LevelEntry { Level = 6, Features = { DominatorBonusSpellKnown3 } },
                    new LevelEntry { Level = 8, Features = { DominatorBonusSpellKnown4 } },
                    new LevelEntry { Level = 10, Features = { DominatorBonusSpellKnown5 } },
                    new LevelEntry { Level = 12, Features = { DominatorBonusSpellKnown6 } },
                    new LevelEntry { Level = 14, Features = { DominatorBonusSpellKnown7 } },
                    new LevelEntry { Level = 16, Features = { DominatorBonusSpellKnown8 } },
                    new LevelEntry { Level = 18, Features = { DominatorBonusSpellKnown9 } },
                };
            });
            Resources.AddBlueprint(DominatorArchetype);

            ClassUtil.Classes.Arcanist.m_Archetypes = 
                ClassUtil.Classes.Arcanist.m_Archetypes.AppendToArray(DominatorArchetype.ToReference<BlueprintArchetypeReference>());
            ClassUtil.Classes.Arcanist.Progression.UIGroups = ClassUtil.Classes.Arcanist.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    DominatorFocus
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
    }

    public class DominatorDomination : IBeforeRulebookEventTriggerHandler<RuleCastSpell>,
                                       IBeforeRulebookEventTriggerHandler<RuleCanApplyBuff>
    {
        public void OnBeforeRulebookEventTrigger(RuleCastSpell evt)
        {
            var context = evt.Context;
        }

        public void OnBeforeRulebookEventTrigger(RuleCanApplyBuff evt)
        {
            var context = evt.Context;
        }
    }
}
