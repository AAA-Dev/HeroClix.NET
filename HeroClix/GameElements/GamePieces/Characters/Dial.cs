using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.GameElements.GamePieces.Characters
{
    /// <summary>
    ///  A Dial that belongs to a GamePiece
    /// </summary>
    public class Dial : IDial
    {
        private Click[] dial;
        private int currentClickIndex = -1;

        /// <summary>
        /// Creates a Default Dial.
        /// </summary>
        public Dial()
        {
            this.dial = new Click[12];
            this.dial[0] = new Click(Color.Red, 1, 0, 0, 0, 0, true);
            for (int i = 1; i < this.dial.Length; i++)
            {
                this.dial[i] = new KOClick(i);
            }
            currentClickIndex = 0;
        }

        /// <summary>
        /// Creates a Dial with the specified Click Array.
        /// </summary>
        /// <param name="clickArray">The Dial.</param>
        /// <exception cref="ArgumentException">Thrown if the <cref="Click">[] provided does not include atleast one Click that has the flag isStartingClick set to 'true'.</exception>
        public Dial(Click[] clickArray)
        {
            this.dial = clickArray;

            for (int i = 0; i < this.dial.Length; i++)
            {
                if (this.dial[i].IsStartingClick())
                {
                    this.currentClickIndex = i;
                    break;
                }
            }

            if (this.currentClickIndex == -1)
            {
                throw new ArgumentException("clickArray", "No starting click exists in the Dial that was provided.");
            }
        }

        /// <summary>
        /// Increases the currentClickIndex a number of times.
        /// </summary>
        /// <param name="numberOfTimes">The number of times to increase the index by 1.</param>
        /// <returns>The resulting <cref="Click">.</returns>
        public Click TurnDialForDamage(int numberOfTimes)
        {
            int count = numberOfTimes;
            while (count > 0)
            {
                this.currentClickIndex++;

                // Stop turning the dial if a KO Click is revealed.
                if (CurrentClick().GetType().Equals(typeof(KOClick)))
                {
                    count = 1;
                }
                // TODO: Check for STOP clicks
                count--;
            }
            return CurrentClick();
        }

        /// <summary>
        /// Decreases the currentClickIndex a number of times.
        /// </summary>
        /// <param name="numberOfTimes">The number of times to decrease the index by 1.</param>
        /// <returns>The resulting <cref="Click">.</returns>
        public Click TurnDialForHealing(int numberOfTimes)
        {
            int count = numberOfTimes;
            while (count > 0)
            {
                this.currentClickIndex--;

                // Don't heal past the starting click.
                if (CurrentClick().IsStartingClick())
                {
                    count = 1;
                }
                count--;
            }
            return CurrentClick();
        }

        /// <summary>
        /// Returns the current <cref="Click"> showing on the Dial.
        /// </summary>
        /// <returns>The current <cref="Click"> showing on the Dial.</returns>
        public Click CurrentClick()
        {
            return this.dial[this.currentClickIndex];
        }
    }
}
