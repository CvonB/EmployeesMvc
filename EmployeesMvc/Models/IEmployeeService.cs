namespace EmployeesMvc.Models
{
    public interface IEmployeeService
    {

        int KillCount { get; set; }

        void Add(Employee employee);
        void Kill(Employee id);
        void Genocide();
        void Invade();
        public Employee GetById(int id);
        public Employee[] GetAll();
    }
}
