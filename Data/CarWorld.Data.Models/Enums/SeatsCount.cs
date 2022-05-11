namespace CarWorld.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum SeatsCount
    {
        [Display(Name = "2")]
        Two = 1,
        [Display(Name = "4")]
        Four = 2,
        [Display(Name = "4+")]
        MoreThanFour = 3,
    }
}
