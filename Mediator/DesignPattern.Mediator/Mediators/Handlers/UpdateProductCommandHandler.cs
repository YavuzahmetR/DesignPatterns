using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Commands;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class UpdateProductCommandHandler(Context context) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var value = await context.Products.FindAsync(request.Id);
            if (value == null)
            {
                throw new Exception("Product not found");
            }
            value.Name = request.Name;
            value.Price = request.Price;
            value.Stock = request.Stock;
            value.StockType = request.StockType;
            value.Type = request.Type;
            await context.SaveChangesAsync();
        }
    }
}
