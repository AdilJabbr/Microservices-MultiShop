using MediatR;
using MultiShop.Order.Application.Features.MediatR.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.MediatR.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces.Generic;
using MultiShop.Order.Domain;

namespace MultiShop.Order.Application.Features.MediatR.Handlers.OrderingHandlers
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQuery, List<GetAllOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetAllOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrderingQueryResult>> Handle(GetAllOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllOrderingQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
