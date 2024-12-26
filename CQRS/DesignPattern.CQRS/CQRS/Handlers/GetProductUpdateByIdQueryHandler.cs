using DesignPattern.CQRS.CQRS.Queries;
using DesignPattern.CQRS.CQRS.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class GetProductUpdateByIdQueryHandler(AppDbContext appDbContext)
    {
        public async Task<GetProductUpdateQueryResult> Handle(GetProductUpdateByIdQuery getProductUpdateByIdQuery)
        {
            var product = await appDbContext.Products!.FindAsync(getProductUpdateByIdQuery.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return new GetProductUpdateQueryResult
            {
                Id = product.Id,
                Name = product.Name!,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock
            };
        }
    }
}
