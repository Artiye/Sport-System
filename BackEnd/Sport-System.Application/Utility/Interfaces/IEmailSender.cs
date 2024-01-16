using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Utility.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string toAddress, string subject, string message);
    }
}
