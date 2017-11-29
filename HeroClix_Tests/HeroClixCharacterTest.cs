using HeroClix;
using HeroClix.GameElements.GamePieces.Characters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HeroClix_Tests
{
    [TestClass]
    public class HeroClixCharacterTest
    {
        [TestMethod]
        public void HeroClixCharacter_AddToken_NewToken()
        {
            var myCharacter = new StandardHeroClixCharacter();

            Assert.IsTrue(myCharacter.GetTokens().Count == 0, "A standard character was created with a non-empty Token List.");
            myCharacter.AddToken("Rage", 2, myCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Count == 1, "Tokens were not added to the character.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "Tokens were not added to the character correctly.");

            var myOtherCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("Rage", myOtherCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Count == 2, "Tokens were not added to the character.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "Tokens were not added to the character correctly.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myOtherCharacter)).Quantity == 1, "Tokens were not added to the character correctly.");
        }

        [TestMethod]
        public void HeroClixCharacter_AddToken_ExistingToken()
        {
            var myCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("Rage", myCharacter);
            myCharacter.AddToken("Rage", myCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Count == 1, "An additional Token object was added when not necessary.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "Tokens were not added to the character correctly.");

            var myOtherCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("Rage", myOtherCharacter);
            myCharacter.AddToken("Rage", myOtherCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Count == 2, "An additional Token object was not added when necessary.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "The wrong Token Quantities were updated.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myOtherCharacter)).Quantity == 2, "Tokens were not added to the character correctly.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_ExistingToken()
        {
            var myCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("BombShell", 3, myCharacter);
            myCharacter.RemoveToken("BombShell", 2, myCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("BombShell") && t.TokenDesignator.Equals(myCharacter)).Quantity == 1, "Tokens were not removed from the character correctly.");

            myCharacter.RemoveToken("BombShell", myCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Count == 0, "Token object should be removed if its Quantity is 0.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_ExistingToken_AssignedByADifferentCharacter_Succeeds()
        {
            var character1 = new StandardHeroClixCharacter();
            var character2 = new StandardHeroClixCharacter();

            character1.AddToken("Marked", 2, character1);
            character1.AddToken("Marked", 2, character2);

            character1.RemoveToken("Marked", character2);
            Assert.IsTrue(character1.GetTokens().Find(t => t.Name.Equals("Marked") && t.TokenDesignator.Equals(character1)).Quantity == 2, "Tokens assigned by a different character were removed.");
            Assert.IsTrue(character1.GetTokens().Find(t => t.Name.Equals("Marked") && t.TokenDesignator.Equals(character2)).Quantity == 1, "Token was not removed successfully.");

            character1.RemoveToken("Marked", character2);
            Assert.IsTrue(character1.GetTokens().Count == 1, "Token object should be removed if its Quantity is 0.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_ExistingToken_AssignedByADifferentCharacter_Fails()
        {
            var character1 = new StandardHeroClixCharacter();
            var character2 = new StandardHeroClixCharacter();

            character1.AddToken("Marked", 2, character1);

            character1.RemoveToken("Marked", character2);
            Assert.IsTrue(character1.GetTokens().Find(t => t.Name.Equals("Marked") && t.TokenDesignator.Equals(character1)).Quantity == 2, "Tokens were removed when they should not have been.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_TokenThatDoesNotExist()
        {
            var myCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("BombShell", 2, myCharacter);
            myCharacter.RemoveToken("Rage", myCharacter);
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("BombShell") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "The wrong tokens were removed from the character.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_AllTokens_WithAGivenName()
        {
            var myCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("BombShell", 2, myCharacter);
            myCharacter.AddToken("Rage", 4, myCharacter);
            myCharacter.AddToken("Asgardian Favor", 1, myCharacter);
            int numberOfTokensRemoved = myCharacter.RemoveAllTokens("Rage", myCharacter);

            Assert.IsTrue(numberOfTokensRemoved == 4, "An incorrect number of tokens were removed.");
            Assert.IsTrue(myCharacter.GetTokens().Count == 2, "Token was not removed from the list.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("BombShell") && t.TokenDesignator.Equals(myCharacter)).Quantity == 2, "The wrong tokens were removed from the character.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Asgardian Favor") && t.TokenDesignator.Equals(myCharacter)).Quantity == 1, "The wrong tokens were removed from the character.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Rage") && t.TokenDesignator.Equals(myCharacter)) == null, "Tokens were not removed completely.");
        }

        [TestMethod]
        public void HeroClixCharacter_RemoveToken_AllTokens_WithAGivenName_AssignedByAGivenCharacter()
        {
            var myCharacter = new StandardHeroClixCharacter();
            var myOtherCharacter = new StandardHeroClixCharacter();

            myCharacter.AddToken("Marked", 5, myCharacter);
            myCharacter.AddToken("Marked", 3, myOtherCharacter);
            int numberOfTokensRemoved = myCharacter.RemoveAllTokens("Marked", myOtherCharacter);

            Assert.IsTrue(numberOfTokensRemoved == 3, "An incorrect number of tokens were removed.");
            Assert.IsTrue(myCharacter.GetTokens().Count == 1, "Token was not removed from the list.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Marked") && t.TokenDesignator.Equals(myCharacter)).Quantity == 5, "The wrong tokens were removed from the character.");
            Assert.IsTrue(myCharacter.GetTokens().Find(t => t.Name.Equals("Marked") && t.TokenDesignator.Equals(myOtherCharacter)) == null, "Tokens were not removed completely.");
        }
    }
}
