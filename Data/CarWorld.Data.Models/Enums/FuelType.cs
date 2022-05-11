namespace CarWorld.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum FuelType
    {
        Diesel = 1,
        Petrol = 2,
        Hybrid = 3,
        [Display(Name = "Petrol / LPG")]
        PetrolLPG = 4,
        Electric = 5,
    }
}
