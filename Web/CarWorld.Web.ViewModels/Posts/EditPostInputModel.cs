using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Posts
{
    public class EditPostInputModel : IMapFrom<Post>, IMapTo<Post>
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
