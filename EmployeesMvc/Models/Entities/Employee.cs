using System;
using System.Collections.Generic;

namespace EmployeesMvc.Models.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }
}
