using DesignPattern.CQRS.CQRS.Results;
using DesignPattern.CQRS.DAL;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly AppDbContext _context;
        public GetProductQueryHandler(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            var result = await _context.Products!.Select(x => new GetProductQueryResult
            {
                Id = x.Id,
                Name = x.Name!,
                Price = x.Price,
                Stock = x.Stock
            }).ToListAsync();

            return result;
        }
    }
}
