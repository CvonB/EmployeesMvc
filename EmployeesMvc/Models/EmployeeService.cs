using EmployeesMvc.Controllers;
using EmployeesMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMvc.Models
{

    public class EmployeeService 
    {
        public EmployeeService(EmployeesContext context)
        {
                this.context = context;
        }
        private readonly EmployeesContext context;

        public static Company CurrentCompany { get; set; }

        public async Task Kill(Employee employee)
        {
            var tmp = context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            context.Employees.Remove(tmp);
            await context.SaveChangesAsync();
        }

        public async Task Add(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee[]> GetAllEmployees(int id)
        {
            await Task.Delay(0);

            return context.Employees
                .Include(o => o.Company)
                .OrderBy(o => o.Name)
                .Where(o => o.CompanyId == id)
                .ToArray();
        }

        public async Task<Company[]> GetAllCompanies()
        {
            await Task.Delay(0);

            return context.Companies
                .OrderBy(o => o.Name)
                .ToArray();
        }

        public async Task<Employee> GetById(int id)
        {
            await Task.Delay(0);
            return context.Employees.FirstOrDefault(o => o.Id == id);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            await Task.Delay(0);
            return context.Companies.FirstOrDefault(o => o.Id == id);

        }

        public async Task<Employee> GetEmployeeByCompany(int id)
        {
            await Task.Delay(0);
            return context.Employees.Include(o => o.Company).Where(o => o.CompanyId == id).FirstOrDefault();

        }

        internal async Task AddCompany(Company company)
        {
            context.Companies.Add(company);
            await context.SaveChangesAsync();
        }
    }
}
