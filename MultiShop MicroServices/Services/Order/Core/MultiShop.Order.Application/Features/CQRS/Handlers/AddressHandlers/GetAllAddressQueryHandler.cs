using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces.Generic;
using MultiShop.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAllAddressQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAllAddressQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public  async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x=> new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }

    }
}
