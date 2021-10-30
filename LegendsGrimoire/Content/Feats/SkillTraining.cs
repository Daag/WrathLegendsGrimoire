using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Feats
{
    static class SkillTraining
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("93c80f6b89f0448996b747811b449602"));
        public static BlueprintGuid AthleticsAssetGuid = new BlueprintGuid(new System.Guid("a73f30db96184ed4ba9555ab020fe6ff"));
        public static BlueprintGuid KnowledgeArcanaAssetGuid = new BlueprintGuid(new System.Guid("dc801d9ba41040bcba4982894b169993"));
        public static BlueprintGuid KnowledgeWorldAssetGuid = new BlueprintGuid(new System.Guid("3b8c7d58276d4b0baa2afd6d12847eba"));
        public static BlueprintGuid LoreNatureAssetGuid = new BlueprintGuid(new System.Guid("33f09b0d655f4cb49c06e95d296068b0"));
        public static BlueprintGuid LoreReligionAssetGuid = new BlueprintGuid(new System.Guid("2d66b0609692424aaea9347bf35db6a1"));
        public static BlueprintGuid MobilityAssetGuid = new BlueprintGuid(new System.Guid("e5c231b67e504a07bae66093bb77bc69"));
        public static BlueprintGuid PerceptionAssetGuid = new BlueprintGuid(new System.Guid("a832880b6af045debccbd0c4cc8b5e42"));
        public static BlueprintGuid PersuasionAssetGuid = new BlueprintGuid(new System.Guid("0694be0964f147a8a3a721b1edc92ba2"));
        public static BlueprintGuid StealthAssetGuid = new BlueprintGuid(new System.Guid("f8b3707ede1e4834aaa1c1996c5183bf"));
        public static BlueprintGuid TrickeryAssetGuid = new BlueprintGuid(new System.Guid("c6c65dc4e5754d21a2fee904a3c9d237"));
        public static BlueprintGuid UseMagicDeviceAssetGuid = new BlueprintGuid(new System.Guid("c4bacd20aee242ba89657c24c9a07b8d"));

        public static void AddSkillTraining()
        {
            var skillTrainingAthletics = CreateSkillTrainingFeature("Athletics", AthleticsAssetGuid, StatType.SkillAthletics);
            var skillTrainingKnowledgeArcana = CreateSkillTrainingFeature("Knowledge Arcana", KnowledgeArcanaAssetGuid, StatType.SkillKnowledgeArcana);
            var skillTrainingKnowledgeWorld = CreateSkillTrainingFeature("Knowledge Arcana", KnowledgeWorldAssetGuid, StatType.SkillKnowledgeWorld);
            var skillTrainingLoreNature = CreateSkillTrainingFeature("Lore Nature", LoreNatureAssetGuid, StatType.SkillLoreNature);
            var skillTrainingLoreReligion = CreateSkillTrainingFeature("Lore Religion", LoreReligionAssetGuid, StatType.SkillLoreReligion);
            var skillTrainingMobility = CreateSkillTrainingFeature("Mobility", MobilityAssetGuid, StatType.SkillMobility);
            var skillTrainingPerception = CreateSkillTrainingFeature("Perception", PerceptionAssetGuid, StatType.SkillPerception);
            var skillTrainingPersuasion = CreateSkillTrainingFeature("Persuasion", PersuasionAssetGuid, StatType.SkillPersuasion);
            var skillTrainingStealth = CreateSkillTrainingFeature("Stealth", StealthAssetGuid, StatType.SkillStealth);
            var skillTrainingTrickery = CreateSkillTrainingFeature("Trickery", TrickeryAssetGuid, StatType.SkillThievery);
            var skillTrainingUseMagicDevice = CreateSkillTrainingFeature("Use Magic Device", UseMagicDeviceAssetGuid, StatType.SkillUseMagicDevice);

            var skillTraining = Helpers.Create<BlueprintFeatureSelection>(bp =>
            {
                bp.name = "SkillTrainingFeature";
                bp.AssetGuid = AssetGuid;
                bp.SetName("Skill Training");
                bp.SetDescription("You become trained in the skill of your choice.");
                bp.m_AllFeatures = new BlueprintFeatureReference[]
                {
                    skillTrainingAthletics.ToReference<BlueprintFeatureReference>(),
                    skillTrainingKnowledgeArcana.ToReference<BlueprintFeatureReference>(),
                    skillTrainingKnowledgeWorld.ToReference<BlueprintFeatureReference>(),
                    skillTrainingLoreNature.ToReference<BlueprintFeatureReference>(),
                    skillTrainingLoreReligion.ToReference<BlueprintFeatureReference>(),
                    skillTrainingMobility.ToReference<BlueprintFeatureReference>(),
                    skillTrainingPerception.ToReference<BlueprintFeatureReference>(),
                    skillTrainingPersuasion.ToReference<BlueprintFeatureReference>(),
                    skillTrainingStealth.ToReference<BlueprintFeatureReference>(),
                    skillTrainingTrickery.ToReference<BlueprintFeatureReference>(),
                    skillTrainingUseMagicDevice.ToReference<BlueprintFeatureReference>()
                };
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Mode = SelectionMode.OnlyNew;
                bp.AddComponent(Helpers.Create<PrerequisiteStatValue>(c =>
                {
                    c.Stat = StatType.Intelligence;
                    c.Value = 12;
                }));
            });
            Resources.AddBlueprint(skillTraining);
            FeatUtil.AddAsFeat(skillTraining);
        }

        static BlueprintFeature CreateSkillTrainingFeature(string desc, BlueprintGuid assetGuid, StatType skill)
        {
            var skillTrainingFeature = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = $"SkillTraining{desc}";
                bp.AssetGuid = assetGuid;
                bp.SetName(desc);
                bp.SetDescription($"You gain training in the {{g|Encyclopedia:{desc.Replace(' ', '_')}}}{desc}{{/g}} skill.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { };
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = skill;
                });
            });
            Resources.AddBlueprint(skillTrainingFeature);
            return skillTrainingFeature;
        }
    }
}
