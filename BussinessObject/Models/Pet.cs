using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string? PetName { get; set; }

    public string? PetType { get; set; }

    public string? Age { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? MedicalCondition { get; set; }

    public bool? IsAdopted { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public string? Size { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();

    public virtual User? User { get; set; }
}
