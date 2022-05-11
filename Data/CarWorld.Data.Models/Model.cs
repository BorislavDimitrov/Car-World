namespace CarWorld.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarWorld.Data.Common.Models;

    public class Model : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
