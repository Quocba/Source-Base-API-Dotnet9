using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Login
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime LoginDate { get; set; }

    public DateTime? LogoutDate { get; set; }

    public DateTime? LastAccess { get; set; }

    public int? IdComputer { get; set; }

    public string? Ipaddress { get; set; }

    public int? Pid { get; set; }

    public string? AppVersion { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
