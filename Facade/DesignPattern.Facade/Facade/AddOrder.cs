using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.Facade
{
    public class AddOrder
    {
        public async Task AddNewOrder(Order order)
        {
            using (var context = new Context())
            {
                order.OrderedAt = DateTime.Parse(DateTime.Now.ToLongDateString());
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
