using DesignPattern.CQRS.CQRS.Commands;
using DesignPattern.CQRS.CQRS.Handlers;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddScoped<GetProductQueryHandler>();
            builder.Services.AddScoped<CreateProductCommandHandler>();
            builder.Services.AddScoped<GetProductByIdQueryHandler>();
            builder.Services.AddScoped<RemoveProductCommandHandler>();
            builder.Services.AddScoped<GetProductUpdateByIdQueryHandler>();
            builder.Services.AddScoped<UpdateProductCommandHandler>();
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