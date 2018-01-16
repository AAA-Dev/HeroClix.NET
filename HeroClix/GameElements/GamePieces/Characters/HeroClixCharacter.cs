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
        private int pointValue;
        private BaseCombatInformation baseCombatInformation;
        private Dial dial;
        private List<Token> tokens;

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
            this.pointValue = 0;
            this.baseCombatInformation = new BaseCombatInformation();
            this.dial = new Dial();
            this.tokens = new List<Token>();
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
        /// <param name="points">The character's point value.</param>
        /// <param name="characterBase">The character's base information.</param>
        /// <param name="characterDial">The character's dial information.</param>
        public HeroClixCharacter(IntellectualProperty IP, string setName, string num, HeroClixRarity rarityLevel, List<NamedKeyword> namedKeywords, List<GenericKeyword> genericKeywords, string charName, string name, int points, BaseCombatInformation characterBase, Dial characterDial)
        {
            this.intellectualProperty = IP;
            this.set = setName;
            this.collectorsNumber = num;
            this.rarity = rarityLevel;
            this.namedKeywords = namedKeywords;
            this.genericKeywords = genericKeywords;
            this.characterName = charName;
            this.realName = name;
            this.pointValue = points;
            this.baseCombatInformation = characterBase;
            this.dial = characterDial;
            this.tokens = new List<Token>();
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
        /// Returns the character's point value.
        /// </summary>
        /// <returns>The character's point value.</returns>
        public virtual int GetPointValue()
        {
            return this.pointValue;
        }

        /// <summary>
        /// Returns the character's combat information that is printed on it's base.
        /// </summary>
        /// <returns>The character's combat information that is printed on it's base.</returns>
        public BaseCombatInformation GetBaseCombatInformation()
        {
            return this.baseCombatInformation;
        }

        /// <summary>
        /// Returns the character's dial.
        /// </summary>
        /// <returns>The character's dial.</returns>
        public Dial GetDial()
        {
            return this.dial;
        }

        /// <summary>
        /// Returns a <cref=List> of tokens that are currently on the character.
        /// </summary>
        /// <returns>A <cref=List> of tokens that are currently on the character.</returns>
        public List<Token> GetTokens()
        {
            return this.tokens;
        }

        /// <summary>
        /// Adds a <cref=Token> to a character.
        /// </summary>
        /// <param name="tokenName">The type of <cref=Token> to add.</param>
        /// <param name="quantity">The quantity to add.</param>
        /// <param name="designator">The GamePiece assigning the token to the character.</param>
        public void AddToken(string tokenName, int quantity, IGamePiece designator)
        {
            if (!this.tokens.Any() || this.tokens.FirstOrDefault(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator)) == null)
            {
                this.tokens.Add(new Token(tokenName, quantity, designator));
            }
            else{
                var token = this.tokens.FirstOrDefault(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator));
                token.Quantity += quantity;
            }
        }

        /// <summary>
        /// Adds a single <cref=Token> to a character.
        /// </summary>
        /// <param name="tokenName">The type of <cref=Token> to add.</param>
        /// <param name="designator">The GamePiece assigning the token to the character.</param>
        public void AddToken(string tokenName, IGamePiece designator)
        {
            AddToken(tokenName, 1, designator);
        }

        /// <summary>
        /// Removes a number of named Tokens from a character.
        /// </summary>
        /// <param name="tokenName">The name of the <cref=Token> to remove.</param>
        /// <param name="quantity">The quantity to remove.</param>
        /// <param name="designator">The GamePiece that originally assigned the token to the character.</param>
        /// <returns>True is the remove action was successful, False otherwise.</returns>
        public bool RemoveToken(string tokenName, int quantity, IGamePiece designator)
        {
            bool tokenWasRemoved = false;

            if (this.tokens.FirstOrDefault(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator)) != null)
            {
                var token = this.tokens.FirstOrDefault(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator));
                token.Quantity -= quantity;
                tokenWasRemoved = true;

                if (token.Quantity <= 0)
                {
                    return this.tokens.Remove(token);
                }
            }
            
            return tokenWasRemoved;
        }

        /// <summary>
        /// Removes a single named Token from a character.
        /// </summary>
        /// <param name="tokenName">The name of the <cref=Token> to remove.</param>
        /// <param name="designator">The GamePiece that originally assigned the token to the character.</param>
        /// <returns>True is the remove action was successful, False otherwise.</returns>
        public bool RemoveToken(string tokenName, IGamePiece designator)
        {
            return RemoveToken(tokenName, 1, designator);
        }

        /// <summary>
        /// Removes all Tokens with the specified name from the character.
        /// </summary>
        /// <param name="tokenName">The name of the <cref=Token> to remove.</param>
        /// <param name="designator">The GamePiece that originally assigned the token to the character.</param>
        /// <returns>The quantity removed.</returns>
        public int RemoveAllTokens(string tokenName, IGamePiece designator)
        {
            int numberRemoved = 0;
            var token = this.tokens.FirstOrDefault(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator));
            if (token != null)
            {
                numberRemoved = token.Quantity;
            }

            this.tokens.RemoveAll(t => t.Name.Equals(tokenName) && t.TokenDesignator.Equals(designator));
            return numberRemoved;
        }
    }
}
