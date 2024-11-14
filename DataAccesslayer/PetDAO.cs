using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PetDAO
    {
        public IEnumerable<Pet> getAll()
        {
            using (var context = new PawFundProjectContext())
            {
                return context.Pets.Include(fp => fp.Adoptions).ToList();
            }
        }


        public void DeletePet(Pet p)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Pets.Remove(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void SavePet(Pet p)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Pets.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the pet.", ex);

            }
        }

        public void UpdatePet(Pet p)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Entry<Pet>(p).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
