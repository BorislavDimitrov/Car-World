namespace CarWorld.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Transmission
    {
        Automatic = 1,
        Manual = 2,
        [Display(Name = "Semi Automatic")]
        SemiAutomatic = 3,
    }
}
