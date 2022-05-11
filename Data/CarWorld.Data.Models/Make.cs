namespace CarWorld.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarWorld.Data.Common.Models;

    public class Make : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; } = new HashSet<Model>();

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
