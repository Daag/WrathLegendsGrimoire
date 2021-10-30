using Kingmaker.Blueprints.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Utilities
{
    static class ItemUtil
    {
        public static class WeaponTypes
        {
            public static BlueprintWeaponType Javelin => Resources.GetBlueprint<BlueprintWeaponType>("a70cea34b275522458654beb3c53fe3f");
            public static BlueprintWeaponType ThrowingAxe => Resources.GetBlueprint<BlueprintWeaponType>("ca131c71f4fefcb48b30b5991520e01d");
        }
    }
}
