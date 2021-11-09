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

            //Evocation
            public static BlueprintAbility BatteringBlast => Resources.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc");
            public static BlueprintAbility EarPiercingScream => Resources.GetBlueprint<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
            public static BlueprintAbility ChainLightning => Resources.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");
            public static BlueprintAbility IcyPrison => Resources.GetBlueprint<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
            public static BlueprintAbility IcyPrisonMass => Resources.GetBlueprint<BlueprintAbility>("1852a9393a23d5741b650a1ea7078abc");
            public static BlueprintAbility KiShout => Resources.GetBlueprint<BlueprintAbility>("5c8cde7f0dcec4e49bfa2632dfe2ecc0");
            public static BlueprintAbility LightningBolt => Resources.GetBlueprint<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            public static BlueprintAbility Shout => Resources.GetBlueprint<BlueprintAbility>("f09453607e683784c8fca646eec49162");
            public static BlueprintAbility ShoutGreater => Resources.GetBlueprint<BlueprintAbility>("fd0d3840c48cafb44bb29e8eb74df204");
            public static BlueprintAbility SoundBurst => Resources.GetBlueprint<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
        }
    }
}
