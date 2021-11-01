using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Utilities
{
    static class SpellUtil
    {
        public static class Spells
        {
            //Enchantment
            public static BlueprintAbility Command => Resources.GetBlueprint<BlueprintAbility>("feb70aab86cc17f4bb64432c83737ac2");
            public static BlueprintAbility CommandGreater => Resources.GetBlueprint<BlueprintAbility>("cb15cc8d7a5480648855a23b3ba3f93d");
            public static BlueprintAbility Confusion => Resources.GetBlueprint<BlueprintAbility>("cf6c901fb7acc904e85c63b342e9c949");
            public static BlueprintAbility HoldMonster => Resources.GetBlueprint<BlueprintAbility>("41e8a952da7a5c247b3ec1c2dbb73018");
            public static BlueprintAbility HoldMonsterMass => Resources.GetBlueprint<BlueprintAbility>("7f4b66a2b1fdab142904a263c7866d46");
            public static BlueprintAbility HoldPerson => Resources.GetBlueprint<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            public static BlueprintAbility HoldPersonMass => Resources.GetBlueprint<BlueprintAbility>("defbbeaef79eda64abc645036228a31b");
            public static BlueprintAbility Insanity => Resources.GetBlueprint<BlueprintAbility>("2b044152b3620c841badb090e01ed9de");
            public static BlueprintAbility OverwhelmingGrief => Resources.GetBlueprint<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");
            public static BlueprintAbility OverwhelmingPresence => Resources.GetBlueprint<BlueprintAbility>("41cf93453b027b94886901dbfc680cb9");
        }
    }
}
