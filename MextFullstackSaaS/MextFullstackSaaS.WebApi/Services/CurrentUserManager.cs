
using MextFullstackSaaS.Application.Common.Interfaces;
using System.Security.Claims;

namespace MextFullstackSaaS.WebApi.Services
{
    public class CurrentUserManager : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId =>GetUserId();
      
        private Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");

            return userId is null ? Guid.Empty : Guid.Parse(userId);

        }
    }
}


