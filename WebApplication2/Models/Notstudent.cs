using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Notstudent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? JoinDate { get; set; }
}
