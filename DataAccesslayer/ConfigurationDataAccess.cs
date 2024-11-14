using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConfigurationDataAccess
    {
        public EmailSettings GetEmailSettings()
        {
            return new EmailSettings
            {
                Email = "PawFundProject@gmail.com",
                Password = "kqqntpouhtebqlic",
                Host = "smtp.gmail.com",
                Displayname = "PawFundPet",
                Port = 587
            };
        }
    }
}
