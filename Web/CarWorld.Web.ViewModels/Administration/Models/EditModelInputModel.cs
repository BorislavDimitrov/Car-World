namespace CarWorld.Web.ViewModels.Administration.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditModelInputModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public int MakeId { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; }
    }
}
