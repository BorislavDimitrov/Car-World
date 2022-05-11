namespace CarWorld.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum DoorsCount
    {
        [Display(Name = "2/3")]
        TwoThree = 1,
        [Display(Name = "4/5")]
        FourFive = 2,
    }
}
