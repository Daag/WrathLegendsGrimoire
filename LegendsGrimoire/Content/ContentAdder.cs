using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content
{
    class ContentAdder
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Logger.LogHeader("Loading New Content");

                Feats.BladeDancer.AddBladeDancer();
                Feats.ProdigiousTwoWeaponFighting.AddProdigiousTwoWeaponFighting();
            }
        }
    }
}
