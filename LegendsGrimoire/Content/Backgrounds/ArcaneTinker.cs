using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Backgrounds
{
    static class ArcaneTinker
    {
        public readonly static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("80832735fdbb4e96bc1053c8d1f9840b"));

        public static void AddArcaneTinker()
        {
            var backgroundArcaneTinker = Helpers.Create<BlueprintFeature>(bp => {
                bp.name = "BackgroundArcaneTinker";
                bp.AssetGuid = AssetGuid;
                bp.SetName("Arcane Tinker");
                bp.SetDescription("The Arcane Tinker adds {g|Encyclopedia:Use_Magic_Device}Use Magic Device{/g} and {g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g} "
                    + "to the list of her class {g|Encyclopedia:Skills}skills{/g}. You can use your {g|Encyclopedia:Intelligence}Intelligence{/g} "
                    + "instead of {g|Encyclopedia:Charisma}Charisma{/g} while attempting Use Magic Device {g|Encyclopedia:Check}checks{/g}.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { };
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
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
            });
            Resources.AddBlueprint(backgroundArcaneTinker);
        }
    }
}
