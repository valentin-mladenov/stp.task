using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEB.APP;
using WEB.APP.Controllers;

namespace WEB.APP.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
