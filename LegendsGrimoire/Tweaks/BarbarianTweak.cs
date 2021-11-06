using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.Mechanics.Facts;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Tweaks
{
    class BarbarianTweak
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Logger.LogHeader("Barbarian Tweaks");
                TweakAlignmentRestrictions();
            }

            static void TweakAlignmentRestrictions()
            {
                ClassUtil.Classes.Barbarian.RemoveComponents<PrerequisiteAlignment>();
            }
        }
    }
}
