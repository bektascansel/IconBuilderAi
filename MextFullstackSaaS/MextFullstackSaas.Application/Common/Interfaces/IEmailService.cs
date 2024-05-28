using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailVerificationAsync(string email, string subject, string message);
    }
}
