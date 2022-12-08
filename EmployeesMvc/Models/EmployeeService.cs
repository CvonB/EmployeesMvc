namespace EmployeesMvc.Models
{
    public class EmployeeService
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="Eddy Binen",Email="Eddy@binen.com"},
            new Employee{Id=2,Name="Christian von Bothmer",Email="Christian@von.bothmer"},
            new Employee{Id=3,Name="Niklas Lindfors",Email="Niklas@lindfors.se"}
        };

        public void Add(Employee employee)
        {
            employee.Id = employees.Max(o => o.Id) + 1;
            employees.Add(employee);
        }

        public Employee[] GetAll()
        {
            return employees.ToArray();
        }

        public Employee GetById(int id)
        {
            return employees.FirstOrDefault(o => o.Id == id);
        }
    }
}
