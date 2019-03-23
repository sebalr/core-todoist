using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using todoist.Infraestructure;
using todoist.Infraestructure.Login;
using todoist.Infraestructure.Settings;
using todoist.Persistance;

namespace todoist
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(env.ContentRootPath);

            config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appConfig = new AppSettings();
            ConfigurationBinder.Bind(config, appConfig);

            /* services.AddDbContext<BaseContext>(options =>
                options.UseMySql(appConfig.DbSettings.ConnectionString)); */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var appConfig = new AppSettings();
            ConfigurationBinder.Bind(config, appConfig);

            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new CustomBootstrapper(appConfig)));
        }
    }
}