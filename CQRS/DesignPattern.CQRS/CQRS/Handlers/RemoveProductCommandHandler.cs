using DesignPattern.CQRS.CQRS.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class RemoveProductCommandHandler(AppDbContext appDbContext)
    {

        public async Task Handle(RemoveProductCommand removeProductCommand)
        {
            var product = await appDbContext.Products!.FindAsync(removeProductCommand.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
        }
    }
}
