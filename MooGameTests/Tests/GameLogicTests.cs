using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Components;
using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.Tests
{
    [TestClass()]
    public class GameLogicTests
    {
       
        // This TestMethod is to ensure that it returns the expected value.
        [TestMethod()]
        public void QuitOrPlayGame_ReturnsExpectedValue()
        {
            // Arrange
            
            var expected = true;
            var input = "q\n";
            var output = new StringWriter();
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);

            // Act
            var result = MooGameLogic.QuitOrPlayGame();

            // Assert
            Assert.AreEqual(expected, result);
        }


        // This TestMethod checks that the CheckBullOrCow method returns the correct result when the goal and guess strings are different.
        [TestMethod()]
        public void TestCheckBullOrCow_DifferentStrings()
        {
            // Arrange
            ISaveGame saveGame = new MooSaveGame();
            MooGameLogic game = new(saveGame);
            string goal = "1234";
            string guess = "4321";

            // Act
            string result = game.CheckBullOrCow(goal, guess);

            // Assert
            Assert.AreEqual("Result: [] , [CCCC]", result); // The spaces needs to be equal to the method.

        }


        // This TestMethod ensures that the method returns a four-digit number string with unique digits
        [TestMethod]
        public void TestCreateGuessNumber_UniqueDigits()
        {
            // Act
            var result = MooGameLogic.GenerateGuessNumber();

            // Assert
            Assert.AreEqual(4, result.Length);
            Assert.IsTrue(result.Distinct().Count() == 4);
        }
    }
}


