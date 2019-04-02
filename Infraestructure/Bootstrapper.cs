using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using todoist.Infraestructure.Automapper;
using todoist.Infraestructure.Helpers;
using todoist.Infraestructure.Services;
using todoist.Infraestructure.Settings;
using todoist.Persistance;
using todoist.Persistance.finders;
using todoist.Persistance.Finders;

namespace todoist.Infraestructure
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppSettings _appConfig;

        public CustomBootstrapper(IAppSettings appConfig)
        {
            _appConfig = appConfig;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IAppSettings>(_appConfig);


        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            base.ApplicationStartup(container, pipelines);

            var identityProvider = container.Resolve<IIdentityProvider>();
            var statelessAuthConfig = new StatelessAuthenticationConfiguration(identityProvider.GetUserIdentity);

            StatelessAuthentication.Enable(pipelines, statelessAuthConfig);

        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseMySql(_appConfig.DbSettings.ConnectionString);
            container.Register<BaseContext>(new BaseContext(optionsBuilder.Options));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(container.Resolve);
                cfg.AddProfile(new AutomapperProfiles());
            });
            container.Register<IMapper>(config.CreateMapper());


            
            container.Register<IUserFinder, UserFinder>();
            container.Register<ICategoryFinder, CategoryFinder>();

            container.Register<IBaseModuleService, BaseModuleService>();
        }
    }
}