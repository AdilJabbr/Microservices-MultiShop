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
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
