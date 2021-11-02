using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LegendsGrimoire.Utilities;


namespace LegendsGrimoire.Content.Feats
{
    static class CrossbowExpert
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("335215c7d710400cb27e1a86db06c458"));

        public static void AddCrossbowExpert()
        {
            var crossbowExpert = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "CrossbowExpert";
                bp.SetName("Crossbow Expert");
                bp.AssetGuid = AssetGuid;
                bp.SetDescription("You can add your Dexterity modifier to damage rolls with crossbows.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.LightCrossbow;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.HeavyCrossbow;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.HandCrossbow;
                }));
            });
            Resources.AddBlueprint(crossbowExpert);
            FeatUtil.AddAsFeat(crossbowExpert);
        }
    }
}
