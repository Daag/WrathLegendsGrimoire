using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LegendsGrimoire.Utilities;

namespace LegendsGrimoire.Content.Feats
{
    static class BladeDancer
    {
        public static BlueprintGuid AssetGuid = new BlueprintGuid(new System.Guid("c6398d5e497b45ef8d09cb291166af62"));

        public static void AddBladeDancer()
        {
            var bladeDancer = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BladeDancer";
                bp.SetName("Blade Dancer");
                bp.AssetGuid = AssetGuid;
                bp.SetDescription("You hit your enemies with precision and pinpoint strikes. You use your Dexterity instead "
                    + "of your Strength for damage on weapons you can finesse.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Bite;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Claw;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Dagger;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.DuelingSword;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.ElvenCurvedBlade;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Estoc;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Handaxe;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Kama;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Kukri;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.LightHammer;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.LightMace;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.LightPick;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.WeaponLightShield;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.SpikedLightShield;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Nunchaku;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.PunchingDagger;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Rapier;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Sai;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Shortsword;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Sickle;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.DuelingSword;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Starknife;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.UnarmedStrike;
                }));
            });

            Resources.AddBlueprint(bladeDancer);
            FeatUtil.AddAsFeat(bladeDancer);
        }
    }
}
