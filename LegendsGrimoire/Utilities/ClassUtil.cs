using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Utilities
{
    static class ClassUtil
    {
        public static class Classes
        {
            public static BlueprintCharacterClass Arcanist => Resources.GetBlueprint<BlueprintCharacterClass>("52dbfd8505e22f84fad8d702611f60b7");
            public static BlueprintCharacterClass Barbarian => Resources.GetBlueprint<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
        }
    }
}
