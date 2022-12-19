using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Components;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MooGameTests.Tests
{
    [TestClass()]
    public class UserObjectTests
    {
        UserObject user = new UserObject();

        [TestMethod]
        //Testing for appropriate input from user. Nun or too long of an input is not allowed
        public void CheckUserNameTest()
        {
            bool result = user.CheckUserName("NametooLong12334567");
            bool result2 = user.CheckUserName("A");
            bool result3 = user.CheckUserName("");
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(false, result3);
        }

        [TestMethod()]
        // Testing for user guess where null and longer tha 4 char input is not allowed
        public void CheckUserGuessTest()
        {
            bool svar = user.CheckUserGuess(null);
            bool svar2 = user.CheckUserGuess("12345");
            bool svar3 = user.CheckUserGuess("12");
            Assert.AreEqual(false, svar);
            Assert.AreEqual(false, svar2);
            Assert.AreEqual(true, svar3);
        }


        [TestMethod()]
        // testing if number of guesses in user object is as expected
        public void UpdateTest()
        {
            user.Update(2);
            Assert.AreEqual(2, user.NumberOfGuesses);
        }

        [TestMethod()]
        public void AverageTest()
        {
            user.NumberOfGuesses = 8;
            user.NumberOfGames = 4;
            double result = user.Average();
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        // Testing for null or empty input. String less than 10 char is allowed
        public void checkNullorEmptyTest()
        {
            bool svar = user.checkNullorEmpty(null);
            bool svar2 = user.checkNullorEmpty("");
            bool svar3 = user.checkLength("milad", max: 10);
            Assert.AreEqual(false, svar);
            Assert.AreEqual(false, svar2);
            Assert.AreEqual(true, svar3);
        }

        [TestMethod()]
        // Testing for user guess where max 4 chars are allowed
        public void checkLengthTest()
        {
            bool result = user.checkLength("50155");
            bool result2 = user.checkLength("50");
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, result2);
        }

    }

}
