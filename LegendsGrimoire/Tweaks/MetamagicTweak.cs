using HarmonyLib;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Commands.Base;

namespace LegendsGrimoire.Tweaks
{
    class MetamagicTweak
    {
        [HarmonyPatch(typeof(AbilityData), "RequireFullRoundAction", MethodType.Getter)]
        [HarmonyPriority(Priority.Last)]
        static class AbilityData_RequireFullRoundAction_Patch
        {
            static void Postfix(AbilityData __instance, ref bool __result)
            {
                if (__instance.RuntimeActionType == UnitCommand.CommandType.Standard)
                {
                    MetamagicData metamagicData = __instance.MetamagicData;
                    if (metamagicData == null || !metamagicData.Has(Metamagic.Quicken))
                    {
                        __result = __instance.Blueprint.IsFullRoundAction;
                    }
                }
            }
        }
    }
}
