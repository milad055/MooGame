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

    }
}

//List<string> readLine() {
//    StreamReader textDocument = new StreamReader("resultTest.txt");
//    List<string> line = new List<string>();
//    string checkFornull;
//    while ((checkFornull = textDocument.ReadLine()) != null)
//    {
//        line.Add(checkFornull);
//    }
//    textDocument.Close();
//    return line;

//}