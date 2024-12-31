using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Commands;
using MediatR;


namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class CreateProductCommandHandler(Context context) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            context.Products.Add(new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                StockType = request.StockType,
                Type = request.Type
            });
            await context.SaveChangesAsync();
        }
    }
}
