using DesignPattern.CQRS.CQRS.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRS.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand command)
        {
            _context.Products!.Add(new Product
            {
                Name = command.Name,
                Price = command.Price,
                Description = command.Description,
                Status = true
            });
           await _context.SaveChangesAsync();
        }
    }
}
