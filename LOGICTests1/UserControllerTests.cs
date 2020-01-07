using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace LOGIC.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod]
        public void GetUserByUserNameTest()
        {
            UserController userController = new UserController();
            UserModel user = userController.GetUserByName("Bram");
            Assert.AreEqual("Bram", user.username.ToString());
            Assert.AreEqual("Bram1", user.password.ToString());
        }

        [TestMethod]
        public void GetUserByUserNameTestFail()
        {
            UserController userController = new UserController();
            UserModel user = userController.GetUserByName("Bram");
            Assert.AreNotEqual("Hans", user.username.ToString());
            Assert.AreNotEqual("Hans2", user.password.ToString());
        }


        [TestMethod()]
        public void LoginCheckTest()
        {
            UserController userController = new UserController();

            bool loginCheck = userController.LoginCheck("Bram","Bram1");
            Assert.IsTrue(loginCheck);
        }

        [TestMethod()]
        public void LoginCheckTest2()
        {
            UserController userController = new UserController();

            bool loginCheck = userController.LoginCheck("Bram", "Bram2");
            Assert.IsFalse(loginCheck);
        }
    }
}