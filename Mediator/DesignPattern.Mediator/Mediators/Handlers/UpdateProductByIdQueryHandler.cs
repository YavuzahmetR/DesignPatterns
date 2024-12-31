using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Queries;
using DesignPattern.Mediator.Mediators.Results;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class UpdateProductByIdQueryHandler : IRequestHandler<UpdateProductByIdQuery, UpdateProductByIdQueryResult>
    {
        private readonly Context context;
        public UpdateProductByIdQueryHandler(Context context)
        {
            this.context = context;
        }
        public async Task<UpdateProductByIdQueryResult> Handle(UpdateProductByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await context.Products.FindAsync(request.Id);
            if (value == null)
            {
                throw new Exception("Product not found");
            }
            return new UpdateProductByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Price = value.Price,
                Stock = value.Stock,
                StockType = value.StockType
            };
        }
    }
}
