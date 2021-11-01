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

                Archetypes.Dominator.AddDominator();

                Backgrounds.ArcaneTinker.AddArcaneTinker();
                Backgrounds.CunningDiplomat.AddCunningDiplomat();
                Backgrounds.DivineVoice.AddDivineVoice();
                Backgrounds.FeyTouched.AddFeyTouched();

                Feats.BladeDancer.AddBladeDancer();
                Feats.ProdigiousTwoWeaponFighting.AddProdigiousTwoWeaponFighting();
                Feats.PolearmDancer.AddPolearmDancer();
                Feats.SkillTraining.AddSkillTraining();

                Legendary.Adventurer.AddLegendaryAdventurer();
            }
        }
    }
}
