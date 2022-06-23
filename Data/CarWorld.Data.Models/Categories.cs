using CarWorld.Data.Common.Models;

namespace CarWorld.Data.Models
{
    public class Categories : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
