using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmployeesMvc.Models
{
    public class EmployeeService
    {
        static List<Employee> employees = new List<Employee>
        {
            //new Employee{Id=1,Name="Eddy Binen",Email="Eddy@binen.com"},
            //new Employee{Id=2,Name="Christian von Bothmer",Email="Christian@von.bothmer"},
            //new Employee{Id=3,Name="Niklas Lindfors",Email="Niklas@lindfors.se"}
        };

        public void Add(Employee employee)
        {
            if (employees.Count != 0)
            {
                employee.Id = employees.Max(o => o.Id) + 1;

            }
            employees.Add(employee);
            SaveToFile();
            SaveXML();
        }

        public void SaveToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("employees.json", JsonSerializer.Serialize(employees, options));
        }

        public void LoadFromFile()
        {
            if (File.Exists("employees.json"))
            {
                var json = File.ReadAllText("employees.json");
                employees = JsonSerializer.Deserialize<List<Employee>>(json);

            }
        }

        public void SaveXML()
        {
            var serializer = new XmlSerializer(typeof(List<Employee>), new XmlRootAttribute("Employees"));
            using (var stream = new StringWriter())
            {
                serializer.Serialize(stream, employees);
                File.WriteAllText("employees.xml", stream.ToString());
            }
        }

        public void LoadXML()
        {
            var serializer = new XmlSerializer(typeof(List<Employee>), new XmlRootAttribute("Employees"));
            if (File.Exists("employees.xml"))
            {
                using (var stream = new FileStream("employees.xml", FileMode.Open))
                {
                    employees = (List<Employee>)serializer.Deserialize(stream);
                }
            }
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
