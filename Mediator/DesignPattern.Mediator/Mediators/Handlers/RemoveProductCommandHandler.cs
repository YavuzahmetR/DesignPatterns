using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.Mediators.Commands;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Handlers
{
    public class RemoveProductCommandHandler(Context context) : IRequestHandler<RemoveProductCommand>
    {
        
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var value = await context.Products.FindAsync(request.Id);
            context.Products.Remove(value!);
            await context.SaveChangesAsync();
        }
    }
}
