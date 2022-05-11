namespace CarWorld.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Condition
    {
        New = 1,
        Used = 2,
        [Display(Name = "After crash")]
        AfterCrash = 3,
        [Display(Name = "For Parts")]
        ForParts = 4,
    }
}
