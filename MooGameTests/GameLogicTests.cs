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
