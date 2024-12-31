using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.Facade
{
    public class OrderFacade
    {
        Order order = new Order();
        OrderDetail orderDetail = new OrderDetail();
        ProductStock productStock = new ProductStock(); 

        AddOrder addOrder = new AddOrder();
        AddOrderDetail addOrderDetail = new AddOrderDetail();

        public async Task CompleteOrderDetail(int customerId, int productId, int orderId, int productCount, decimal
            productPrice)
        {
            orderDetail.OrderId = orderId;
            orderDetail.CustomerId = customerId;
            orderDetail.ProductsId = productId;
            orderDetail.Count = productCount;
            orderDetail.Price = productPrice;
            int totalProductPrice = Convert.ToInt32(productCount * productPrice);
            orderDetail.Total = totalProductPrice;
            await addOrderDetail.AddNewOrderDetail(orderDetail);

            await productStock.StockDecrease(productId, productCount);
        }
        public async Task CompleteOrder(int customerId
           )
        {
            order.CustomerId = customerId;
            await addOrder.AddNewOrder(order);
        }
    }
}
