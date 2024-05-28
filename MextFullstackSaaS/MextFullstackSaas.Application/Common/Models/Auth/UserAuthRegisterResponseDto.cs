using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Common.Models.Auth
{
    public class UserAuthRegisterResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public UserAuthRegisterResponseDto(Guid id,string email) { 
                Id= id;

               Email= email;

        }
    }
}
