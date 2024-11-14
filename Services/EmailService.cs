using BussinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService
    {
        private readonly EmailRepository _emailRepository;

        public EmailService()
        {
            _emailRepository = new EmailRepository();
        }

        public async Task SendEmailAsync(Mailrequest mailRequest)
        {
            await _emailRepository.SendEmailAsync(mailRequest);
        }
    }
}
