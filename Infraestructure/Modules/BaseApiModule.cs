using Nancy;
using todoist.Infraestructure.DTOs;
using todoist.Infraestructure.Entities;
using todoist.Infraestructure.Extensions;
using todoist.Infraestructure.Helpers;
using todoist.Persistance;

namespace todoist.Infraestructure.Modules
{

    public abstract class BaseApiModule<TEntity, TDTO> : NancyModule
    where TEntity : Entity
    where TDTO : EntityDTO
    {

        public BaseApiModule(string Route, IBaseModuleService BaseModuleService, IBaseFinder<TEntity> BaseFinder)
        : base(Route)
        {
            Get("/", parameters =>
            {
                var entities = BaseFinder.Get();

                return BaseModuleService.RespondWithListOfEntitiesDTO<TEntity, TDTO>(this, entities);
            });

            Get("/{ID}", parameters =>
            {
                var entity = this.GetById<TEntity>((string) parameters.ID, BaseFinder);

                return BaseModuleService.RespondWithEntitiyDTO<TEntity, TDTO>(this, entity);
            });
        }
    }
}