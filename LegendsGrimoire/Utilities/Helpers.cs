using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;

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

        static Dictionary<String, LocalizedString> textToLocalizedString = new Dictionary<string, LocalizedString>();
        public static LocalizedString CreateString(string key, string value)
        {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            LocalizedString localized;
            if (textToLocalizedString.TryGetValue(value, out localized))
            {
                return localized;
            }
            var strings = LocalizationManager.CurrentPack.Strings;
            strings[key] = value;
            localized = new LocalizedString
            {
                m_Key = key
            };
            textToLocalizedString[value] = localized;
            return localized;
        }
    }
}
