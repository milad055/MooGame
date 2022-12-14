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
    public class SaveGameTests
    {
        [TestMethod]
        public void SaveUserToFileTest()
        {
            // Arrange
            var user = new UserObject 
            { 
                UserName = "John",
                NumberOfGuesses = 3 
            };
            var expectedFileContents = "John#&#3\n";

            // Act
            SaveGame.SaveUserToFile(user);

            // Assert
            // Check that the file has been created and has the expected contents
            Assert.IsTrue(File.Exists("result.txt"));
            Assert.AreEqual(expectedFileContents, File.ReadAllText("result.txt"));
        }

    }
}