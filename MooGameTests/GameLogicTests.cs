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
    public class GameLogicTests
    {
        [TestMethod()]
        public void GameLoopTest()
        {
            try
            {
                GameLogic user = new GameLogic();

                string guessResult = "";
                while (guessResult != "BBBB") ;
                Assert.IsTrue(true, "Wrong answer, try again!");
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}