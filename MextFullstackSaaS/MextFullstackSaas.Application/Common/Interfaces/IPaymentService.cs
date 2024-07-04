using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<object> CreateCheckoutFormAsync(CancellationToken cancellationToken);

    }
}
