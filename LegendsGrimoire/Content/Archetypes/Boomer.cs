using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using LegendsGrimoire.Components;
using LegendsGrimoire.Utilities;
using System;

namespace LegendsGrimoire.Content.Archetypes
{
    static class Boomer
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new Guid("87b5adef3e824b6cb340a5e3b78059a4"));

        public static void AddBoomer()
        {
            var BoomerSpellSlots = Helpers.Create<BlueprintSpellsTable>(bp =>
            {
                bp.name = "BoomerSpellslots";
                bp.AssetGuid = new BlueprintGuid(new Guid("8fee74580c7b49569e7d8512b733bf48"));
                bp.Levels = new SpellsLevelEntry[]
                {
                    new SpellsLevelEntry() { Count = new int[0] },
                    new SpellsLevelEntry() { Count = new int[] { 0, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 4 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 4, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 5, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 5, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 5, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 5, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 4, 3, 2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 4, 4, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6, 6, 5, 5, 5, 4, 4, 4, 4 } }
                };
            });
            Resources.AddBlueprint(BoomerSpellSlots);

            var BoomerSpellbook = Helpers.Create<BlueprintSpellbook>(bp =>
            {
                bp.name = "BoomerSpellbook";
                bp.AssetGuid = new BlueprintGuid(new Guid("18d00350dac642438dd79440763dec67"));
                bp.Name = ClassUtil.Classes.Arcanist.Spellbook.Name;
                bp.CastingAttribute = ClassUtil.Classes.Arcanist.Spellbook.CastingAttribute;
                bp.m_SpellsPerDay = ClassUtil.Classes.Arcanist.Spellbook.m_SpellsPerDay;
                bp.m_SpellSlots = BoomerSpellSlots.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellList = ClassUtil.Classes.Arcanist.Spellbook.m_SpellList;
                bp.m_CharacterClass = ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>();
                bp.Spontaneous = true;
                bp.SpellsPerLevel = 2;
                bp.CanCopyScrolls = true;
                bp.IsArcane = true;
                bp.IsArcanist = true;
            });
            Resources.AddBlueprint(BoomerSpellbook);

            var ElementalAirArcana = Resources.GetBlueprint<BlueprintActivatableAbility>("5f6315dfeb74a564f96f460d72f7206c");
            var ElementalEarthArcana = Resources.GetBlueprint<BlueprintActivatableAbility>("94ce51ed666fc8d42830aa9fe48897f9");
            var ElementalFireArcana = Resources.GetBlueprint<BlueprintActivatableAbility>("924dfcd481c0be54c959c2846b3fb7da");
            var ElementalWaterArcana = Resources.GetBlueprint<BlueprintActivatableAbility>("dd484f0706325de40aee5dba15fbce45");

            var BoomerDamageSubstitutionSonicBuff = CreateSubstitutionBuff(
                "Sonic", 
                new BlueprintGuid(new Guid("adf135214f74437c8a10aa30d15e2970")), 
                SpellUtil.Spells.SoundBurst.Icon, 
                SpellDescriptor.Sonic
            );
            var BoomerDamageSubstitutionAcidBuff = CreateSubstitutionBuff(
                "Acid",
                new BlueprintGuid(new Guid("363dd97b908d42d794fd7cff49bc80ea")),
                ElementalEarthArcana.Icon,
                SpellDescriptor.Acid
            );
            var BoomerDamageSubstitutionColdBuff = CreateSubstitutionBuff(
                "Cold",
                new BlueprintGuid(new Guid("3e819f0626984e188eca6cb3cca5e686")),
                ElementalWaterArcana.Icon,
                SpellDescriptor.Cold
            );
            var BoomerDamageSubstitutionElectricityBuff = CreateSubstitutionBuff(
                "Electricity",
                new BlueprintGuid(new Guid("eb96ab1897c04568bf60728af32170ec")),
                ElementalAirArcana.Icon,
                SpellDescriptor.Electricity
            );
            var BoomerDamageSubstitutionFireBuff = CreateSubstitutionBuff(
                "Fire",
                new BlueprintGuid(new Guid("c7afedad488f49df961a66d12c53c653")),
                ElementalFireArcana.Icon,
                SpellDescriptor.Fire
            );

            var BoomerDamageSubstitutionSonicActivatableAbility = CreateSubstituteActivatableAbility(
                "Sonic",
                BoomerDamageSubstitutionSonicBuff.Name,
                BoomerDamageSubstitutionSonicBuff.Description,
                new BlueprintGuid(new Guid("687c4e0afe14473a9acbeae0378c8557")),
                BoomerDamageSubstitutionSonicBuff,
                BoomerDamageSubstitutionSonicBuff.Icon
            );
            var BoomerDamageSubstitutionAcidActivatableAbility = CreateSubstituteActivatableAbility(
                "Acid",
                BoomerDamageSubstitutionAcidBuff.Name,
                BoomerDamageSubstitutionAcidBuff.Description,
                new BlueprintGuid(new Guid("292be60e0a1e47c69d12b8a78f817ebb")),
                BoomerDamageSubstitutionAcidBuff,
                BoomerDamageSubstitutionAcidBuff.Icon
            );
            var BoomerDamageSubstitutionColdActivatableAbility = CreateSubstituteActivatableAbility(
                "Cold",
                BoomerDamageSubstitutionColdBuff.Name,
                BoomerDamageSubstitutionColdBuff.Description,
                new BlueprintGuid(new Guid("55c7b8e1ac9d4a54aac49a5703ee3b87")),
                BoomerDamageSubstitutionColdBuff,
                BoomerDamageSubstitutionColdBuff.Icon
            );
            var BoomerDamageSubstitutionElectricityActivatableAbility = CreateSubstituteActivatableAbility(
                "Electricity",
                BoomerDamageSubstitutionElectricityBuff.Name,
                BoomerDamageSubstitutionElectricityBuff.Description,
                new BlueprintGuid(new Guid("4e2b2b920dd5494e87595328d285cd20")),
                BoomerDamageSubstitutionElectricityBuff,
                BoomerDamageSubstitutionElectricityBuff.Icon
            );
            var BoomerDamageSubstitutionFireActivatableAbility = CreateSubstituteActivatableAbility(
                "Fire",
                BoomerDamageSubstitutionFireBuff.Name,
                BoomerDamageSubstitutionFireBuff.Description,
                new BlueprintGuid(new Guid("938d0cc476d5493e9f8d74f8433fb111")),
                BoomerDamageSubstitutionFireBuff,
                BoomerDamageSubstitutionFireBuff.Icon
            );

            var BoomerBomb = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerBomb";
                bp.AssetGuid = new BlueprintGuid(new Guid("14f59c9b722f4787a559f7873d102763"));
                bp.SetName("Boomber Bomb");
                bp.SetDescription("You can change spells you cast to any energy type among acid, cold, electricity, fire and sonic." + "\n"
                    + "Whenever you cast a {g|Encyclopedia:Spell}spell{/g} with {g|Encyclopedia:Energy_Damage}energy damage{/g}, that spell deals +2 "
                    + "point of {g|Encyclopedia:Damage}damage{/g} per die {g|Encyclopedia:Dice}rolled{/g}.");
                bp.IsClassFeature = true;
                bp.Ranks = 5;
                bp.AddComponent(Helpers.Create<AddFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BoomerDamageSubstitutionSonicActivatableAbility.ToReference<BlueprintUnitFactReference>(),
                        BoomerDamageSubstitutionAcidActivatableAbility.ToReference<BlueprintUnitFactReference>(),
                        BoomerDamageSubstitutionColdActivatableAbility.ToReference<BlueprintUnitFactReference>(),
                        BoomerDamageSubstitutionElectricityActivatableAbility.ToReference<BlueprintUnitFactReference>(),
                        BoomerDamageSubstitutionFireActivatableAbility.ToReference<BlueprintUnitFactReference>()
                    };
                }));
                bp.AddComponent<BoomerBombDamage>();
            });
            Resources.AddBlueprint(BoomerBomb);

            var BoomerBlastAbility = Helpers.Create<BlueprintAbility>(bp => {
                bp.name = "BoomerBlastAbility";
                bp.AssetGuid = new BlueprintGuid(new Guid("4ba50e0f2b0444f28e55344e3ceef3e5"));
                bp.SetName("Boomer Blast");
                bp.SetDescription("Starting at 1st level, you can create a localized sonic boom as a standard action, targeting any "
                    + "foe within 30 feet as a ranged touch attack. The boomer blast deals 1d6 points of sonice damage + 1 "
                    + "for every two sorcerer levels you possess. You deal 2d6 at 5th level, 3d6 at 11th level and 4d6 at 17th level.");
                bp.LocalizedDuration = new Kingmaker.Localization.LocalizedString();
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.CanTargetEnemies = true;
                bp.Range = AbilityRange.Close;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = SpellUtil.Spells.BatteringBlast.Icon;
                bp.ResourceAssetIds = SpellUtil.Spells.BatteringBlast.ResourceAssetIds;
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Evocation;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { SpellUtil.Spells.BatteringBlast.GetComponent<AbilityDeliverProjectile>().m_Projectiles[0] };
                    c.m_LineWidth = new Kingmaker.Utility.Feet() { m_Value = 5 };
                    c.m_Weapon = SpellUtil.Spells.BatteringBlast.GetComponent<AbilityDeliverProjectile>().m_Weapon;
                    c.NeedAttackRoll = true;
                });
                var dealDamage = Helpers.Create<ContextActionDealDamage>(c => {
                    c.DamageType = new DamageTypeDescription
                    {
                        Type = DamageType.Energy,
                    };
                    c.Duration = new ContextDurationValue()
                    {
                        m_IsExtendable = true,
                        DiceCountValue = new ContextValue(),
                        BonusValue = new ContextValue()
                    };
                    c.Value = new ContextDiceValue
                    {
                        DiceType = DiceType.D6,
                        DiceCountValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageDice
                        },
                        BonusValue = new ContextValue
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageBonus
                        }
                    };
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList();
                    c.Actions.Actions = new GameAction[] { dealDamage };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                    c.m_StartLevel = 1;
                    c.m_StepLevel = 2;
                    c.m_Max = 20;
                    c.m_Min = 1;
                    c.m_UseMin = true;
                    c.m_Class = new BlueprintCharacterClassReference[] { ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>() };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.DelayedStartPlusDivStep;
                    c.m_StartLevel = -1;
                    c.m_StepLevel = 6;
                    c.m_Max = 20;
                    c.m_Min = 1;
                    c.m_UseMin = true;
                    c.m_Class = new BlueprintCharacterClassReference[] { ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>() };
                });
            });
            Resources.AddBlueprint(BoomerBlastAbility);

            var BoomerBlast = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "BoomerBlast";
                bp.AssetGuid = new BlueprintGuid(new Guid("faf5db0f382447959ebbf74267ef52ad"));
                bp.SetName("Boomer Blast");
                bp.SetDescription(BoomerBlastAbility.Description);
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        BoomerBlastAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_Icon = BoomerBlastAbility.Icon;
            });
            Resources.AddBlueprint(BoomerBlast);

            var BoomerCombatInstincts = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerCombatInstincts";
                bp.AssetGuid = new BlueprintGuid(new Guid("c6012ae2fa96456c950dcde9540db597"));
                bp.SetName("Combat Instincts");
                bp.SetDescription("Your ability to see sound grants you an advantage in combat. At 3rd level and every "
                    + "4 levels thereafter, you gain a +1 insight bonus on initiative checks.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c =>
                {
                    c.m_Progression = ContextRankProgression.StartPlusDivStep;
                    c.m_StartLevel = 3;
                    c.m_StepLevel = 4;
                    c.m_Max = 20;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Class = new BlueprintCharacterClassReference[]
                    {
                        ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>()
                    };
                }));
                bp.AddComponent(Helpers.Create<AddContextStatBonus>(c =>
                {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Initiative;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank
                    };
                }));
            });
            Resources.AddBlueprint(BoomerCombatInstincts);

            var BoomerBlastingFocus = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerBlastingFocus";
                bp.AssetGuid = new BlueprintGuid(new Guid("76c38664286e45f2b818cae69f9f7a35"));
                bp.SetName("Blasting Focus");
                bp.SetDescription("You have gained mastery in destroying your foes by blasting them to smithereens. "
                    + "You gain a +2 bonus on spells of the evocation school.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent(Helpers.Create<IncreaseSpellSchoolDC>(c =>
                {
                    c.BonusDC = 2;
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.School = SpellSchool.Evocation;
                }));
            });
            Resources.AddBlueprint(BoomerBlastingFocus);

            var BoomerSpeedOfSound = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerSpeedOfSound";
                bp.AssetGuid = new BlueprintGuid(new Guid("0f0ceaaee653423d921b0d1496249050"));
                bp.SetName("Speed of Sound");
                bp.SetDescription("Your mastery of sound lets you move with it.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent(Helpers.Create<BuffMovementSpeed>(c =>
                {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Value = 30;
                    c.ContextBonus = new ContextValue();
                    c.CappedOnMultiplier = false;
                }));
            });
            Resources.AddBlueprint(BoomerSpeedOfSound);

            var BoomerArchetype = Helpers.Create<BlueprintArchetype>(bp =>
            {
                bp.name = "BoomerArchetype";
                bp.AssetGuid = AssetGuid;
                bp.LocalizedName = Helpers.CreateString("BoomerArchetype.Name", "Boomer");
                bp.LocalizedDescription = Helpers.CreateString("BoomerArchetype.Description", "");
                bp.m_ReplaceSpellbook = BoomerSpellbook.ToReference<BlueprintSpellbookReference>();
                bp.RemoveFeatures = new LevelEntry[]
                {
                    new LevelEntry { Level = 1, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 3, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 9, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 15, Features = { FeatUtil.Selections.ArcanistExploitSelection } }
                };
                bp.AddFeatures = new LevelEntry[]
                {
                    new LevelEntry {Level = 1, Features = { BoomerBlast, BoomerBomb } },
                    new LevelEntry {Level = 3, Features = { BoomerCombatInstincts } },
                    new LevelEntry {Level = 9, Features = { BoomerBlastingFocus } },
                    new LevelEntry {Level = 15, Features = { BoomerSpeedOfSound } },
                };
            });
            Resources.AddBlueprint(BoomerArchetype);

            ClassUtil.Classes.Arcanist.m_Archetypes =
                ClassUtil.Classes.Arcanist.m_Archetypes.AppendToArray(BoomerArchetype.ToReference<BlueprintArchetypeReference>());
            ClassUtil.Classes.Arcanist.Progression.UIGroups = ClassUtil.Classes.Arcanist.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    BoomerBomb,
                    BoomerBlast,
                    BoomerCombatInstincts,
                    BoomerBlastingFocus,
                    BoomerSpeedOfSound
                )
            );
            Logger.LogPatch("Added", BoomerArchetype);
        }

        static BlueprintBuff CreateSubstitutionBuff(string energy, BlueprintGuid assetId, UnityEngine.Sprite icon, SpellDescriptor energyType)
        {
            var buff = Helpers.Create<BlueprintBuff>(bp =>
            {
                bp.name = $"BoomerDamageSubstitution{energy}Buff";
                bp.AssetGuid = assetId;
                bp.SetName($"Boomer Substitution - {energy}");
                bp.SetDescription("All {g|Encyclopedia:Spell}spells{/g} that deal {g|Encyclopedia:Energy_Damage}energy damage{/g} that you cast will "
                    + $"deal {energy.ToLower()} {{g|Encyclopedia:Damage}}damage{{/g}} instead. This also changes the spell's type to a {energy.ToLower()} spell.");
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.m_Icon = icon;
                bp.AddComponent<BoomerDamageSubstitution>(c =>
                {
                    c.EnergyType = energyType;
                });
            });
            Resources.AddBlueprint(buff);
            return buff;
        }

        static BlueprintActivatableAbility CreateSubstituteActivatableAbility(string energy, string name, string desc, BlueprintGuid assetId, BlueprintBuff buff, UnityEngine.Sprite icon)
        {
            var ability = Helpers.Create<BlueprintActivatableAbility>(bp =>
            {
                bp.name = $"BoomerDamageSubstitution{energy}Ability";
                bp.AssetGuid = assetId;
                bp.SetName(name);
                bp.SetDescription(desc);
                bp.m_Buff = buff.ToReference<BlueprintBuffReference>();
                bp.IsOnByDefault = false;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.m_Icon = icon;
                bp.Group = ActivatableAbilityGroup.FormInfusion;
            });
            Resources.AddBlueprint(ability);
            return ability;
        }
    }

    public class BoomerBombDamage : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {
            var context = evt.Reason.Context;
            var sourceAbility = context.SourceAbility;
            if (sourceAbility == null || !sourceAbility.IsSpell || sourceAbility.Type == AbilityType.Physical
                || !context.SpellDescriptor.HasAnyFlag(SpellDescriptor.Sonic | SpellDescriptor.Acid | SpellDescriptor.Fire | SpellDescriptor.Cold | SpellDescriptor.Electricity))
            {
                return;
            }
            foreach (var damage in evt.DamageBundle)
            {
                damage.AddModifier(2 * damage.Dice.Rolls, base.Fact);
            }
        }

        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
        }
    }
}
