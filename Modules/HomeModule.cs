using System;
using AutoMapper;
using Nancy;
using Nancy.Security;
using todoist.DTOs;
using todoist.Entities;
using todoist.Persistance;
using todoist.Persistance.finders;
using todoist.Persistance.Finders;

namespace todoist.modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(UserFinder userFinder, CategoryFinder categoryFinder, IMapper mapper)
        { 
            
            // this.RequiresAuthentication();
            
            Get("/", _ =>
            {
                var users = userFinder.GetById(1);

                var cat = categoryFinder.GetById(1);

                var catDTO = mapper.Map<CategoryDTO>(cat);

                var state = new ItemStateDTO(){
                    Id = 1
                };

                var iten = new ItemDTO(){
                    Body = "ad",
                    ItemState = state,
                    Creation = DateTime.Now
                };

                var item = mapper.Map<ItemDTO,Item>(iten);

                return Response.AsJson(catDTO);
            });

        }
    }
}