using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        public User checkLogin(string email, string password);
        List<User> findAllUsers();

        void saveUser (User u);
        void deleteUser (User u);
        void updateUser (User u);
    }
}
