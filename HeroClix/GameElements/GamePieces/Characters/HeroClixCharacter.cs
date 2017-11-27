using HeroClix.GameElements;
using HeroClix.GameElements.Enums;
using HeroClix.GameElements.GamePieces.Characters;
using HeroClix.GameElements.GamePieces.Characters.Enums;
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
        private List<NamedKeyword> namedKeywords;
        private List<GenericKeyword> genericKeywords;
        private string characterName;
        private string realName;
        private Dial dial;

        /// <summary>
        /// Creates a basic HeroClixCharacter.
        /// </summary>
        public HeroClixCharacter()
        {
            this.intellectualProperty = IntellectualProperty.Other;
            this.set = String.Empty;
            this.collectorsNumber = String.Empty;
            this.rarity = HeroClixRarity.Common;
            this.namedKeywords = new List<NamedKeyword>();
            this.genericKeywords = new List<GenericKeyword>();
            this.characterName = String.Empty;
            this.realName = String.Empty;
            this.dial = new Dial();
        }

        /// <summary>
        /// Creates a HeroClixCharacter with the specified properties.
        /// </summary>
        /// <param name="IP">The Intellectual Property the character belongs to.</param>
        /// <param name="setName">The name of the set the character belongs to.</param>
        /// <param name="num">The collector's number of character within the set the character belongs to.</param>
        /// <param name="rarityLevel">The rarity level of the character.</param>
        /// <param name="namedKeywords">The character's named keywords.</param>
        /// <param name="genericKeywords">The character's generic keywords.</param>
        /// <param name="charName">The character's name.</param>
        /// <param name="name">The character's real name.</param>
        /// <param name="characterDial">The character's real name.</param>
        public HeroClixCharacter(IntellectualProperty IP, string setName, string num, HeroClixRarity rarityLevel, List<NamedKeyword> namedKeywords, List<GenericKeyword> genericKeywords, string charName, string name, Dial characterDial)
        {
            this.intellectualProperty = IP;
            this.set = setName;
            this.collectorsNumber = num;
            this.rarity = rarityLevel;
            this.namedKeywords = namedKeywords;
            this.genericKeywords = genericKeywords;
            this.characterName = charName;
            this.realName = name;
            this.dial = characterDial;
        }

        /// <summary>
        /// Returns the Intellectual Property that the character belongs to.
        /// </summary>
        /// <returns>The Intellectual Property that the character belongs to.</returns>
        public IntellectualProperty GetIP()
        {
            return this.intellectualProperty;
        }

        /// <summary>
        /// Returns the name of the set that the character belongs to.
        /// </summary>
        /// <returns>The name of the set that the character belongs to.</returns>
        public string GetSetName()
        {
            return this.set;
        }

        /// <summary>
        /// Returns the collector's number of the character for the set the character belongs to.
        /// </summary>
        /// <returns>The collector's number of the character for the set the character belongs to.</returns>
        public string GetCollectorsNumber()
        {
            return this.collectorsNumber;
        }

        /// <summary>
        /// Returns the rarity level of the character.
        /// </summary>
        /// <returns>The rarity level of the character.</returns>
        public HeroClixRarity GetRarity()
        {
            return this.rarity;
        }

        /// <summary>
        /// Returns the character's named keywords.
        /// </summary>
        /// <returns>the character's named keywords.</returns>
        public List<NamedKeyword> GetNamedKeywords()
        {
            return this.namedKeywords;
        }

        /// <summary>
        /// Returns the character's generic keywords.
        /// </summary>
        /// <returns>the character's generic keywords.</returns>
        public List<GenericKeyword> GetGenericKeywords()
        {
            return this.genericKeywords;
        }

        /// <summary>
        /// Returns the character's name.
        /// </summary>
        /// <returns>The character's name.</returns>
        public string GetCharacterName()
        {
            return this.characterName;
        }

        /// <summary>
        /// Returns the character's real name.
        /// </summary>
        /// <returns>The character's real name.</returns>
        public string GetRealName()
        {
            return this.realName;
        }

        /// <summary>
        /// Returns the character's dial.
        /// </summary>
        /// <returns>The character's dial.</returns>
        public Dial GetDial()
        {
            return this.dial;
        }
    }
}
