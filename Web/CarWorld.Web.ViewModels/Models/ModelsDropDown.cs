using AutoMapper;
using CarWorld.Data.Models;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Models
{
    public class ModelsDropDown : IMapFrom<Model>, IHaveCustomMappings
    {
        public int? ModelId { get; set; }

        public string ModelName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Model, ModelsDropDown>()
                .ForMember(x => x.ModelId, opt =>
                opt.MapFrom(x => x.Id))
                .ForMember(x => x.ModelName, opt =>
                opt.MapFrom(x => x.Name));
        }
    }
}
