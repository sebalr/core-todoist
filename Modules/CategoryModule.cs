using todoist.DTOs;
using todoist.Entities;
using todoist.Infraestructure.Helpers;
using todoist.Infraestructure.Modules;
using todoist.Persistance.Finders;

namespace todoist.Modules
{
    public class CategoryModule : BaseApiModule<Category, CategoryDTO>
    {
        public CategoryModule(IBaseModuleService BaseModuleService, ICategoryFinder CategoryFinder) :
        base("category", BaseModuleService, CategoryFinder)
        {

        }
    }
}