using System.ComponentModel.DataAnnotations;

namespace CarWorld.Data.Models.Enums
{
    public enum ReportType
    {       
        Scam = 1,
        [Display(Name = "Inappropriate Language")]
        InappropriateLanguage = 2,
    }
}
