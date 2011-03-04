using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestMVC3.Controllers;
using MsTestMVC3.Models;
using System.Web.Mvc;


namespace MsTestMVC3.Test.Controllers
{
    /// <summary>
    /// Summary description for HomeControllerFixture
    /// </summary>
    [TestClass]
    public class HomeControllerFixture
    {
        public HomeControllerFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestDetailsReturnsView()
        {
            HomeController _controller = new HomeController();
            ViewResult _result = _controller.Details(0);
            Assert.AreEqual(_result.ViewName, "Details");
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            HomeController _controller = new HomeController();
            ViewResult _result = _controller.Details(0);
            Product _item = _result.ViewData.Model as Product;
            Assert.AreEqual(_item.Name, "Data");
        }

        [TestMethod]
        public void TestDetailsRedirect()
        {
            HomeController _controller = new HomeController();
            RedirectToRouteResult _result = _controller.Category(-1) as RedirectToRouteResult;
           
            Assert.AreEqual("Index",_result.RouteValues["action"]);
        }

    }
}
