using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateMagazineAnnouncement(IServiceProvider serviceProvider) : IObserver
    {

        public void CreateNewUser(AppUser appUser)
        {
            using AppDbContext appDbContext = new AppDbContext();
            appDbContext.UserSpecifiedActions.Add(new UserSpecifiedAction
            {
                Content = $"Dear {appUser.Name} {appUser.Surname}, we have a new magazine announcement for you!",
                NameSurname = $"{appUser.UserName}",
                Magazine = "Software"
            });
            appDbContext.SaveChanges();
        }
    }
}
