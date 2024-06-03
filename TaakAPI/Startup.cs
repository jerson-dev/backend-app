using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Utilities;



namespace TaakAPI
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(this.configuration);
            services.AddHttpContextAccessor();
            //services.AddSingleton<MailService>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS",
                    builder =>
                    {
                        builder.WithOrigins("https://dev.web.taak.cl", "https://qa.web.taak.cl", "https://web.taak.cl")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddControllersWithViews();
        }
    }
}
