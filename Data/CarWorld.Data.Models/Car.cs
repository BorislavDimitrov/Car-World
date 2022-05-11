namespace CarWorld.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarWorld.Data.Common.Models;
    using CarWorld.Data.Models.Enums;

    public class Car : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(1, 5_000_000)]
        public int Price { get; set; }

        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }

        [Required]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public Model Model { get; set; }

        [Range(1, 1500)]
        public int HorsePower { get; set; }

        [Required]
        public CarType CarType { get; set; }

        [Required]
        public HandDrive HandDrive { get; set; }

        [Range(25, 200)]
        public int TankFuel { get; set; }

        [Required]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; }

        [StringLength(30)]
        [Display(Name = "City / Village")]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string Color { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(1800, 2025)]
        public int CreationYear { get; set; }

        [Required]
        [Range(1, 5_000_000)]
        public int Mileage { get; set; }

        public EmissionClass EmissionClass { get; set; }

        public Transmission Transmission { get; set; }

        public Condition Condition { get; set; }

        public FuelType FuelType { get; set; }

        [Required]
        [Range(500, 9000)]
        public int CubicCapacity { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DoorsCount DoorsCount { get; set; }

        [Required]
        public SeatsCount SeatsCount { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; }

        public string ThumbnailPicturePath { get; set; }

        public List<Picture> Pictures { get; set; } = new List<Picture>();

        // public IList<ApplicationUser> InterestedUsers { get; set; } = new List<ApplicationUser>();
    }
}
