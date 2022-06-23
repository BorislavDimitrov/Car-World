using CarWorld.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorld.Data.Models
{
    public class Post : BaseDeletableModel<int>
    {
       
        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
