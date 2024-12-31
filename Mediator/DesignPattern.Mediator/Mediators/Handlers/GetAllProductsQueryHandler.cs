using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Queries;
using DesignPattern.Mediator.Mediators.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductQueryResults>>
    {
        private readonly Context context;
        public GetAllProductsQueryHandler(Context context)
        {
            this.context = context;
        }
        public async Task<List<GetAllProductQueryResults>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await context.Products.Select(x => new GetAllProductQueryResults
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                StockType = x.StockType,
                Type = x.Type
            }).AsNoTracking().ToListAsync();
            
        }
    }
}
