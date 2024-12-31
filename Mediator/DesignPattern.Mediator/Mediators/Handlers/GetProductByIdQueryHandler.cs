using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Queries;
using DesignPattern.Mediator.Mediators.Results;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class GetProductByIdQueryHandler(Context context) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await context.Products.FindAsync(request.Id);
            return new GetProductByIdQueryResult
            {
                Id = value!.Id,
                Name = value.Name,
                Stock = value.Stock
            };
        }
    }
}
