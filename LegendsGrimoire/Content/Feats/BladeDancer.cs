using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LegendsGrimoire.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Content.Feats
{
    static class BladeDancer
    {
        static readonly BlueprintFeature weaponFinesse = Resources.GetBlueprint<BlueprintFeature>("90e54424d682d104ab36436bd527af09");

        public static void AddBladeDancer()
        {
            var bladeDancer = Helpers.Create<BlueprintFeature>(bp =>
            {
                bp.name = "BladeDancer";
                bp.AssetGuid = new BlueprintGuid(new System.Guid("c6398d5e497b45ef8d09cb291166af62"));
                bp.SetName("Blade Dancer");
                bp.SetDescription("You hit your enemies with precision and pinpoint strikes. You use your Dexterity instead of your Strength for damage on weapons you can finesse.");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Bardiche;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Fauchard;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Glaive;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Javelin;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Longspear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Shortspear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Spear;
                    c.TwoHandedBonus = true;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeDamageStatReplacement>(c =>
                {
                    c.Stat = StatType.Dexterity;
                    c.Category = WeaponCategory.Trident;
                    c.TwoHandedBonus = true;
                }));
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
                bp.AddComponent(Helpers.Create<PrerequisiteFeature>(c =>
                {
                    c.m_Feature = weaponFinesse.ToReference<BlueprintFeatureReference>();
                    c.Group = Prerequisite.GroupType.Any;
                }));
            });

            var weaponFinessePrereq = bladeDancer.GetComponent<PrerequisiteFeature>();
            weaponFinessePrereq.Group = Prerequisite.GroupType.Any;

            Resources.AddBlueprint(bladeDancer);
            FeatUtil.AddAsFeat(bladeDancer);
        }
    }
}
