using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.Mechanics.Facts;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Tweaks
{
    class MythicTweak
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
                TweakAbundantCasting();
                TweakEnduringSpells();
            }

            static readonly BlueprintFeature abundantCasting = Resources.GetBlueprint<BlueprintFeature>("cf594fa8871332a4ba861c6002480ec2");

            public static void TweakAbundantCasting()
            {
                var abundantCastingAddSpellsPerDay = abundantCasting.GetComponent<AddSpellsPerDay>();
                abundantCastingAddSpellsPerDay.Levels = new int[] {
                    1, 2, 3, 4, 5, 6, 7, 8, 9
                };
                Logger.LogPatch("Patched", abundantCasting);
            }

            static readonly BlueprintFeature enduringSpells = Resources.GetBlueprint<BlueprintFeature>("2f206e6d292bdfb4d981e99dcf08153f");

            public static void TweakEnduringSpells()
            {
                var enduringSpellsComponent = enduringSpells.GetComponent<EnduringSpells>();
                enduringSpellsComponent.m_Greater = enduringSpells.ToReference<BlueprintUnitFactReference>();
                Logger.LogPatch("Patched", enduringSpells);
            }
        }
    }
}
