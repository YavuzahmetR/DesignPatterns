using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateWelcomeMessage(IServiceProvider serviceProvider) : IObserver
    {
        public void CreateNewUser(AppUser appUser)
        {
            using AppDbContext appDbContext = new AppDbContext();
            appDbContext.WelcomeMessages.Add(new WelcomeMessage
            {
                Content = $"Welcome {appUser.Name} {appUser.Surname}!",
                NameSurname = $"{appUser.UserName}",
            });
            appDbContext.SaveChanges();
        }
    }
}
