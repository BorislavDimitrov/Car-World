namespace CarWorld.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum CarType
    {
        Sedan = 1,
        Cabriolet = 2,
        SUV = 3,
        Van = 4,
        Hatchback = 6,
        [Display(Name = "Station Wagon")]
        StationWagon = 7,
    }
}
