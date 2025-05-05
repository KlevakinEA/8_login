using System;
using System.Collections.Generic;

namespace _8_login.Model;

public partial class FullName
{
    public int FId { get; set; }

    public string FFirstName { get; set; } = null!;

    public string FLastName { get; set; } = null!;

    public string? FMiddleName { get; set; }
}
