using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsGrimoire.Components
{
    [TypeId("0c067d07-c385-4676-b061-6eff9cbef45d")]
    public class BoomerDamageSubstitution : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCastSpell>, IRulebookHandler<RuleCastSpell>, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RulePrepareDamage>, IRulebookHandler<RulePrepareDamage>
    {
        public SpellDescriptor EnergyType = SpellDescriptor.Sonic;

        public void OnEventAboutToTrigger(RulePrepareDamage evt)
        {
        }

        public void OnEventAboutToTrigger(RuleCastSpell evt)
        {
        }

        public void OnEventDidTrigger(RulePrepareDamage evt)
        {
            var ability = evt.Reason.Ability;
            var blueprintAbility = ability != null ? ability.Blueprint : null;
            if (blueprintAbility == null)
            {
                var context = evt.Reason.Context;
                blueprintAbility = context != null ? context.SourceAbility : null;
            }
            if (blueprintAbility == null || !blueprintAbility.IsSpell)
            {
                return;
            }
            foreach (BaseDamage baseDamage in evt.DamageBundle)
            {
                var energyDamage = baseDamage as EnergyDamage;
                if (energyDamage != null)
                {
                    energyDamage.ReplaceEnergy(getDamageType(EnergyType));
                }
            }
        }

        public void OnEventDidTrigger(RuleCastSpell evt)
        {
            var context = evt.Context;
            context.RemoveSpellDescriptor(SpellDescriptor.Fire);
            context.RemoveSpellDescriptor(SpellDescriptor.Cold);
            context.RemoveSpellDescriptor(SpellDescriptor.Acid);
            context.RemoveSpellDescriptor(SpellDescriptor.Electricity);
            context.RemoveSpellDescriptor(SpellDescriptor.Sonic);
            context.AddSpellDescriptor(EnergyType);
        }

        private DamageEnergyType getDamageType(SpellDescriptor energyType)
        {
            switch (energyType)
            {
                case SpellDescriptor.Fire:
                    return DamageEnergyType.Fire;
                case SpellDescriptor.Acid:
                    return DamageEnergyType.Acid;
                case SpellDescriptor.Cold:
                    return DamageEnergyType.Cold;
                case SpellDescriptor.Electricity:
                    return DamageEnergyType.Electricity;
                case SpellDescriptor.Sonic:
                    return DamageEnergyType.Sonic;
                default:
                    return DamageEnergyType.Fire;
            }
        }
    }
}
