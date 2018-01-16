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

        /// <summary>
        /// Creates a default character base
        /// </summary>
        public BaseCombatInformation()
        {
            this.range = 0;
            this.numberOfTargets = 1;
        }

        /// <summary>
        /// Creates a character base with the specified property values.
        /// </summary>
        /// <param name="_range">The character's range that is printed on it's base.</param>
        /// <param name="_numberOfTargets">The number of targets the character can target when using a ranged attack.</param>
        public BaseCombatInformation(int _range, int _numberOfTargets)
        {
            this.range = _range;
            this.numberOfTargets = _numberOfTargets;
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
    }
}
