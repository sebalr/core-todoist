using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using todoist.infraestructure.services;
using todoist.infraestructure.settings;
using todoist.persistance;
using todoist.persistance.finders;

namespace todoist.infraestructure
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
            optionsBuilder.UseMySql("Server=http://172.17.0.2;Database=Todois;Uid=root;Pwd=se53ba63.;");
            container.Register<BaseContext>(new BaseContext(optionsBuilder.Options));

            // container.Register<IBaseContext, BaseContext>();
            container.Register<IUserFinder, UserFinder>();
        }
    }
}