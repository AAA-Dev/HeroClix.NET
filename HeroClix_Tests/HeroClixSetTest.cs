using HeroClix;
using HeroClix.Common;
using HeroClix.GameElements.GamePieces.Characters;
using HeroClix.Maps;
using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeroClix_Tests
{
    [TestClass]
    public class HeroClixSetTest
    {
        HeroClixSet testSet;

        [TestInitialize]
        public void Initialize()
        {
            IGameElement[] testElements = new IGameElement[]{
                new IndoorMap(),
                new OutdoorMap(),
                new IndoorOutdoorMap(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new StandardHeroClixCharacter(),
                new SpecialHeroClixObject(),
                new SpecialHeroClixObject(),
                new SpecialHeroClixObject(),
                new SpecialHeroClixObject(),
                new SpecialHeroClixObject()
            };

            testSet = new HeroClixSet("TestSet", DateTime.Now, HeroClixAge.Modern, new Bitmap(32, 32), testElements);
        }

        [TestMethod]
        public void HeroClixSet_AllElements_Returns_CorrectNumberOfElements()
        {
            Assert.IsTrue(testSet.AllElements().Length == 18, "HeroClixSet.AllElements() did not return a list containing all elements in the set.");
        }

        [TestMethod]
        public void HeroClixSet_Maps_Returns_CorrectNumberOfMaps()
        {
            Assert.IsTrue(testSet.Maps().Length == 3, "HeroClixSet.Maps() did not return a list containing all Maps in the set.");
        }

        [TestMethod]
        public void HeroClixSet_Characters_Returns_CorrectNumberOfCharacters()
        {
            Assert.IsTrue(testSet.Characters().Length == 10, "HeroClixSet.Characters() did not return a list containing all characters in the set.");
        }

        [TestMethod]
        public void HeroClixSet_Objects_Returns_CorrectNumberOfObjects()
        {
            Assert.IsTrue(testSet.Objects().Length == 5, "HeroClixSet.Objects() did not return a list containing all objects in the set.");
        }
    }
}
