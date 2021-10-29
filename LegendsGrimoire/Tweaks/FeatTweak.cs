using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
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
                TweakPointBlankShot();
            }

            static readonly BlueprintFeature pointBlankShot = Resources.GetBlueprint<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab");
            static readonly BlueprintWeaponType javelin = Resources.GetBlueprint<BlueprintWeaponType>("a70cea34b275522458654beb3c53fe3f");
            static readonly BlueprintWeaponType throwingAxe = Resources.GetBlueprint<BlueprintWeaponType>("ca131c71f4fefcb48b30b5991520e01d");

            public static void TweakPointBlankShot()
            {
                pointBlankShot.AddComponent(Helpers.Create<AttackStatReplacement>(c =>
                {
                    c.ReplacementStat = StatType.Strength;
                    c.m_WeaponTypes = new BlueprintWeaponTypeReference[]
                    {
                    javelin.ToReference<BlueprintWeaponTypeReference>(),
                    throwingAxe.ToReference<BlueprintWeaponTypeReference>()
                    };
                    c.CheckWeaponTypes = true;
                }));
            }
        }
    }
}
