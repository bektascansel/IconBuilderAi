using MextFullstackSaas.Application.Common.Models;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Common.Interfaces
{
    public interface IJwtService
    {
        Task<JwtDto> GenerateTokenAsync(Guid userId, string email,CancellationToken cancellationToken);
        JwtDto GenerateToken(User user,List<string> roles);
    }
}
