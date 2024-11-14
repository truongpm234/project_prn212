using BussinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly UserDAO userDAO;

        public UserRepository()
        {
            userDAO = new UserDAO();
        }
        public User checkLogin(string email, string password)
        => UserDAO.checkLogin(email, password);

        public void deleteUser(User u)
        => userDAO.DeleteUser(u);

        public List<User> findAllUsers()
        => UserDAO.GetAllUsers();

        public void saveUser(User u)
        =>userDAO.SaveUser(u);

        public void updateUser(User u)
        => userDAO.UpdateUser(u);

        public void getUserId(string userId) 
        => userDAO.GetUserId();
    }
}
