using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Adoption
{
    public int AdoptionId { get; set; }

    public int? UserId { get; set; }

    public int? PetId { get; set; }

    public bool? IsApproved { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? SelfDescription { get; set; }

    public bool? HasPetExperience { get; set; }

    public string? ReasonForAdopting { get; set; }


    public virtual Pet? Pet { get; set; }

    public virtual User? User { get; set; }
}
