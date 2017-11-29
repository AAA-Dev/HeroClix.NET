using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.GameElements.GamePieces.Characters
{
    /// <summary>
    /// A Token that can be added to a HeroClixCharacter.
    /// </summary>
    public class Token
    {
        private string tokenName;
        private IGamePiece tokenDesignator;

        /// <summary>
        /// Creates a default Token
        /// </summary>
        public Token()
        {
            this.tokenName = "Default";
            Quantity = 1;
            this.tokenDesignator = new StandardHeroClixCharacter();
        }

        /// <summary>
        /// Creates a Token with the specified name, quantity, and designator.
        /// </summary>
        /// <param name="_tokenName">The specified name.</param>
        /// <param name="_quantity">The specified quantity.</param>
        /// <param name="_tokenDesignator">The specified designator.</param>
        public Token(string _tokenName, int _quantity, IGamePiece _tokenDesignator)
        {
            this.tokenName = _tokenName;
            Quantity = _quantity;
            this.tokenDesignator = _tokenDesignator;
        }

        /// <summary>
        /// Creates a Single Token with a designator
        /// </summary>
        /// <param name="_tokenName">The specified name.</param>
        /// <param name="_tokenDesignator">The specified designator.</param>
        public Token(string _tokenName, IGamePiece _tokenDesignator)
        {
            this.tokenName = _tokenName;
            Quantity = 1;
            this.tokenDesignator = _tokenDesignator;
        }

        /// <summary>
        /// Returns the name of the Token.
        /// </summary>
        public string Name
        {
            get
            {
                return this.tokenName;
            }
        }

        /// <summary>
        /// Gets or Sets the Quantity value of the Token.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Returns the Game Piece that orginally assigned the Token.
        /// </summary>
        public IGamePiece TokenDesignator
        {
            get
            {
                return this.tokenDesignator;
            }
        }
    }
}
