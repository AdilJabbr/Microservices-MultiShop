
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces.Generic;
using MultiShop.Order.Domain;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository) 
        {
            this.repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await repository.CreateAsync(new OrderDetail
            {
                ProductAmount = command.ProductAmount,
                OrderingId = command.OrderingId,
                ProductId = command.ProductId,
                ProductName = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice

            });
        }
    }
}
