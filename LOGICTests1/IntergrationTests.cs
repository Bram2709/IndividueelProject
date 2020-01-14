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

    public class IntergrationTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public IntergrationTests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        
        [TestMethod]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:5001/Login/Inloggen");
 
            Assert.AreEqual("Login a", _driver.Title);
        }


    }
}