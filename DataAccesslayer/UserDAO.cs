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

        public int? GetUserId()
{
    return UserSession.UserId;
}


        public static List<User> GetAllUsers()
        {
            var listUser = new List<User>();
            try
            {
                using var context = new PawFundProjectContext();
                listUser = context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUser;
        }

        public void DeleteUser(User u)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Users.Remove(u);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void SaveUser(User p)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Users.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the user.", ex);

            }
        }

        public void UpdateUser(User u)
        {
            try
            {
                using var context = new PawFundProjectContext();
                context.Entry<User>(u).State
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
