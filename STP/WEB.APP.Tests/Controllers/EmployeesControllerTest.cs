namespace WEB.APP.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WEB.APP.Controllers;
    using WEB.APP.Models;

    [TestClass]
    public class EmployeesControllerTest : BaseTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new EmployeesController(this.MockContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            var mockedModels = result.Model as List<Employee>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8, mockedModels.Count);
            Assert.AreEqual("Worker 1", mockedModels[0].FullName);
            Assert.AreEqual("Worker 2", mockedModels[1].FullName);
            Assert.AreEqual("Worker 3", mockedModels[2].FullName);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            var controller = new EmployeesController(this.MockContext.Object);

            // Act
            var result = controller.Details(3) as ViewResult;

            var mockedModel = result.Model as Employee;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Worker 3", mockedModel.FullName);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var controller = new EmployeesController(this.MockContext.Object);

            // Act
            controller.Create();

            var employee = new Employee() {
                CompanyId = 1,
                FullName = "Worker 9",
                Salary = 2500.5m,
                StartDate = DateTime.Now,
                VacationDays = 15.0m,
                Experiance = ExperianceLevel.B
            };

            controller.Create(employee);
            var result = controller.Index() as ViewResult;
            var mockedModels = result.Model as List<Employee>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(9, mockedModels.Count);
            Assert.AreEqual("Worker 9", mockedModels[8].FullName);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            var controller = new EmployeesController(this.MockContext.Object);

            // Act
            var CompanyFindEdit = controller.Edit(2) as ViewResult;

            var mockedFindEditModel = CompanyFindEdit.Model as Employee;

            mockedFindEditModel.FullName = "Worker 2-Changed";

            controller.Edit(mockedFindEditModel);

            var result = controller.Index() as ViewResult;

            var mockedModels = result.Model as List<Employee>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8, mockedModels.Count);
            Assert.AreEqual("Worker 1", mockedModels[0].FullName);
            Assert.AreEqual("Worker 2-Changed", mockedModels[1].FullName);
            Assert.AreEqual("Worker 3", mockedModels[2].FullName);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var controller = new EmployeesController(this.MockContext.Object);

            // Act
            controller.Delete(2);
            controller.DeleteConfirmed(2);

            var result = controller.Index() as ViewResult;

            var mockedModels = result.Model as List<Employee>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7, mockedModels.Count);
            Assert.AreEqual("Worker 1", mockedModels[0].FullName);
            Assert.AreEqual("Worker 3", mockedModels[1].FullName);
        }
    }
}
