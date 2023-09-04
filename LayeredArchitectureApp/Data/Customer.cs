using System;
using System.Collections.Generic;

namespace LayeredArchitectureApp.Data;

public partial class Customer
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string Lastname { get; set; } = null!;
}
