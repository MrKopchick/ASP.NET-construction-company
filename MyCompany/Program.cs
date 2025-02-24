using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyCompany.Domain;
using MyCompany.Infrastructure;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // configuration
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfiguration configuration = configurationBuild.Build();
            AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

            // database, fix .net 9 bug
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(appConfig.Database.ConnectionString).
            ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));

            // identity system
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            // auth cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ConstructionCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.LoginPath = "/admin/login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // controllers
            builder.Services.AddControllersWithViews();
            WebApplication app = builder.Build();

            // static files
            app.UseStaticFiles();

            // routs
            app.UseRouting();

            // auth connection
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
