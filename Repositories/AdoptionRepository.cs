using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesslayer;
using DataAccessLayer;

namespace Repositories
{
    public class AdoptionRepository : IAdoptionRepository
    {
 
        public List<Adoption> GetAll()
        => AdoptionDAO.GetAllAdoptions();
    }
}
