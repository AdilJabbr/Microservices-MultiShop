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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await repository.GetByIdAsync(command.AddressId);
            value.Detail = command.Detail;
            value.District = command.District;
            value.City = command.City;
            value.UserId = command.UserId;
            await repository.UpdateAsync(value);
        }
    }
}
