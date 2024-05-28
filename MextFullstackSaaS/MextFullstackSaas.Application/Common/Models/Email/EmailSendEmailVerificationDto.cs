using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Common.Models.Email
{
    public class EmailSendEmailVerificationDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string Token { get; set; }

        public EmailSendEmailVerificationDto(string token, string firstName, string email)
        {
            Token = token;
            FirstName = firstName;
            Email = email;
        }

        public EmailSendEmailVerificationDto()
        {
        }
    }
}
