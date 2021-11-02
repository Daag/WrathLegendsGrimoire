using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Backgrounds
{
    static class CunningTinker
    {
        public readonly static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("ab6e180c090c47c0b8f85e9d82e30d95"));

        public static void AddCunningTinker()
        {
            var backgroundCunningDiplomat = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "BackgroundCunningTinker";
                bp.AssetGuid = AssetGuid;
                bp.SetName("Cunning Tinker");
                bp.SetDescription("The Cunning Tinker adds {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Use_Magic_Device}Use Magic Device{/g} "
                    + "to the list of her class {g|Encyclopedia:Skills}skills{/g}. "
                    + "Your intellect allows you to influence people and magic. You can use your {g|Encyclopedia:Intelligence}Intelligence{/g} "
                    + "instead of {g|Encyclopedia:Charisma}Charisma{/g} while attempting Persuasion {g|Encyclopedia:Check}checks{/g} and {g|Encyclopedia:Use_Magic_Device}Use Magic Device{/g}.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { };
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillUseMagicDevice;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillUseMagicDevice;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillUseMagicDevice;
                    c.BaseAttributeReplacement = StatType.Intelligence;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillPersuasion;
                    c.BaseAttributeReplacement = StatType.Intelligence;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
            });
            Resources.AddBlueprint(backgroundCunningDiplomat);
        }
    }
}
