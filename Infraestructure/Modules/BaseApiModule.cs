using todoist.Infraestructure.DTOs;
using todoist.Infraestructure.Entities;

namespace todoist.Infraestructure.Modules
{
    public abstract class BaseApiModule <TEntity, TDTO> 
        where TEntity : Entity
        where TDTO : EntityDTO
    {
        
    }
}