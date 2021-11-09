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
            var EarPiercingScream = SpellUtil.Spells.EarPiercingScream;
            var SoundBurst = SpellUtil.Spells.SoundBurst;
            var LightningBolt = SpellUtil.Spells.LightningBolt;
            var Shout = SpellUtil.Spells.Shout;
            var IcyPrison = SpellUtil.Spells.IcyPrison;
            var ChainLightning = SpellUtil.Spells.ChainLightning;
            var KiShout = SpellUtil.Spells.KiShout;
            var ShoutGreater = SpellUtil.Spells.ShoutGreater;
            var IcyPrisonMass = SpellUtil.Spells.IcyPrisonMass;

            var BoomerDamageSubstitutionBuff = Helpers.Create<BlueprintBuff>(bp =>
            {
                bp.name = "BoomerDamageSubstitutionBuff";
                bp.AssetGuid = new BlueprintGuid(new Guid("363dd97b908d42d794fd7cff49bc80ea"));
                bp.SetName("Boomer Substitution");
                bp.SetDescription("All {g|Encyclopedia:Spell}spells{/g} that deal {g|Encyclopedia:Energy_Damage}energy damage{/g} that you cast will "
                    + "deal sonic {g|Encyclopedia:Damage}damage{/g} instead. This also changes the spell's type to a sonic spell.");
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.m_Icon = SoundBurst.Icon;
                bp.AddComponent<BoomerDamageSubstitution>();
            });
            Resources.AddBlueprint(BoomerDamageSubstitutionBuff);

            var BoomerDamageSubstitutionActivatableAbility = Helpers.Create<BlueprintActivatableAbility>(bp =>
            {
                bp.name = "BoomerDamageSubstitutionAbility";
                bp.AssetGuid = new BlueprintGuid(new Guid("687c4e0afe14473a9acbeae0378c8557"));
                bp.SetName(BoomerDamageSubstitutionBuff.Name);
                bp.SetDescription(BoomerDamageSubstitutionBuff.Description);
                bp.m_Buff = BoomerDamageSubstitutionBuff.ToReference<BlueprintBuffReference>();
                bp.IsOnByDefault = false;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.m_Icon = SoundBurst.Icon;
            });
            Resources.AddBlueprint(BoomerDamageSubstitutionActivatableAbility);

            var BoomerBomb = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerBomb";
                bp.AssetGuid = new BlueprintGuid(new Guid("14f59c9b722f4787a559f7873d102763"));
                bp.SetName("Boomber Bomb");
                bp.SetDescription(BoomerDamageSubstitutionBuff.Description + "/n"
                    + "Whenever you cast a {g|Encyclopedia:Spell}spell{/g} with {g|Encyclopedia:Energy_Damage}sonic damage{/g}, that spell deals +2 "
                    + "point of {g|Encyclopedia:Damage}damage{/g} per die {g|Encyclopedia:Dice}rolled{/g}.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent(Helpers.Create<AddFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BoomerDamageSubstitutionActivatableAbility.ToReference<BlueprintUnitFactReference>()
                    };
                }));
                bp.AddComponent<BoomerBombDamage>();
            });
            Resources.AddBlueprint(BoomerBomb);

            var BoomerConversionSpells = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BoomerConversionSpellsFeature";
                bp.AssetGuid = new BlueprintGuid(new Guid("38c1869554a547c89e73dd39f4a15b81"));
                bp.SetName("Sonic Spells");
                bp.SetDescription("Your boomer mastery over sound, lets you convert your spell slots to specific sound based spells.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent(Helpers.Create<SpontaneousSpellConversion>(c =>
                {
                    c.m_CharacterClass = ClassUtil.Classes.Arcanist.ToReference<BlueprintCharacterClassReference>();
                    c.m_SpellsByLevel = new BlueprintAbilityReference[]
                    {
                        null,
                        EarPiercingScream.ToReference<BlueprintAbilityReference>(),
                        SoundBurst.ToReference<BlueprintAbilityReference>(),
                        LightningBolt.ToReference<BlueprintAbilityReference>(),
                        Shout.ToReference<BlueprintAbilityReference>(),
                        IcyPrison.ToReference<BlueprintAbilityReference>(),
                        ChainLightning.ToReference<BlueprintAbilityReference>(),
                        KiShout.ToReference<BlueprintAbilityReference>(),
                        ShoutGreater.ToReference<BlueprintAbilityReference>(),
                        IcyPrisonMass.ToReference<BlueprintAbilityReference>()
                    };
                }));
            });
            Resources.AddBlueprint(BoomerConversionSpells);

            var BoomerBonusSpellKnown1 = CreateBonusSpellKnown(SpellUtil.Spells.EarPiercingScream, 1, new BlueprintGuid(new Guid("7071384001994314a92c98d5df38a8cd")));
            var BoomerBonusSpellKnown2 = CreateBonusSpellKnown(SpellUtil.Spells.SoundBurst, 2, new BlueprintGuid(new Guid("8f955886dd18438fa1e5d1b763b95c00")));
            var BoomerBonusSpellKnown3 = CreateBonusSpellKnown(SpellUtil.Spells.LightningBolt, 3, new BlueprintGuid(new Guid("1482779198324fc9a2b280448bbfa692")));
            var BoomerBonusSpellKnown4 = CreateBonusSpellKnown(SpellUtil.Spells.Shout, 4, new BlueprintGuid(new Guid("96e57a648b88442f8e023cc08a80d8ab")));
            var BoomerBonusSpellKnown5 = CreateBonusSpellKnown(SpellUtil.Spells.IcyPrison, 5, new BlueprintGuid(new Guid("5c10df1b77dd406eaf3de50b092668f9")));
            var BoomerBonusSpellKnown6 = CreateBonusSpellKnown(SpellUtil.Spells.ChainLightning, 6, new BlueprintGuid(new Guid("553ef1d68a244438a4d7acbaecc00764")));
            var BoomerBonusSpellKnown7 = CreateBonusSpellKnown(SpellUtil.Spells.KiShout, 7, new BlueprintGuid(new Guid("0038fb36e6f1479e975ca45036dd0bf1")));
            var BoomerBonusSpellKnown8 = CreateBonusSpellKnown(SpellUtil.Spells.ShoutGreater, 8, new BlueprintGuid(new Guid("4e47d003cafa4bf49ab609863eb36341")));
            var BoomerBonusSpellKnown9 = CreateBonusSpellKnown(SpellUtil.Spells.IcyPrisonMass, 9, new BlueprintGuid(new Guid("a16358b7b0df481386cf6f38197f2ce8")));

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
                bp.RemoveFeatures = new LevelEntry[]
                {
                    new LevelEntry { Level = 1, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 3, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 9, Features = { FeatUtil.Selections.ArcanistExploitSelection } },
                    new LevelEntry { Level = 15, Features = { FeatUtil.Selections.ArcanistExploitSelection } }
                };
                bp.AddFeatures = new LevelEntry[]
                {
                    new LevelEntry {Level = 1, Features = { BoomerBlast, BoomerBomb, BoomerConversionSpells } },
                    new LevelEntry {Level = 2, Features = { BoomerBonusSpellKnown1 } },
                    new LevelEntry {Level = 3, Features = { BoomerCombatInstincts } },
                    new LevelEntry {Level = 4, Features = { BoomerBonusSpellKnown2 } },
                    new LevelEntry {Level = 6, Features = { BoomerBonusSpellKnown3 } },
                    new LevelEntry {Level = 8, Features = { BoomerBonusSpellKnown4 } },
                    new LevelEntry {Level = 9, Features = { BoomerBlastingFocus } },
                    new LevelEntry {Level = 10, Features = { BoomerBonusSpellKnown5 } },
                    new LevelEntry {Level = 12, Features = { BoomerBonusSpellKnown6 } },
                    new LevelEntry {Level = 14, Features = { BoomerBonusSpellKnown7 } },
                    new LevelEntry {Level = 15, Features = { BoomerSpeedOfSound } },
                    new LevelEntry {Level = 16, Features = { BoomerBonusSpellKnown8 } },
                    new LevelEntry {Level = 18, Features = { BoomerBonusSpellKnown9 } },
                };
            });
            Resources.AddBlueprint(BoomerArchetype);

            ClassUtil.Classes.Arcanist.m_Archetypes =
                ClassUtil.Classes.Arcanist.m_Archetypes.AppendToArray(BoomerArchetype.ToReference<BlueprintArchetypeReference>());
            ClassUtil.Classes.Arcanist.Progression.UIGroups = ClassUtil.Classes.Arcanist.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    BoomerBomb,
                    BoomerBlast,
                    BoomerConversionSpells,
                    BoomerCombatInstincts,
                    BoomerBlastingFocus,
                    BoomerSpeedOfSound
                ),
                Helpers.CreateUIGroup(
                    BoomerBonusSpellKnown1,
                    BoomerBonusSpellKnown2,
                    BoomerBonusSpellKnown3,
                    BoomerBonusSpellKnown4,
                    BoomerBonusSpellKnown5,
                    BoomerBonusSpellKnown6,
                    BoomerBonusSpellKnown7,
                    BoomerBonusSpellKnown8,
                    BoomerBonusSpellKnown9
                )
            );
            Logger.LogPatch("Added", BoomerArchetype);
        }

        static BlueprintFeature CreateBonusSpellKnown(BlueprintAbility spell, int level, BlueprintGuid assetGuid)
        {
            var bonusSpellKnown = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = $"BoomerBonusSpellKnown{level}";
                bp.AssetGuid = assetGuid;
                bp.SetName(spell.Name);
                bp.SetDescription("At 2nd level, and every two levels thereafter, the boomer learns an additional spell.\n"
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

    public class BoomerBombDamage : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {
            var context = evt.Reason.Context;
            var sourceAbility = context.SourceAbility;
            if (sourceAbility == null || !context.SpellDescriptor.HasAnyFlag(SpellDescriptor.Sonic)
                || !sourceAbility.IsSpell || sourceAbility.Type == AbilityType.Physical)
            {
                return;
            }
            foreach (var item in evt.DamageBundle)
            {
                item.AddModifier(2, base.Fact);
            }
        }

        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
        }
    }
}
