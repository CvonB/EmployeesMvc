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

    public class JsonEmployeeService : IEmployeeService
    {
        private List<Employee> employees = new List<Employee>
        {
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

            SaveToFile();

        }

        public void Genocide()
        {
            for (int i = employees.Count - 1; i >= 0; i--)
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
        }

        public Employee[] GetAll()
        {
            LoadFromFile();
            return employees.ToArray();
        }

        public Employee GetById(int id)
        {
            return employees.FirstOrDefault(o => o.Id == id);
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
    }
}
