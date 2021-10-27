using JetBrains.Annotations;
using Kingmaker.Blueprints.JsonSystem;
using UnityModManagerNet;

namespace Legends.Utilities
{
    static class Logger
    {
        public static UnityModManager.ModEntry ModEntry;

        public static void Log(string msg)
        {
            ModEntry.Logger.Log(msg);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg)
        {
            ModEntry.Logger.Log(msg);
        }

        public static void LogPatch(string action, [NotNull] IScriptableObjectWithAssetId bp)
        {
            Log($"{action}: {bp.AssetGuid} - {bp.name}");
        }

        public static void LogHeader(string msg)
        {
            Log($"--{msg.ToUpper()}--");
        }
    }
}
