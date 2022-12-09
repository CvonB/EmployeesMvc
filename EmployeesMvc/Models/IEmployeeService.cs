namespace EmployeesMvc.Models
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        void Kill(Employee id);
        void Genocide();
        void Invade();
        public Employee GetById(int id);
        public Employee[] GetAll();
    }
}
