using todoist.Entities;

namespace todoist.Persistance.Finders
{
    public interface ICategoryFinder : IBaseFinder<Category>
    { }

    public class CategoryFinder : BaseFinder<Category>, ICategoryFinder
    {
        public CategoryFinder(BaseContext baseContext) : base(baseContext) { }

    }
}