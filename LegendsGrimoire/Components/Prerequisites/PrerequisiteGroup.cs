using JetBrains.Annotations;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System.Collections.Generic;
using System.Text;

namespace LegendsGrimoire.Components.Prerequisites
{
    [TypeId("81f49717bb1344c9af0485c002c7e9ec")]
    class PrerequisiteGroup : Prerequisite
    {
        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            return Prerequisites.TrueForAll(p => p.Check(selectionState, unit, state));
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Prerequisites.Count; i++)
            {
                stringBuilder.Append(Prerequisites[i].GetUIText(unit));
                if (i < Prerequisites.Count - 1)
                {
                    stringBuilder.Append("\n");
                }
            }

            return stringBuilder.ToString();
        }

        public List<Prerequisite> Prerequisites = new List<Prerequisite>();
    }
}
