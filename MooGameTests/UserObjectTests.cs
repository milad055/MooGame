using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MooGame.Tests
{
    [TestClass()]
    public class UserObjectTests
    {
        //[TestMethod()]
        //public void GetUserNameTest()
        //{
        //    // Arrange
        //    UserObject user = new UserObject();
        //    string name = "milad";

        //    // Act
        //    user.GetUserName();

        //    // Assert
        //    Assert.That(user.UserName, Is.Not.Null);
        //    //Assert.AreEqual(user.UserName, "milad");
        //}


        //[TestMethod()]
        //public void ContinueGameTest()
        //{
        //    Assert.AreEqual(true, UserObject.QuitOrPlayGame());
        //}

        [TestMethod]
        public void CheckUserNameTest()
        {
            UserObject user = new UserObject();
            bool result = user.CheckUserName("NametooLong12334567");
            bool result2 = user.CheckUserName("A");
            bool result3 = user.CheckUserName("");
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(false, result3);
        }
        [TestMethod()]
        public void checkNullorEmptyTest()
        {
            UserObject user = new UserObject();
            bool svar = user.checkNullorEmpty(null);
            bool svar2 = user.checkNullorEmpty("");
            bool svar3 = user.checkLength("milad", max:10);
            Assert.AreEqual(false, svar);
            Assert.AreEqual(false, svar2);
            Assert.AreEqual(true, svar3);

            
        }

        [TestMethod()]
        public void checkLengthTest() 
        {
            UserObject user = new UserObject();
            bool result = user.checkLength("50155", max:4);
            Assert.AreEqual(false, result);
        
        }
    }

}
/*  1.Hur många tester ska vi ha? 
 *  2.Vad ska man testa exakt av en metod?
    3.Gör vi rätt? Eller har vi tänkt rätt?
    4.Måste vi ge testet data för att kunna utföra logiken?
    5.Måste vi ändra vår privat metoder till public för att kunna köra tester?
        Finns det något annat sätt som inte ändrar vår arkitektur?
    6.

 */