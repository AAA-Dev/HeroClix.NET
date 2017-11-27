using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.GameElements.GamePieces.Characters
{
    /// <summary>
    /// A single KO click belonging to a Dial.
    /// </summary>
    public class KOClick : Click
    {
        /// <summary>
        /// Creates a KO Click with the given click number.
        /// </summary>
        /// <param name="clickNumber">The click number of the KO Click.</param>
        public KOClick(int clickNumber)
        {
            this.clickNumber = clickNumber;

            this.color = Color.Red;
            this.speedValue = -1;
            this.attackValue = -1;
            this.defenseValue = -1;
            this.damageValue = -1;
            this.isStartClick = false;
        }
    }
}
