namespace WEB.APP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class StpInitializer : DropCreateDatabaseIfModelChanges<StpDbContext>
    {
        protected override void Seed(StpDbContext context)
        {
            var companies = new List<Company>
            {
                new Company{Name="STP"},
                new Company{Name="Philips"},
                new Company{Name="ACME"}
            };

            companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{CompanyId=companies[0].Id, FullName="Worker 1", Salary=1000.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.A},
                new Employee{CompanyId=companies[0].Id, FullName="Worker 2", Salary=2000.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.C},
                new Employee{CompanyId=companies[0].Id, FullName="Worker 3", Salary=2300.5m, Company=companies[0], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.B},
                new Employee{CompanyId=companies[1].Id, FullName="Worker 4", Salary=5000.5m, Company=companies[1], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.B},
                new Employee{CompanyId=companies[1].Id, FullName="Worker 5", Salary=7000.0m, Company=companies[1], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.D},
                new Employee{CompanyId=companies[1].Id, FullName="Worker 6", Salary=7000.0m, Company=companies[1], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.D},
                new Employee{CompanyId=companies[2].Id, FullName="Worker 7", Salary=1500.5m, Company=companies[2], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.A},
                new Employee{CompanyId=companies[2].Id, FullName="Worker 8", Salary=2500.5m, Company=companies[2], StartDate=DateTime.Now, VacationDays=15.5m, Experiance=ExperianceLevel.B},
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }
    }
}