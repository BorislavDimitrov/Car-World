using CarWorld.Data.Common.Models;
using System.Collections.Generic;

namespace CarWorld.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
