using Nancy;
using Nancy.Security;
using todoist.persistance;
using todoist.persistance.finders;

namespace todoist.modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(UserFinder userFinder)
        { 
            
            // this.RequiresAuthentication();
            
            Get("/", _ =>
            {
                var users = userFinder.GetById(1);

                return "Hello dotnet core world!";
            });

        }
    }
}