using CarWorld.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            Items = new HashSet<Item>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string PicturePath { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
