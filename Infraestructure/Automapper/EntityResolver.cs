using AutoMapper;
using todoist.Infraestructure.DTOs;
using todoist.Infraestructure.Entities;
using todoist.Persistance;

namespace todoist.Infraestructure.Automapper
{
    public class EntityResolver<TDTO, TModel> : IMemberValueResolver<object, object, TDTO, TModel>
        where TDTO : EntityDTO
        where TModel : Entity
    {
        private readonly BaseContext _dbContext;

        public EntityResolver(BaseContext BaseContext)
        {
            _dbContext = BaseContext;
        }

        public TModel Resolve(object source, object destination, TDTO sourceMember, TModel destinationMember, ResolutionContext Context) 
        {
            if(sourceMember.Id != 0)
            {
                var a = _dbContext.Find<TModel>(sourceMember.Id);
            }
            return null;
        }
    }
}