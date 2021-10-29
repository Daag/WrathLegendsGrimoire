using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Backgrounds
{
    static class FeyTouched
    {
        public readonly static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("191ceb62373c4a3a90ccaf3ce719ece6"));

        public static void AddFeyTouched()
        {
            var backgroundFeyTouched = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "BackgroundFeyTouched";
                bp.AssetGuid = AssetGuid;
                bp.SetName("Fey Touched");
                bp.SetDescription("The Fey Touched adds {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Perception}Perception{/g} "
                    + "to the list of her class {g|Encyclopedia:Skills}skills{/g}.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { };
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
            });
            Resources.AddBlueprint(backgroundFeyTouched);
        }
    }
}
