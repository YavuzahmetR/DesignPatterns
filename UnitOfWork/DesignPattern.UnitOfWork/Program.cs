using DesignPattern.Bussiness.Abstract;
using DesignPattern.Bussiness.Concrete;
using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Concrete;
using DesignPattern.DataAccess.Repositories;
using DesignPattern.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.UnitOfWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitofWork, DesignPattern.DataAccess.UnitOfWork.UnitOfWork>();
            builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
            builder.Services.AddScoped<ICustomerService, CustomerManager>();


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
