using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.GameElements.GamePieces.Characters
{
    /// <summary>
    /// A single click belonging to a Dial.
    /// </summary>
    public class Click : IClick
    {
        protected Color color;
        protected int clickNumber;
        protected int speedValue;
        protected int attackValue;
        protected int defenseValue;
        protected int damageValue;
        protected bool isStartClick;

        /// <summary>
        /// Creates a default Click.
        /// </summary>
        public Click()
        {
            this.color = Color.Red;
            this.clickNumber = 1;
            this.speedValue = 8;
            this.attackValue = 9;
            this.defenseValue = 16;
            this.damageValue = 1;
            this.isStartClick = false;
        }

        /// <summary>
        /// Creates a single Click with the specifies property values.
        /// </summary>
        /// <param name="clickColor">The Color of the Click.</param>
        /// <param name="clickNumber">The click number.</param>
        /// <param name="speed">The speed value.</param>
        /// <param name="attack">The attack value.</param>
        /// <param name="defense">The defense value.</param>
        /// <param name="damage">The damage value.</param>
        /// <param name="startClick">Whether the character starts on this click or not.</param>
        public Click(Color clickColor, int clickNumber, int speed, int attack, int defense, int damage, bool startClick)
        {
            this.color = clickColor;
            this.clickNumber = clickNumber;
            this.speedValue = speed;
            this.attackValue = attack;
            this.defenseValue = defense;
            this.damageValue = damage;
            this.isStartClick = startClick;
        }

        /// <summary>
        /// Returns the Click Number's color.
        /// </summary>
        /// <returns>The Click Number's color.</returns>
        public Color GetClickColor()
        {
            return this.color;
        }

        /// <summary>
        /// Returns the Click number of the Click.
        /// </summary>
        /// <returns>The Click number of the Click.</returns>
        public int GetClickNumber()
        {
            return this.clickNumber;
        }

        /// <summary>
        /// Returns the speed value for the Click.
        /// </summary>
        /// <returns>The speed value for the Click.</returns>
        public int GetSpeedValue()
        {
            return this.speedValue;
        }

        /// <summary>
        /// Retuns the attack value for the Click.
        /// </summary>
        /// <returns>The attack value for the Click.</returns>
        public int GetAttackValue()
        {
            return this.attackValue;
        }

        /// <summary>
        /// Returns the defense value for the Click.
        /// </summary>
        /// <returns>The defense value for the Click.</returns>
        public int GetDefenseValue()
        {
            return this.defenseValue;
        }

        /// <summary>
        /// Returns the damage value for the Click.
        /// </summary>
        /// <returns>The damage value for the Click.</returns>
        public int GetDamageValue()
        {
            return this.damageValue;
        }

        /// <summary>
        /// Returns whether this click is a starting click or not.
        /// </summary>
        /// <returns>True if this click is a starting click, false otherwise.</returns>
        public bool IsStartingClick()
        {
            return this.isStartClick;
        }
    }
}
