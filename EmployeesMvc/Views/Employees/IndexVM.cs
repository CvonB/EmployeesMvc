using System.ComponentModel.DataAnnotations;

namespace EmployeesMvc.Views.Employees
{
    public class IndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public bool ShowAsHighlighted => Email.StartsWith("admin");
    }
}
