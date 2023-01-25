using CarWorld.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorld.Data.Models
{
    public class Cart : BaseModel<int>
    {
        public Cart()
        {
            Items = new HashSet<Item>();
        }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
