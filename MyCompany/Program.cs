using MyCompany.Infrastructure;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // ��������� �������
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // ����� ������ Project � ��������� ����� ��� ��������
            IConfiguration configuration = configurationBuild.Build();
            AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

            // ��������� ��������� MVC
            builder.Services.AddControllersWithViews();
            
            // ������� ������ 
            WebApplication app = builder.Build();

            //! ������� ����������  middleware �����    

            // ��������� ����������� �����
            app.UseStaticFiles();

            // ��������� ������� ������������
            app.UseRouting();

            // ����������� ������ ��������
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");



            // �������� ����������
            await app.RunAsync();
        }
    }
}
