using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Posts
{
    public class CreatePostInputModel : IMapTo<Post>
    {
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
