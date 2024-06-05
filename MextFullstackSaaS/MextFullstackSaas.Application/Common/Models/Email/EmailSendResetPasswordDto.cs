using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Models.Email
{
    public  class EmailSendResetPasswordDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Token { get; set; }

        public EmailSendResetPasswordDto(string email, string firstName, string token)
        {
            Email = email;
            FirstName = firstName;
            Token = token;
        }

        public EmailSendResetPasswordDto()
        {

        }
    }
}
