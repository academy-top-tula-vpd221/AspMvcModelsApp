using AspMvcModelsApp.Models;

namespace AspMvcModelsApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CompanyNameModel> CompanyNames { get; set; } = new List<CompanyNameModel>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
