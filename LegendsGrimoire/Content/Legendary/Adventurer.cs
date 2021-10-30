using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LegendsGrimoire.Utilities;
using System.Linq;

namespace LegendsGrimoire.Content.Legendary
{
    static class Adventurer
    {
        static readonly BlueprintProgression basicFeatProgression = Resources.GetBlueprint<BlueprintProgression>("5b72dd2ca2cb73b49903806ee8986325");

        public static void AddLegendaryAdventurer()
        {
            var basicFeatsProgressionFeatures = basicFeatProgression.LevelEntries.Where(e => e.Level == 1).FirstOrDefault().m_Features;
            var basicFeatSelection = FeatUtil.Selections.BasicFeatSelection;
            var backgroundCunningDiplomat = Resources.ModBlueprints[Backgrounds.CunningDiplomat.AssetGuid] as BlueprintFeature;
            var backgroundDivineVoice = Resources.ModBlueprints[Backgrounds.DivineVoice.AssetGuid] as BlueprintFeature;
            var backgroundFeyTouched = Resources.ModBlueprints[Backgrounds.FeyTouched.AssetGuid] as BlueprintFeature;
            var backgroundArcaneTinker = Resources.ModBlueprints[Backgrounds.ArcaneTinker.AssetGuid] as BlueprintFeature;
            var skillTraining = Resources.ModBlueprints[Feats.SkillTraining.AssetGuid] as BlueprintFeatureSelection;

            var mainCharacterBackgroundSelection = Helpers.Create<BlueprintFeatureSelection>(bp => {
                bp.name = "MainCharacterBackgroundSelection";
                bp.AssetGuid = new BlueprintGuid(new System.Guid("4590fc2a55a44294aaee460f1d921667"));
                bp.SetName("Campaign Background");
                bp.SetDescription("Choose the option that will help in your journey.");
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    backgroundCunningDiplomat.ToReference<BlueprintFeatureReference>(),
                    backgroundDivineVoice.ToReference<BlueprintFeatureReference>(),
                    backgroundFeyTouched.ToReference<BlueprintFeatureReference>(),
                    backgroundArcaneTinker.ToReference<BlueprintFeatureReference>()
                };
                bp.Mode = SelectionMode.OnlyNew;
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };
                bp.IsClassFeature = true;
                bp.Ranks = 1;
            });
            Resources.AddBlueprint(mainCharacterBackgroundSelection);

            var mainCharacterProgression = Helpers.Create<BlueprintProgression>(bp => {
                bp.name = "MainCharacterProgression";
                bp.AssetGuid = new BlueprintGuid(new System.Guid("30f7b8080c3143d3ae35a556f966f263"));
                bp.SetName("Main Character");
                bp.SetDescription("Your destiny sets you apart. You are the main character of your story.");
                bp.Groups = new FeatureGroup[] { FeatureGroup.None };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.GiveFeaturesForPreviousLevels = true;
                bp.HideInUI = false;
                bp.LevelEntries = new LevelEntry[] {
                    new LevelEntry(){ Level = 1, Features = { mainCharacterBackgroundSelection, basicFeatSelection, skillTraining }},
                    new LevelEntry(){ Level = 2, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 4, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 6, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 8, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 10, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 12, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 14, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 16, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 18, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 20, Features = { basicFeatSelection }}
                };
            });
            Resources.AddBlueprint(mainCharacterProgression);

            var companionCharacterProgression = Helpers.Create<BlueprintProgression>(bp => {
                bp.name = "CompanionCharacterProgression";
                bp.AssetGuid = new BlueprintGuid(new System.Guid("7d9485aae43445e0b4db41b62383a7e2"));
                bp.SetName("Companion");
                bp.SetDescription("You've seen something in your leader, and you were destined to follow.");
                bp.Groups = new FeatureGroup[] { FeatureGroup.None };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.GiveFeaturesForPreviousLevels = true;
                bp.HideInUI = false;
                bp.LevelEntries = new LevelEntry[] {
                    new LevelEntry(){ Level = 1, Features = { basicFeatSelection }},
                    new LevelEntry(){ Level = 2, Features = { basicFeatSelection }}
                };
            });
            Resources.AddBlueprint(companionCharacterProgression);

            var legendaryAdventurerSelection = Helpers.Create<BlueprintFeatureSelection>(bp => {
                bp.name = "LegendaryAdventurerSelection";
                bp.SetName("Legendary Adenturer");
                bp.SetDescription("Are you the main character of your story? Choose wisely.");
                bp.AssetGuid = new BlueprintGuid(new System.Guid("8fcf3946270a44169780546f2b79d5fe"));
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    mainCharacterProgression.ToReference<BlueprintFeatureReference>(),
                    companionCharacterProgression.ToReference<BlueprintFeatureReference>()
                };
                bp.Mode = SelectionMode.OnlyNew;
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };
                bp.IsClassFeature = true;
                bp.Ranks = 1;
            });
            Resources.AddBlueprint(legendaryAdventurerSelection);

            basicFeatsProgressionFeatures.Add(legendaryAdventurerSelection.ToReference<BlueprintFeatureBaseReference>());
        }

    }
}
