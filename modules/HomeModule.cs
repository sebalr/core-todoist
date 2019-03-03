using Nancy;
namespace todoist.modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Hello dotnet core world!");
        }
    }
}