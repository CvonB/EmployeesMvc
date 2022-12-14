using EmployeesMvc.Models.Entities;

namespace EmployeesMvc.Models
{

    public class EmployeeService 
    {
        public EmployeeService(EmployeesContext context)
        {
                this.context = context;
        }

        private readonly EmployeesContext context;


        


        public int KillCount { get; set; }

        public async Task Kill(Employee employee)
        {
            var tmp = context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            KillCount++;
            context.Employees.Remove(tmp);
            await context.SaveChangesAsync();
        }

        public async Task Add(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee[]> GetAll()
        {
            await Task.Delay(0);

            return context.Employees
                .OrderBy(o => o.Name)
                .ToArray();
        }

        public async Task<Employee> GetById(int id)
        {
            await Task.Delay(0);
            return context.Employees.FirstOrDefault(o => o.Id == id);
        }
    }

}
