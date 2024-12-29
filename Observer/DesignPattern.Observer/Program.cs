using DesignPattern.Observer.DAL;
using DesignPattern.Observer.ObserverPattern;

namespace DesignPattern.Observer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddSingleton<ObserverObject>(sp =>
            {
                ObserverObject observerObject = new();
                observerObject.Attach(new CreateWelcomeMessage(sp));
                observerObject.Attach(new CreateDiscountCode(sp));
                observerObject.Attach(new CreateMagazineAnnouncement(sp));
                return observerObject;
            });

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
