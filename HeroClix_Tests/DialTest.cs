using HeroClix;
using HeroClix.GameElements.GamePieces.Characters;
using HeroClix.Maps;
using HeroClix.Maps.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HeroClix_Tests
{
    [TestClass]
    public class DialTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A dial has been created in which there is not a Starting Click.")]
        public void Dial_ThrowsArgumentException_IfClickArrayHasNoStartingClick()
        {
            Click[] clix = new Click[6]{
                new Click(It.IsAny<Color>(), 1, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 2, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 3, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 4, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 5, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new KOClick(6)
            };

            Dial myDial = new Dial(clix);
        }

        [TestMethod]
        public void Dial_StopsTurning_WhenKOClickIsRevealed()
        {
            Click[] clix = new Click[5]{
                new Click(It.IsAny<Color>(), 1, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), true),
                new Click(It.IsAny<Color>(), 2, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new KOClick(3),
                new Click(It.IsAny<Color>(), 4, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new KOClick(5)
            };

            Dial myDial = new Dial(clix);

            Click clickAfterTurning =  myDial.TurnDialForDamage(4);

            Assert.IsTrue(clickAfterTurning.GetClickNumber() == 3, "The dialed continued turning after a KO Click was revealed.");
        }

        [TestMethod]
        public void Dial_StopsTurning_WhenStartingClickIsRevealed()
        {
            Click[] clix = new Click[5]{
                new Click(It.IsAny<Color>(), 1, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 2, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), true),
                new Click(It.IsAny<Color>(), 3, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new Click(It.IsAny<Color>(), 4, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), false),
                new KOClick(5)
            };

            Dial myDial = new Dial(clix);

            myDial.TurnDialForDamage(1);

            Click clickAfterHealing = myDial.TurnDialForHealing(2);

            Assert.IsTrue(clickAfterHealing.GetClickNumber() == 2, "The dialed continued turning after a starting click was revealed.");
        }
    }
}
