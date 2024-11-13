using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BussinessObject.Models;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static User checkLogin(string email, string password)
        {
            using var db = new PawFundProjectContext();
            return db.Users.SingleOrDefault(d => d.Email.Equals(email) && d.Password.Equals(password));
        }
    }
}
