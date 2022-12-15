using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Tests
{
    [TestClass()]
    public class GameLogicTests : GameLogic
    {
        [TestMethod()]
        public void GameLoopTest()
        {
            GameLogic user = new GameLogic();
            try
            {
                user.GameLoop();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

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
            var result = QuitOrPlayGame();

            // Assert
            Assert.AreEqual(expected, result);
        }

        
        // This test method checks that the CheckBullOrCow method returns the correct result when the goal and guess strings are different.
        [TestMethod()]
        public void TestCheckBullOrCow_DifferentStrings()
        {
            // Arrange
            string goal = "1234";
            string guess = "4321";

            // Act
            string result = CheckBullOrCow(goal, guess);

            // Assert
            Assert.AreEqual("Result: [] , [CCCC]", result); // The spaces needs to be equal.

        }

        
        // This testmethod ensures that the method returns a four-digit number string with unique digits
        [TestMethod]
        public void TestCreateGuessNumber_UniqueDigits()
        {
            // Act
            var result = createGuessNumber();

            // Assert
            Assert.AreEqual(4, result.Length);
            Assert.IsTrue(result.Distinct().Count() == 4);
        }
    }
}
/*
 [TestMethod]
public void TestSomething()
{
    try
    {
        YourMethodCall();
        Assert.IsTrue(true);
    }
    catch {
        Assert.IsTrue(false);
    }
}
 
 */
