using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;

namespace LegendsGrimoire.Utilities
{
    static class Helpers
    {
        public static T Create<T>(Action<T> init = null) where T : new()
        {
            var result = new T();
            init?.Invoke(result);
            return result;
        }

        public static UIGroup CreateUIGroup(params BlueprintFeatureBase[] features)
        {
            UIGroup uiGroup = new UIGroup();
            features.ForEach(f => uiGroup.Features.Add(f));
            return uiGroup;
        }
    }
}
