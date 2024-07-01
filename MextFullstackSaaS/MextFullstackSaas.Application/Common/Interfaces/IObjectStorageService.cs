using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(byte[] imageData,CancellationToken cancellationToken);
    }
}
