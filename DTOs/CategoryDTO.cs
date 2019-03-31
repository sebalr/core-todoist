using todoist.Infraestructure.DTOs;

namespace todoist.DTOs
{

    public class CategoryDTO : EntityDTO
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}