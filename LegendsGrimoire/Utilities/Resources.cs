using JetBrains.Annotations;
using Kingmaker.Blueprints;
using LegendsGrimoire.Utilities;
using System.Collections.Generic;

namespace LegendsGrimoire
{
    static class Resources
    {
        public static readonly Dictionary<BlueprintGuid, SimpleBlueprint> ModBlueprints = new Dictionary<BlueprintGuid, SimpleBlueprint>();

        public static T GetBlueprint<T>(string id) where T : SimpleBlueprint
        {
            var assetId = new BlueprintGuid(System.Guid.Parse(id));
            var asset = ResourcesLibrary.TryGetBlueprint(assetId) as T;
            if (asset == null) { Logger.Log($"COULD NOT LOAD: {id} - {typeof(T)}"); }
            return asset;
        }

        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint)
        {
            var assetId = blueprint.AssetGuid;
            var loadedBlueprint = ResourcesLibrary.TryGetBlueprint(assetId);
            if (loadedBlueprint == null)
            {
                ModBlueprints[assetId] = blueprint;
                ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, blueprint);
                blueprint.OnEnable();
                Logger.LogPatch("Added", blueprint);
            }
            else
            {
                Logger.Log($"Failed to Add: {blueprint.name}");
                Logger.Log($"Asset ID: {assetId} already in use by: {loadedBlueprint.name}");
            }
        }
    }
}
