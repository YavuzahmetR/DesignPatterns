using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateDiscountCode(IServiceProvider serviceProvider) : IObserver
    {
        public void CreateNewUser(AppUser appUser)
        {
            using AppDbContext appDbContext = new AppDbContext();
            appDbContext.Discounts.Add(new Discount
            {
                DiscountAmount = 10.00m,
                DiscountCode = "WELCOME10",
                IsPercentage = true,
            });
            appDbContext.SaveChanges();
        }
    }
}
