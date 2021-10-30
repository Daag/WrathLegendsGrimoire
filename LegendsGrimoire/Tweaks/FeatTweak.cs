using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Tweaks
{
    class FeatTweak
    {

        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Logger.LogHeader("Mythic Tweaks");
                TweakCombatExpertise();
                TweakDeadlyAim();
                TweakPointBlankShot();
                TweakPowerAttack();
            }

            public static void TweakCombatExpertise()
            {
                var combatExpertiseActivatableAbility = Resources.GetBlueprint<BlueprintActivatableAbility>("a75f33b4ff41fc846acbac75d1a88442");
                combatExpertiseActivatableAbility.IsOnByDefault = false;
                combatExpertiseActivatableAbility.DoNotTurnOffOnRest = true;
                combatExpertiseActivatableAbility.DeactivateIfCombatEnded = false;
                combatExpertiseActivatableAbility.DeactivateAfterFirstRound = false;
                combatExpertiseActivatableAbility.ActivationType = AbilityActivationType.Immediately;
                combatExpertiseActivatableAbility.DeactivateIfOwnerDisabled = true;
            }

            public static void TweakDeadlyAim()
            {
                var deadlyAimActivatableAbility = Resources.GetBlueprint<BlueprintActivatableAbility>("ccde5ab6edb84f346a74c17ea3e3a70c");
                deadlyAimActivatableAbility.IsOnByDefault = false;
                deadlyAimActivatableAbility.DoNotTurnOffOnRest = true;
            }

            public static void TweakPointBlankShot()
            {
                FeatUtil.Feats.PointBlankShot.AddComponent(Helpers.Create<AttackStatReplacement>(c =>
                {
                    c.ReplacementStat = StatType.Strength;
                    c.m_WeaponTypes = new BlueprintWeaponTypeReference[]
                    {
                    ItemUtil.WeaponTypes.Javelin.ToReference<BlueprintWeaponTypeReference>(),
                    ItemUtil.WeaponTypes.ThrowingAxe.ToReference<BlueprintWeaponTypeReference>()
                    };
                    c.CheckWeaponTypes = true;
                }));
            }

            public static void TweakPowerAttack()
            {
                var powerAttackActivatableAbility = Resources.GetBlueprint<BlueprintActivatableAbility>("a7b339e4f6ff93a4697df5d7a87ff619");
                powerAttackActivatableAbility.IsOnByDefault = false;
                powerAttackActivatableAbility.DoNotTurnOffOnRest = true;
            }
        }
    }
}
