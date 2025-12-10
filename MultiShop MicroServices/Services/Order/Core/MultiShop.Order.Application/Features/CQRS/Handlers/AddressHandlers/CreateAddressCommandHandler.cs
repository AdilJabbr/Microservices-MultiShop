using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces.Generic;
using MultiShop.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await repository.CreateAsync(new Address
            {
                City = command.City,
                Detail = command.Detail,
                District = command.District,
                UserId = command.UserId
            });
        }
    }
}
