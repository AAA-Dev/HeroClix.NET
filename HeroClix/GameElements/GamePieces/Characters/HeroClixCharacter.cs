using HeroClix.GameElements;
using HeroClix.GameElements.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix
{
    /// <summary>
    /// A HeroClixCharacter.
    /// </summary>
    public abstract class HeroClixCharacter : IGamePiece
    {
        private IntellectualProperty intellectualProperty;
        private string set;
        private string collectorsNumber;
        private HeroClixRarity rarity;
        private string characterName;
        private string realName;

        /// <summary>
        /// Creates a basic HeroClixCharacter
        /// </summary>
        public HeroClixCharacter()
        {
            this.intellectualProperty = IntellectualProperty.Other;
            this.set = String.Empty;
            this.collectorsNumber = String.Empty;
            this.rarity = HeroClixRarity.Common;
            this.characterName = String.Empty;
            this.realName = String.Empty;
        }

        public HeroClixCharacter(IntellectualProperty IP, string setName, string num, HeroClixRarity rarityLevel, string charName, string name)
        {
            this.intellectualProperty = IP;
            this.set = setName;
            this.collectorsNumber = num;
            this.rarity = rarityLevel;
            this.characterName = charName;
            this.realName = name;
        }

        public IntellectualProperty GetIP()
        {
            return this.intellectualProperty;
        }

        public string GetSetName()
        {
            return this.set;
        }

        public string GetCollectorsNumber()
        {
            return this.collectorsNumber;
        }

        public HeroClixRarity GetRarity()
        {
            return this.rarity;
        }

        public string GetCharacterName()
        {
            return this.characterName;
        }

        public string GetRealName()
        {
            return this.realName;
        }
    }
}
