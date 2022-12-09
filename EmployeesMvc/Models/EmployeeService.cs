using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace EmployeesMvc.Models
{


    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }


    public class EmployeeService
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="Eddy Binen",Email="Eddy@binen.com"},
            //new Employee{Id=2,Name="Christian von Bothmer",Email="Christian@von.bothmer"},
            new Employee{Id=3,Name="Niklas Lindfors",Email="Niklas@lindfors.se"}
        };

        public EmployeeService()
        {
        }

        public void Kill(Employee employee)
        {
            var tmp = employees.FirstOrDefault(x => x.Id== employee.Id);
            employees.Remove(tmp);
            SaveToFile();
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
            SaveToFile();
        }

        public void Genocide()
        {

            for (int i = employees.Count-1; i >= 0; i--)
            {
                employees.Remove(employees[i]);

            }

            SaveToFile();
        }

        public void Add(Employee employee)
        {
            if (employees.Count != 0)
            {
                employee.Id = employees.Max(o => o.Id) + 1;

            }
            employees.Add(employee);
            SaveToFile();
            //SaveXML();
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
            using (var stream = new StringWriterUTF8())
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
