using System;
using System.Collections.Generic;

namespace _8_login.Model;

public partial class User
{
    public int UId { get; set; }

    public string ULogin { get; set; } = null!;

    public string UPassword { get; set; } = null!;

    public string UEmail { get; set; } = null!;

    public string UPhoneNumber { get; set; } = null!;

    public int URId { get; set; }

    public int UFId { get; set; }
}
