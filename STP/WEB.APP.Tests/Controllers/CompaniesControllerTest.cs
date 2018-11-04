namespace WEB.APP.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WEB.APP.Controllers;
    using WEB.APP.Models;

    [TestClass]
    public class CompaniesControllerTest : BaseTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new CompaniesController(this.MockContext.Object);
            
            var result = controller.Index() as ViewResult;

            var mockedModels = result.Model as List<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, mockedModels.Count);
            Assert.AreEqual("STP", mockedModels[0].Name);
            Assert.AreEqual("Philips", mockedModels[1].Name);
            Assert.AreEqual("ACME", mockedModels[2].Name);
        }

        [TestMethod]
        public void Details()
        {
            var controller = new CompaniesController(this.MockContext.Object);

            var result = controller.Details(3) as ViewResult;

            var mockedModel = result.Model as Company;

            Assert.IsNotNull(result);
            Assert.AreEqual("ACME", mockedModel.Name);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new CompaniesController(this.MockContext.Object);

            controller.Create();
            
            var company = new Company() { Id=4, Name = "Osram"};

            controller.Create(company);

            var result = controller.Index() as ViewResult;
            var mockedModels = result.Model as List<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual(4, mockedModels.Count);
            Assert.AreEqual("Osram", mockedModels[3].Name);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new CompaniesController(this.MockContext.Object);
            
            var mockedFindEditModel = (controller.Edit(2) as ViewResult).Model as Company;

            mockedFindEditModel.Name = "Philips-Changed";

            controller.Edit(mockedFindEditModel);

            var result = controller.Index() as ViewResult;
            
            var mockedModels = result.Model as List<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, mockedModels.Count);
            Assert.AreEqual("STP", mockedModels[0].Name);
            Assert.AreEqual("Philips-Changed", mockedModels[1].Name);
            Assert.AreEqual("ACME", mockedModels[2].Name);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var controller = new CompaniesController(this.MockContext.Object);

            // Act
            controller.Delete(2);
            controller.DeleteConfirmed(2);

            var result = controller.Index() as ViewResult;

            var mockedModels = result.Model as List<Company>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, mockedModels.Count);
            Assert.AreEqual("STP", mockedModels[0].Name);
            Assert.AreEqual("ACME", mockedModels[1].Name);
        }
    }
}
