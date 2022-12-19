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
        // This test checks that the testSave method correctly writes the UserObject instance to a text file and that the text file has the expected contents.
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
                textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses);
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
        // Testing if the method completes without failing
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
            
            // Testing if update method is equal to the expected value
            Assert.AreEqual(9, testClass.userList[0].NumberOfGuesses);

            testClass.UpdatePlayerData("Player 2", 1);
            // Testing if user object is added as expected
            Assert.AreEqual("Player 2", testClass.userList[1].UserName);
        }

        [TestMethod()]
        // Testing if the method completes without failing
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
