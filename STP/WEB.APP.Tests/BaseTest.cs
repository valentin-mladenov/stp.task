namespace WEB.APP.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WEB.APP.Models;

    public class BaseTest
    {
        protected Mock<StpDbContext> MockContext;
        protected Mock<IDbSet<Company>> CompanyMockSet;
        protected Mock<IDbSet<Employee>> EmployeeMockSet;

        [TestInitialize]
        public void Setup()
        {
            MockContext = new Mock<StpDbContext>();

            var companies = new List<Company>
            {
                new Company{Id=1, Name="STP"},
                new Company{Id=2, Name="Philips"},
                new Company{Id=3, Name="ACME"}
            };
            var companyQueryable = companies.AsQueryable();

            var employees = new List<Employee>
            {
                new Employee{Id=1, CompanyId=companies[0].Id, FullName="Worker 1", Salary=1000.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.A},
                new Employee{Id=2, CompanyId=companies[0].Id, FullName="Worker 2", Salary=2000.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=12.5m, Experiance=ExperianceLevel.C},
                new Employee{Id=3, CompanyId=companies[0].Id, FullName="Worker 3", Salary=2300.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.B},
                new Employee{Id=4, CompanyId=companies[1].Id, FullName="Worker 4", Salary=5000.5m, Company=companies[1], StartDate=DateTime.Now, VacationDays=25.5m, Experiance=ExperianceLevel.B},
                new Employee{Id=5, CompanyId=companies[1].Id, FullName="Worker 5", Salary=7000.0m, Company=companies[1], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.D},
                new Employee{Id=6, CompanyId=companies[1].Id, FullName="Worker 6", Salary=7000.0m, Company=companies[1], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.D},
                new Employee{Id=7, CompanyId=companies[2].Id, FullName="Worker 7", Salary=1500.5m, Company=companies[2], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.A},
                new Employee{Id=8, CompanyId=companies[2].Id, FullName="Worker 8", Salary=2500.5m, Company=companies[2], StartDate=DateTime.Now, VacationDays=15.0m, Experiance=ExperianceLevel.B},
            };
            var employeeQueryable = employees.AsQueryable();

            CompanyMockSet = MockDbSetExtensions.AsDbSetMock(companies, new Mock<IDbSet<Company>>());

            CompanyMockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => companies.FirstOrDefault(d => d.Id == (int)ids[0]));

            MockContext.Setup(m => m.Companies).Returns(CompanyMockSet.Object);

            EmployeeMockSet = MockDbSetExtensions.AsDbSetMock(employees, new Mock<IDbSet<Employee>>());
            
            EmployeeMockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => employees.FirstOrDefault(d => d.Id == (int)ids[0]));

            MockContext.Setup(m => m.Employees).Returns(EmployeeMockSet.Object);
        }
    }

    public static class MockDbSetExtensions
    {
        public static Mock<IDbSet<T>> AsDbSetMock<T>(this IList<T> list, Mock<IDbSet<T>> dbSetMock) where T : class
        {
            IQueryable<T> queryableList = list.AsQueryable();

            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
            
            dbSetMock.Setup(m => m.Add(It.IsAny<T>())).Callback<T>((entity) => list.Add(entity));
            dbSetMock.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>((entity) => list.Remove(entity));

            return dbSetMock;
        }
    }
}
