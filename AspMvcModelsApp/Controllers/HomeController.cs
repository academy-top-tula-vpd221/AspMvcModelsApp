using AspMvcModelsApp.Models;
using AspMvcModelsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspMvcModelsApp.Controllers
{
    public class HomeController : Controller
    {
        List<Company> companies;
        List<Employee> employees;


        public HomeController()
        {
            companies = new()
            {
                new() { Id = 1, Title = "Yandex", City = "Moscow" },
                new() { Id = 2, Title = "Piter Soft", City = "St Peterburg" },
                new() { Id = 3, Title = "Super Game", City = "Kazan" },
            };
            employees = new()
            {
                new(){ Id = 1, Name = "Bobby", Age = 27, Company = companies[0] },
                new(){ Id = 2, Name = "Sammy", Age = 19, Company = companies[1] },
                new(){ Id = 3, Name = "Jimmy", Age = 32, Company = companies[2] },
                new(){ Id = 1, Name = "Tommy", Age = 21, Company = companies[0] },
                new(){ Id = 2, Name = "Jonny", Age = 35, Company = companies[1] },
                new(){ Id = 3, Name = "Leopold", Age = 26, Company = companies[2] },
                new(){ Id = 1, Name = "Kenny", Age = 18, Company = companies[0] },
                new(){ Id = 2, Name = "Billy", Age = 22, Company = companies[1] },
                new(){ Id = 3, Name = "Sandy", Age = 38, Company = companies[2] },
            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyNameModel> companyNamesModel = companies.Select(
                c => new CompanyNameModel()
                {
                    Id = c.Id,
                    CompanyTitle = c.Title
                }).ToList();
            companyNamesModel.Insert(0, new CompanyNameModel() { Id = 0, CompanyTitle = "All companies" });

            IndexViewModel indexModel = new()
            {
                CompanyNames = companyNamesModel
            };

            if (companyId is not null && companyId != 0)
                indexModel.Employees = employees.Where(e => e.Id == companyId).ToList();
            else
                indexModel.Employees = employees;

            return View(indexModel);
        }

        public string Privacy(Employee employee)
        {
            //return View();
            return $"{employee.Name} {employee.Company?.Title}";
        }

    }
}
