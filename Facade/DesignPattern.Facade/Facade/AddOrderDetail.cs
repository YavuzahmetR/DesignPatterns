using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.Facade
{
    public class AddOrderDetail
    {
        public async Task AddNewOrderDetail(OrderDetail orderDetail)
        {
            using (var context = new Context())
            {
                context.OrderDetails.Add(orderDetail);
                await context.SaveChangesAsync();
            }
        }
    }
}
