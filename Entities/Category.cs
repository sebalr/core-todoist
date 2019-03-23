using todoist.Infraestructure.Entities;

namespace todoist.Entities
{
    public class Category: EntityWithSoftDelete
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}