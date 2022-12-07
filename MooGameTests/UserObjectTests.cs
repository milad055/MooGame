using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace MooGame.Tests
{
    [TestClass()]
    public class UserObjectTests
    {
        [TestMethod()]
        public void GetUserNameTest()
        {
            // Arrange
            UserObject user = new UserObject();
            string name = "milad";

            // Act
            user.GetUserName();

            // Assert
            Assert.That(user.UserName, Is.Not.Null);
            //Assert.AreEqual(user.UserName, "milad");
        }
    }
}