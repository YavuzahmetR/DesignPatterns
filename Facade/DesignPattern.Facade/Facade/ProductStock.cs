using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.Facade
{
    public class ProductStock   
    {
        public async Task StockDecrease(int id , int amount)
        {
            using (var context = new Context())
            {
                var value = await context.Products.FindAsync(id);
                value!.Stock -= amount;
                await context.SaveChangesAsync();
            }
        }
    }
}
