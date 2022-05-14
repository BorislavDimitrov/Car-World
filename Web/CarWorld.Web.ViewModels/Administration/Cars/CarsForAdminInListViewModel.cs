namespace CarWorld.Web.ViewModels.Administration.Cars
{
    using System;
    using AutoMapper;
    using CarWorld.Data.Models;
    using CarWorld.Data.Models.Enums;
    using CarWorld.Services.Mapping;

    public class CarsForAdminInListViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public string UserName { get; set; }

        public int HorsePower { get; set; }

        public CarType CarType { get; set; }

        public string City { get; set; }

        public string Color { get; set; }

        public int Mileage { get; set; }

        public string CreateDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarsForAdminInListViewModel>()
                .ForMember(x => x.CreateDate, opt =>
                opt.MapFrom(x => x.CreateDate.ToString("MM/dd/yyyy")))
                .ForMember(x => x.UserName, opt =>
                opt.MapFrom(x => !String.IsNullOrWhiteSpace(x.Creator.FirstName + " " + x.Creator.LastName) ?
                x.Creator.FirstName + " " + x.Creator.LastName :
                x.Creator.UserName));
        }
    }
}
