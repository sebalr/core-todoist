using System.Collections.Generic;
using AutoMapper;
using Nancy;
using todoist.Infraestructure.DTOs;
using todoist.Infraestructure.Entities;

namespace todoist.Infraestructure.Helpers
{
    public interface IBaseModuleService
    {
        Response RespondWithListOfEntitiesDTO<TEntity, TDTO>(INancyModule Module, IEnumerable<TEntity> Entities)
        where TEntity : Entity
        where TDTO : EntityDTO;

        Response RespondWithEntitiyDTO<TEntity, TDTO>(INancyModule Module, TEntity Entity)
        where TEntity : Entity
        where TDTO : EntityDTO;

        IList<TDTO> ConvertToDTOs<TEntity, TDTO>(IEnumerable<TEntity> Entities)
        where TEntity : Entity
        where TDTO : EntityDTO;

        TDTO ConvertToDTO<TEntity, TDTO>(TEntity Entity)
        where TEntity : Entity
        where TDTO : EntityDTO;
    }

    public class BaseModuleService : IBaseModuleService
    {
        private IMapper _mapper;

        public BaseModuleService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public Response RespondWithListOfEntitiesDTO<TEntity, TDTO>(INancyModule Module, IEnumerable<TEntity> Entities)
        where TEntity : Entity
        where TDTO : EntityDTO
        {
            var entitiesDTO = ConvertToDTOs<TEntity, TDTO>(Entities);

            return Module.Response.AsJson<DataDTO<TDTO>>(new DataDTO<TDTO>(entitiesDTO), HttpStatusCode.OK);
        }

        public Response RespondWithEntitiyDTO<TEntity, TDTO>(INancyModule Module, TEntity Entity)
        where TEntity : Entity
        where TDTO : EntityDTO
        {
            var entityDTO = ConvertToDTO<TEntity, TDTO>(Entity);

            return Module.Response.AsJson<TDTO>(entityDTO, HttpStatusCode.OK);
        }

        public TDTO ConvertToDTO<TEntity, TDTO>(TEntity Entity)
        where TEntity : Entity
        where TDTO : EntityDTO
        {
            return this._mapper.Map<TEntity, TDTO>(Entity);
        }

        public IList<TDTO> ConvertToDTOs<TEntity, TDTO>(IEnumerable<TEntity> Entities)
        where TDTO : EntityDTO
        where TEntity : Entity
        {
            var entitiesDTO = new List<TDTO>();
            foreach (TEntity entity in Entities)
            {
                if (entity is ISoftDeletable && ((ISoftDeletable) entity).Deleted) continue;
                entitiesDTO.Add(this._mapper.Map<TEntity, TDTO>(entity));
            }
            return entitiesDTO;
        }
    }
}