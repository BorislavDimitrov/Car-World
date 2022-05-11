namespace CarWorld.Web.ViewModels.Cars
{
    using AutoMapper;
    using CarWorld.Data.Models;
    using CarWorld.Data.Models.Enums;
    using CarWorld.Services.Mapping;
    using System;
    using System.Collections.Generic;

    public class DetailsCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string Title { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegionName { get; set; }

        public string City { get; set; }

        public int Price { get; set; }

        public int HorsePower { get; set; }

        public bool IsDeleted { get; set; }

        public CarType CarType { get; set; }

        public HandDrive HandDrive { get; set; }

        public int TankFuel { get; set; }

        public string Color { get; set; }

        public int CreationYear { get; set; }

        public int Mileage { get; set; }

        public EmissionClass EmissionClass { get; set; }

        public Transmission Transmission { get; set; }

        public Condition Condition { get; set; }

        public FuelType FuelType { get; set; }

        public int CubicCapacity { get; set; }

        public string? Description { get; set; }

        public DoorsCount DoorsCount { get; set; }

        public SeatsCount SeatsCount { get; set; }

        public string CreateDate { get; set; }

        public List<Picture> Pictures { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string CreatorImagePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, DetailsCarViewModel>()
                .ForMember(x => x.CreateDate, opt =>
                opt.MapFrom(x => x.CreateDate.ToString("MM/dd/yyyy")))
                .ForMember(x => x.UserName, opt =>
                opt.MapFrom(x => String.IsNullOrWhiteSpace(x.Creator.FirstName + " " + x.Creator.LastName) == false
                    ? x.Creator.FirstName + " " + x.Creator.LastName
                    : x.Creator.UserName));
        }
    }
}
