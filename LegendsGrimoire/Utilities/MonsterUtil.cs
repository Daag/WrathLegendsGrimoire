using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Utilities
{
    static class MonsterUtil
    {
        public static class CreatureTypes
        {
            public static BlueprintFeature Aberration => Resources.GetBlueprint<BlueprintFeature>("3bec99efd9a363242a6c8d9957b75e91");
            public static BlueprintFeature Animal => Resources.GetBlueprint<BlueprintFeature>("a95311b3dc996964cbaa30ff9965aaf6");
            public static BlueprintFeature Construct => Resources.GetBlueprint<BlueprintFeature>("fd389783027d63343b4a5634bd81645f");
            public static BlueprintFeature Dragon => Resources.GetBlueprint<BlueprintFeature>("455ac88e22f55804ab87c2467deff1d6");
            public static BlueprintFeature Fey => Resources.GetBlueprint<BlueprintFeature>("018af8005220ac94a9a4f47b3e9c2b4e");
            public static BlueprintFeature MagicalBeast => Resources.GetBlueprint<BlueprintFeature>("625827490ea69d84d8e599a33929fdc6");
            public static BlueprintFeature MonstrousHumanoid => Resources.GetBlueprint<BlueprintFeature>("57614b50e8d86b24395931fffc5e409b");
            public static BlueprintFeature Outsider => Resources.GetBlueprint<BlueprintFeature>("9054d3988d491d944ac144e27b6bc318");
            public static BlueprintFeature Plant => Resources.GetBlueprint<BlueprintFeature>("706e61781d692a042b35941f14bc41c5");
            public static BlueprintFeature Undead => Resources.GetBlueprint<BlueprintFeature>("734a29b693e9ec346ba2951b27987e33");
            public static BlueprintFeature Vermin => Resources.GetBlueprint<BlueprintFeature>("09478937695300944a179530664e42ec");
        }
    }
}
