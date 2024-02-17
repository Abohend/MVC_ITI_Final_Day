using Microsoft.EntityFrameworkCore;
using MVC.Context;

namespace MVC;

public class Program
{
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        #region Services
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var connString = builder.Configuration.GetConnectionString("DB");

        builder.Services.AddDbContext<CompanyContext>(options =>
            options.UseSqlServer(connString));


        #endregion

        var app = builder.Build();

        #region Middelwares
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run(); 
        #endregion
    }
}