using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Text;
using LOGIC;
using MODEL;
using MODEL.Reservation;
using MODEL.Restaurant;
using MODEL.Table;
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


        //[TestMethod]
        //public void Create_WhenExecuted_ReturnsCreateView()
        //{
        //    _driver.Navigate()
        //        .GoToUrl("https://localhost:44332/Login/Inloggen");

        //    Assert.AreEqual("Login Page - Reserverings App", _driver.Title);
        //}

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

        [TestMethod]
        public void ReserveSucces()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44332/Reservation/Reserveren");

            _driver.FindElement(By.Id("reserveName"))
                .SendKeys("Hans");

            DateTime date = DateTime.Now.AddDays(2);

            _driver.FindElement(By.Id("date"))
                .SendKeys("02-02-2020");

            _driver.FindElement(By.Id("telNr"))
                .SendKeys("06948594");

            _driver.FindElement(By.Id("amountOfPeaple"))
                .SendKeys("2");

            _driver.FindElement(By.Id("note"))
                .SendKeys("Hans12");

            _driver.FindElement(By.Id("restaurant"))
                .SendKeys("Bomenpark");

            _driver.FindElement(By.Id("submit"))
                .Click();

            Assert.AreEqual("Reservation - Reserverings App", _driver.Title);
            StringAssert.Contains(_driver.PageSource, "Reserveren Succesfull");
        }




        [TestMethod]
        public void GetUserByUserNameTest()
        {
            UserController userController = new UserController();
            UserModel user = userController.GetUserByName("b");
            Assert.AreEqual("b", user.username.ToString());
            Assert.AreEqual("Bram1", user.password.ToString());
        }

        [TestMethod]
        public void GetUserByUserNameTestFail()
        {
            UserController userController = new UserController();
            UserModel user = userController.GetUserByName("b");
            Assert.AreNotEqual("Hans", user.username.ToString());
            Assert.AreNotEqual("Hans2", user.password.ToString());
        }


        [TestMethod()]
        public void LoginCheckTest()
        {
            User userController = new User();

            bool loginCheck = userController.LoginCheck("b", "Bram1");
            Assert.IsTrue(loginCheck);
        }

        [TestMethod()]
        public void LoginCheckTest2()
        {
            User userController = new User();

            bool loginCheck = userController.LoginCheck("Bram", "Bram2");
            Assert.IsFalse(loginCheck);
        }

        [TestMethod]
        public void ReservationTest()
        {
            ReservationsController reservationsController = new ReservationsController();
            RestaurantController restaurantController = new RestaurantController();
            ReservationModel reservationModel = new ReservationModel();
            RestaurantModel restaurantModel = new RestaurantModel();

            reservationModel.Name = "Bas";
            reservationModel.telNr = "06594857";
            DateTime today = DateTime.Today.Date;
            reservationModel.date = today.AddDays(1);
            reservationModel.amountOfPeaple = 6;
            reservationModel.note = "test";

            restaurantModel.restaurantName = "Bomenpark";
            
            Assert.IsTrue(reservationsController.TryToAddReservation(reservationModel, restaurantController.GetRestaurantModelByName(restaurantModel.restaurantName)));

        }

        [TestMethod]
        public void ReservationTestFail()
        {
            ReservationsController reservationsController = new ReservationsController();
            ReservationModel reservationModel = new ReservationModel();
            RestaurantModel restaurantModel = new RestaurantModel();

            reservationModel.Name = "Bas";
            DateTime today = DateTime.Today.Date;
            reservationModel.date = today.AddDays(1);
            reservationModel.telNr = "065948573";
            reservationModel.amountOfPeaple = 6;
            reservationModel.note = "test";
            restaurantModel.restaurantName = "";

            Assert.IsFalse(reservationsController.TryToAddReservation(reservationModel, restaurantModel));
        }

        [TestMethod]
        public void AddUserTest()
        {
            UserModel userModel = new UserModel();

            userModel.name = "Test";
            userModel.telNr = "06958485";
            userModel.username = "bram";
            userModel.password = "Bram12";

            UserController userController = new UserController();

           Assert.IsTrue(userController.AddUser(userModel));
        }

        [TestMethod]
        public void AddUserTestFail()
        {
            UserModel userModel = new UserModel();

            userModel.name = "Test";
            userModel.telNr = "06958485";
            userModel.username = "";
            userModel.password = "";

            UserController userController = new UserController();

            Assert.IsFalse(userController.AddUser(userModel));
        }

        [TestMethod]
        public void AddTableTest()
        {
            TableModel tableModel = new TableModel();
            tableModel.forThisAmountOfPeaple = 3;
            tableModel.restaurantID = 1;

            TableController tableController = new TableController();
            Assert.IsTrue(tableController.AddTable(tableModel));
        }

        [TestMethod]
        public void AddTableFail()
        {
            TableModel tableModel = new TableModel();
            tableModel.forThisAmountOfPeaple = 3;
            tableModel.restaurantID = 5;

            TableController tableController = new TableController();
            Assert.IsFalse(tableController.AddTable(tableModel));
        }

        [TestMethod]
        public void GetavailiblePlacesTest()
        {
            RestaurantModel restaurantModel = new RestaurantModel();
            RestaurantController restaurantController = new RestaurantController();

            Assert.AreEqual("88",restaurantController.GetAvaliblePlaces("Bomenpark").ToString());
        }
    }
}
