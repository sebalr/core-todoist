using Nancy;
using todoist.Infraestructure.Entities;
using todoist.Persistance;

namespace todoist.Infraestructure.Extensions
{
    public static class NancyModuleExtensions
    {
        public static T GetById<T>(this INancyModule Module, string Id, IBaseFinder<T> Finder)
        where T : Entity
        {
            int id;
            if (!int.TryParse(Id, out id)) throw new HttpException(HttpStatusCode.BadRequest, $"{Id} it is not an int");

            T entity = Finder.GetById(id);

            if (entity == null)
            {
                throw new HttpException(HttpStatusCode.BadRequest, $"Element with Id = {id.ToString()} not found");
            }
            else
            {
                return entity;
            }
        }

    }
}