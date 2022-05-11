namespace CarWorld.Web.ViewModels.Cars
{
    using AutoMapper;
    using CarWorld.Data.Models;
    using CarWorld.Data.Models.Enums;
    using CarWorld.Web.Infrastructure.ValidationAttributes;
    using CarWorld.Web.ViewModels.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCarInputModel 
    {
        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(1, 1500)]
        public int HorsePower { get; set; }

        [Range(1, 5_000_000)]
        public int Price { get; set; }

        public int RegionId { get; set; }

        public CarType CarType { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public HandDrive HandDrive { get; set; }

        public EmissionClass EmissionClass { get; set; }

        public Transmission Transmission { get; set; }

        public Condition Condition { get; set; }

        public FuelType FuelType { get; set; }

        public DoorsCount DoorsCount { get; set; }

        public SeatsCount SeatsCount { get; set; }


        [Range(25, 200)]
        public int TankFuel { get; set; }

        [Required]
        [StringLength(15)]
        public string Color { get; set; }

        [StringLength(30)]
        [Display(Name = "City / Village")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Year")]
        [Range(1800, 2025)]
        public int CreationYear { get; set; }

        [Required]
        [Range(1, 5_000_000)]
        public int Mileage { get; set; }

        [Required]
        [Range(500, 9000)]
        public int CubicCapacity { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Thumbnail Image")]
        [FileSizeAndFormat(4, "jpg", "png", "jpeg")]
        public IFormFile? ThumbnailPicture { get; set; }

        [Display(Name = "Images of the car")]
        [MultiFilesSizeAndFormat(10, 4, "jpg", "png", "jpeg")]
        public List<IFormFile>? Pictures { get; set; } = new List<IFormFile>();

        public IEnumerable<SelectListItem> Makes { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Regions { get; set; } = new List<SelectListItem>();
        public IEnumerable<ModelsDropDown> Models { get; set; } = new List<ModelsDropDown>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CreateCarInputModel, Car>()
                .ForMember(x => x.CreatorId,
                opt => opt.MapFrom(x => x.UserId));
        }
    }
}
