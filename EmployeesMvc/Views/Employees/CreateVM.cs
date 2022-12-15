using System.ComponentModel.DataAnnotations;

namespace EmployeesMvc.Views.Employees
{
    public class CreateVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "What is 2 + 2?")]
        [Range(4, 4)]
        public int BotCheck { get; set; }
    }
}
