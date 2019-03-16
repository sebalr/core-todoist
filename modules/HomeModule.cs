using Nancy;
using Nancy.Security;

namespace todoist.modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.RequiresAuthentication();
            Get("/", _ => "Hello dotnet core world!");
        }
    }
}