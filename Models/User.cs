using System;
using System.Collections.Generic;

namespace RisePingAPIs.Models;

public partial class User
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? DeptId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Password { get; set; }

    public decimal? Score { get; set; }

    public bool? EmailInd { get; set; }

    public bool? PushNotiInd { get; set; }

    public DateTime? InsertedDate { get; set; }

    public virtual DeptSetup? Dept { get; set; }

    public virtual RoleSetup? Role { get; set; }
}

public partial class UserCreate
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? DeptId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Password { get; set; }

    public decimal? Score { get; set; }

    public bool? EmailInd { get; set; }

    public bool? PushNotiInd { get; set; }

    public DateTime? InsertedDate { get; set; }

}
