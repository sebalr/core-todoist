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
            CreateMap<ItemState, ItemStateDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}