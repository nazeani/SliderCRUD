using Microsoft.EntityFrameworkCore;
using Pronia.Business.Services.Abstracts;
using Pronia.Business.Services.Concrates;
using Pronia.Core.RepositoryAbstracts;
using Pronia.Data.DAL;
using Pronia.Data.RepositoryConcrates;

namespace _8may
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); });
            builder.Services.AddScoped<IFeatureService, FeatureService >();
            builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}