using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken);
        Task<List<string>> UploadImagesAsync(List<string> imagesData, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(string key, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(List<string> keys, CancellationToken cancellationToken);

    }
}
