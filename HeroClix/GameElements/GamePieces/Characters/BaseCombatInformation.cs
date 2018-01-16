using HeroClix.GameElements.GamePieces.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroClix.GameElements.GamePieces.Characters
{
    /// <summary>
    /// Represents Combat information that is printed on a character's base.
    /// </summary>
    public class BaseCombatInformation : IBaseCombatInformation
    {
        private int range;
        private int numberOfTargets;
        private SpeedSymbol speedSymbol;
        private AttackSymbol attackSymbol;
        private DefenseSymbol defenseSymbol;
        private DamageSymbol damageSymbol;

        /// <summary>
        /// Creates a default character base
        /// </summary>
        public BaseCombatInformation()
        {
            this.range = 0;
            this.numberOfTargets = 1;
            this.speedSymbol = SpeedSymbol.Standard;
            this.attackSymbol = AttackSymbol.Standard;
            this.defenseSymbol = DefenseSymbol.Standard;
            this.damageSymbol = DamageSymbol.Standard;
        }

        /// <summary>
        /// Creates a character base with the specified property values.
        /// </summary>
        /// <param name="_range">The character's range that is printed on it's base.</param>
        /// <param name="_numberOfTargets">The number of targets the character can target when using a ranged attack.</param>
        public BaseCombatInformation(int _range, int _numberOfTargets, SpeedSymbol _speedSymbol, AttackSymbol _attackSymbol, DefenseSymbol _defenseSymbol, DamageSymbol _damageSymbol)
        {
            this.range = _range;
            this.numberOfTargets = _numberOfTargets;
            this.speedSymbol = _speedSymbol;
            this.attackSymbol = _attackSymbol;
            this.defenseSymbol = _defenseSymbol;
            this.damageSymbol = _damageSymbol;
        }

        /// <summary>
        /// Returns the character's range value that is printed on it's base.
        /// </summary>
        /// <returns>the character's range value that is printed on it's base.</returns>
        public int GetBaseRange()
        {
            return this.range;
        }

        /// <summary>
        /// Returns the number of targets the character can target when making a ranged attack, as printed on the character's base.
        /// </summary>
        /// <returns>The number of targets the character can target when making a ranged attack, as printed on the character's base.</returns>
        public int GetBaseNumberOfTargets()
        {
            return this.numberOfTargets;
        }

        /// <summary>
        /// Returns the Speed symbol printed on this character's base.
        /// </summary>
        /// <returns>The Speed symbol printed on this character's base.</returns>
        public SpeedSymbol GetSpeedSymbol()
        {
            return this.speedSymbol;
        }

        /// <summary>
        /// Returns the Attack symbol printed on this character's base.
        /// </summary>
        /// <returns>The Attack symbol printed on this character's base.</returns>
        public AttackSymbol GetAttackSymbol()
        {
            return this.attackSymbol;
        }

        /// <summary>
        /// Returns the Defense symbol printed on this character's base.
        /// </summary>
        /// <returns>The Defense symbol printed on this character's base.</returns>
        public DefenseSymbol GetDefenseSymbol()
        {
            return this.defenseSymbol;
        }

        /// <summary>
        /// Returns the Damage symbol printed on this character's base.
        /// </summary>
        /// <returns>The Damage symbol printed on this character's base.</returns>
        public DamageSymbol GetDamaageSymbol()
        {
            return this.damageSymbol;
        }
    }
}
