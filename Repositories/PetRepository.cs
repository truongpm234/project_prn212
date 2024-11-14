using BussinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetDAO petDAO;
        public PetRepository()
        {
            petDAO = new PetDAO();
        }
        public void DeletePet(Pet p)
        => petDAO.DeletePet(p);

        public List<Pet> GetAllPets()
        => (List<Pet>)petDAO.getAll();

        public void SavePet(Pet p)
        => petDAO.SavePet(p);

        public void UpdatePet(Pet p)
        => petDAO.UpdatePet(p);   
    }
}
