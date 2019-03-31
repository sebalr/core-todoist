using AutoMapper;
using todoist.DTOs;
using todoist.Entities;

namespace todoist.Infraestructure.Automapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>()
                .ForMember(dest => dest.ItemState, opt => opt.MapFrom<EntityResolver<ItemStateDTO,ItemState>, ItemStateDTO>(src => src.ItemState));
            CreateMap<ItemState, ItemStateDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}