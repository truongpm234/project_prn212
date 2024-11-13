using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public bool? IsApprovedUser { get; set; }

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
