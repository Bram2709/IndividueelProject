using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LOGIC.Tests
{
    [TestClass()]
    public class SystemTests : IDisposable
    {

        private readonly IWebDriver _driver;
        public SystemTests()
        {
            _driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
        }

        public void Dispose()
        {
          
        }



        [TestMethod]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Login/Inloggen");

            Assert.AreEqual("Login Page - Reserverings App", _driver.Title);
        }

        [TestMethod]
        public void RegisterPageTestSucces()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Register/Registreren");

            _driver.FindElement(By.Id("name"))
                .SendKeys("Jan");

            _driver.FindElement(By.Id("telNr"))
                .SendKeys("068973245");

            _driver.FindElement(By.Id("username"))
                .SendKeys("a");

            _driver.FindElement(By.Id("password"))
                .SendKeys("b");

            _driver.FindElement(By.Id("submit"))
                .Click();

            Assert.AreEqual("Registreren - Reserverings App", _driver.Title);
            StringAssert.Contains(_driver.PageSource, "Register Succesfull");
        }

        [TestMethod]
        public void RegisterPageTestFail()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Register/Registreren");

            _driver.FindElement(By.Id("name"))
                .SendKeys("Jan");

            _driver.FindElement(By.Id("telNr"))
                .SendKeys("068973245");

            _driver.FindElement(By.Id("submit"))
                .Click();

            Assert.AreEqual("Registreren - Reserverings App", _driver.Title);
            StringAssert.Contains(_driver.PageSource, "Register Failed");
        }

        

        [TestMethod]
        public void LoginPageTestSucces()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Login/Inloggen");


            _driver.FindElement(By.Id("username"))
                .SendKeys("Jan1");

            _driver.FindElement(By.Id("password"))
                .SendKeys("Jan2");

            _driver.FindElement(By.Id("submit"))
                .Click();

            Assert.AreEqual("Login Page - Reserverings App", _driver.Title);
            StringAssert.Contains(_driver.PageSource, "Login Succesfull");
        }

        [TestMethod]
        public void LoginPageTestFail()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Login/Inloggen");


            _driver.FindElement(By.Id("username"))
                .SendKeys("c");

            _driver.FindElement(By.Id("password"))
                .SendKeys("d");

            _driver.FindElement(By.Id("submit"))
                .Click();

            Assert.AreEqual("Login Page - Reserverings App", _driver.Title);
            StringAssert.Contains(_driver.PageSource, "Login Unsuccesfull");
        }


        ////Unit Tests
        //[TestMethod]
        //public void GetUserByUserNameTest()
        //{
        //    UserController userController = new UserController();
        //    UserModel user = userController.GetUserByName("b");
        //    Assert.AreEqual("b", user.username.ToString());
        //    Assert.AreEqual("Bram1", user.password.ToString());
        //}

        //[TestMethod]
        //public void GetUserByUserNameTestFail()
        //{
        //    UserController userController = new UserController();
        //    UserModel user = userController.GetUserByName("b");
        //    Assert.AreNotEqual("Hans", user.username.ToString());
        //    Assert.AreNotEqual("Hans2", user.password.ToString());
        //}


        //[TestMethod()]
        //public void LoginCheckTest()
        //{
        //    User userController = new User();

        //    bool loginCheck = userController.LoginCheck("b","Bram1");
        //    Assert.IsTrue(loginCheck);
        //}

        //[TestMethod()]
        //public void LoginCheckTest2()
        //{
        //    User userController = new User();

        //    bool loginCheck = userController.LoginCheck("Bram", "Bram2");
        //    Assert.IsFalse(loginCheck);
        //}
    }
}