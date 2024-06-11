using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Models.Email
{
    public class EmailSendDto
    {
        public string Subject { get; set; }
        public List<string> Addresses { get; set; }
        public string HtmlContent { get; set; }

        public EmailSendDto(string email, string subject, string htmlContent)
        {
            Subject = subject;
            Addresses = new() { email };
            HtmlContent = htmlContent;
        }


        public EmailSendDto(List<string> emails,string subject,  string htmlContent)
        {
            Subject = subject;
            Addresses = emails;
            HtmlContent = htmlContent;
        }

    }
}
