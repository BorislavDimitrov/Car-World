namespace CarWorld.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum EmissionClass
    {
        [Display(Name = "Euro - 1")]
        Euro1 = 1,
        [Display(Name = "Euro - 2")]
        Euro2 = 2,
        [Display(Name = "Euro - 3")]
        Euro3 = 3,
        [Display(Name = "Euro - 4")]
        Euro4 = 4,
        [Display(Name = "Euro - 5 ")]
        Euro5 = 5,
        [Display(Name = "Euro - 6")]
        Euro6 = 6,
    }
}
