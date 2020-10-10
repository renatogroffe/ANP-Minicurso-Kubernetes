using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SiteContagem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                    {
                        options.Connect(settings["ConnectionStrings:AppConfiguration"])
                            .ConfigureRefresh(refresh =>
                            {
                                refresh.Register("Saudacao");
                                refresh.Register("UrlMinicursoKubernetes");
                                refresh.Register("UrlMinicursoBDs");
                                refresh.Register("UrlMinicursoDocker");
                                refresh.Register("UrlMinicursoAzureDevOps");
                                refresh.Register("UrlMinicursoInfra");
                                refresh.Register("UrlBrindesMicrosoft");
                                refresh.Register("UrlSorteio");
                            });
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}