using MediatR;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAllCommunity;
using Microsoft.AspNetCore.SignalR;

namespace MextFullstackSaaS.WebApi.Hubs
{
    public class OrderHub:Hub
    {
        private readonly ISender _mediatr;


        public OrderHub(ISender mediatr)
        {
            _mediatr = mediatr;
        }




        //frontend kısmının backendde tetikleme yapabildiği yer
        public async Task NewOrderAddedAsync()
        {


        }

        public  async Task<List<string>> GetAllCommunityAsync()
        {
            return await _mediatr.Send(new OrderGetAllCommunityQuery());
        }
    }
}
