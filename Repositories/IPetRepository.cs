using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPetRepository
    {
        void SavePet(Pet p);
        void DeletePet(Pet p);
        void UpdatePet(Pet p);

        List<Pet> GetAllPets();
    }
}
