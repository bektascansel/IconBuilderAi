using MextFullstackSaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager : IObjectStorageService
    {
        public Task<string> UploadImageAsync(byte[] imageData, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
