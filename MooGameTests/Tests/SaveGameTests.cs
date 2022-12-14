using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.Tests
{
    [TestClass()]
    public class SaveGameTests : MooSaveGame
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
                StreamWriter textFile = new(filename, append: true);
                textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses);
                textFile.Close();
            }

            testSave(user, "result.txt");
            StreamReader textDocument = new("result.txt");
            string line = textDocument.ReadLine();
            textDocument.Close();

            // Assert
            // Check that the file has been created and has the expected contents
            Assert.IsTrue(File.Exists("result.txt"));
            Assert.AreEqual(expectedFileContents, line);
        }


        [TestMethod()]
        // Testing if the method completes without failing
        public void ShowTopListTest()
        {

            try
            {
                DisplayPlayerData();
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
            UserList.Add(new UserObject("Player 1", 3));
            UpdatePlayerData("Player 1", 6);
            // Testing if update method is equal to the expected value
            Assert.AreEqual(9, UserList[0].NumberOfGuesses);

            UpdatePlayerData("Player 2", 1);
            // Testing if user object is added as expected
            Assert.AreEqual("Player 2", UserList[1].UserName);
            Assert.AreEqual(9, UserList[0].NumberOfGuesses);

            UpdatePlayerData("Player 2", 1);
            // Testing if user object is added as expected
            Assert.AreEqual("Player 2", UserList[1].UserName);
        }

        [TestMethod()]
        // Testing if the method completes without failing
        public void ReturnUserFromTextFileTest()
        {
            try
            {
                ReadPlayerData();
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
