using MyCompany.Infrastructure;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Подключаю конфиги
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // делаю секцию Project в обьектную форму для удобства
            IConfiguration configuration = configurationBuild.Build();
            AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

            // подключаю функионал MVC
            builder.Services.AddControllersWithViews();
            
            // собираю конфиг 
            WebApplication app = builder.Build();

            //! Порядок следования  middleware важен    

            // подключаю статические файлы
            app.UseStaticFiles();

            // подключаю систему маршутизации
            app.UseRouting();

            // регистрирую нужные маршруты
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");



            // запускаю приложение
            await app.RunAsync();
        }
    }
}
