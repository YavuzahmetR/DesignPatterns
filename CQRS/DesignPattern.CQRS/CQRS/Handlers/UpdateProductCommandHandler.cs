using DesignPattern.CQRS.CQRS.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class UpdateProductCommandHandler(AppDbContext appDbContext)
    {
        public async Task Handle(UpdateProductCommand updateProductCommand)
        {
            var product = await appDbContext.Products!.FindAsync(updateProductCommand.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.Name = updateProductCommand.Name;
            product.Price = updateProductCommand.Price;
            product.Description = updateProductCommand.Description;
            product.Stock = updateProductCommand.Stock;
            await appDbContext.SaveChangesAsync();
        }
    }
}
