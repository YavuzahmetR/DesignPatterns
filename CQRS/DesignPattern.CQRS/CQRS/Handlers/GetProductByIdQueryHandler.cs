using DesignPattern.CQRS.CQRS.Queries;
using DesignPattern.CQRS.CQRS.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class GetProductByIdQueryHandler(AppDbContext appDbContext)
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var product = await appDbContext.Products!.FindAsync(query.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return new GetProductByIdQueryResult
            {
                Id = product!.Id,
                Name = product.Name!,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
