using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Helpers
{
    public static class MemoryCacheHelper
    {
        //public static string OrdersGetAllKey = "OrdersGetAllList";
        public static string GetOrdersGetAllKey(Guid userId) => $"OrdersGetAll_{userId}";
        public static string GetOrderGetByIdKey(Guid id) =>$"OrderGetById_{id}";

        public static MemoryCacheEntryOptions GetMemoryCacheEntryOptions()
        {
            return new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(12))
                .SetPriority(CacheItemPriority.Normal);


        }
    }
}
