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
    public class SaveGameTests : SaveGame
    {
        [TestMethod]
        public void SaveUserToFileTest()
        {
            // Arrange
            UserObject user = new UserObject
            {
                UserName = "johannes",
                NumberOfGuesses = 3
            };
            string expectedFileContents = "johannes#&#3";

            // Act

            void testSave(UserObject user, string filename = "result.txt")
            {
                StreamWriter textFile = new StreamWriter(filename, append: true);
                textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses); //SKa vi ändra  "#&#"?? alt = "|"
                textFile.Close();
            }

            testSave(user, "newtextFile.txt");
            StreamReader textDocument = new StreamReader("newtextFile.txt");
            string line = textDocument.ReadLine();
            textDocument.Close();

            // Assert
            // Check that the file has been created and has the expected contents
            Assert.IsTrue(File.Exists("newtextFile.txt"));
            Assert.AreEqual(expectedFileContents, line);
        }


        [TestMethod()]
        public void showTopListTest()
        {
            SaveGame testClass = new SaveGame();
            try
            {
                testClass.showTopList();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        
        [TestMethod()]
        public void UpdatePlayerDataTest()
        {
            SaveGame testClass = new SaveGame();
            testClass.userList.Add(new UserObject("Player 1", 3));
            testClass.UpdatePlayerData("Player 1", 6);
            Assert.AreEqual(9, testClass.userList[0].NumberOfGuesses);

            testClass.UpdatePlayerData("Player 2", 1);
            Assert.AreEqual("Player 2", testClass.userList[1].UserName);
        }

        [TestMethod()]
        public void returnUserFromTextFileTest()
        {
            SaveGame testClass = new SaveGame();
            try
            {
                testClass.returnUserFromTextFile();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
                throw new Exception(e.Message);
            }

        }
    }
}

/*[TestMethod]
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
}*/