using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdoptionDAO
    {
        public static List<Adoption> GetAllAdoptions()
        {
            var listAdoption = new List<Adoption>();
            try
            {
                using var context = new PawFundProjectContext();
                listAdoption = context.Adoptions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAdoption;
        }

    }
}
