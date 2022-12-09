namespace EmployeesMvc.Models
{



    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {
        }

        private List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="Eddy Binen",Email="Eddy@binen.com"},
            //new Employee{Id=2,Name="Christian von Bothmer",Email="Christian@von.bothmer"},
            new Employee{Id=3,Name="Niklas Lindfors",Email="Niklas@lindfors.se"}
        };



        public void Kill(Employee employee)
        {
            var tmp = employees.FirstOrDefault(x => x.Id == employee.Id);
            employees.Remove(tmp);
        }

        public void Invade()
        {
            for (int i = 0; i < 400; i++)
            {
                Employee emp = new Employee();
                if (employees.Count != 0)
                {
                    emp.Id = employees.Max(o => o.Id) + 1;

                }
                emp.Name = "Christian von Bothmer";
                emp.Email = "Rick@astley.com";
                employees.Add(emp);
            }

        }

        public void Genocide()
        {
            for (int i = employees.Count - 1; i >= 0; i--)
            {
                employees.Remove(employees[i]);

            }
        }

        public void Add(Employee employee)
        {
            if (employees.Count != 0)
            {
                employee.Id = employees.Max(o => o.Id) + 1;

            }
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
