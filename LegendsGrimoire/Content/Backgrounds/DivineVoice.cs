using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Backgrounds
{
    static class DivineVoice
    {
        public readonly static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("b57d2c4621b4446cbd04288b8c4de281"));

        public static void AddDivineVoice()
        {
            var backgroundDivineVoice = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "BackgroundDivineVoice";
                bp.AssetGuid = AssetGuid;
                bp.SetName("Divine Voice");
                bp.SetDescription("The Divine Voice adds {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Perception}Perception{/g} "
                    + "to the list of her class {g|Encyclopedia:Skills}skills{/g}. "
                    + "Your wisdom allows you to influence people. You can use your {g|Encyclopedia:Wisdom}Wisdom{/g} "
                    + "instead of {g|Encyclopedia:Charisma}Charisma{/g} while attempting Persuasion {g|Encyclopedia:Check}checks{/g}.");
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
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillPersuasion;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c =>
                {
                    c.TargetStat = StatType.SkillKnowledgeArcana;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c =>
                {
                    c.TargetStat = StatType.SkillKnowledgeWorld;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                });
            });
            Resources.AddBlueprint(backgroundDivineVoice);
        }
    }
}
