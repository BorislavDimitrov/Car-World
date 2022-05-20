using CarWorld.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < PagesCount;

        public int PreviousPageNumber => PageNumber - 1;

        public int NextPageNumber => PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)ItemsCount / ItemsPerPage);

        public string Search { get; set; }

        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? RegionId { get; set; }

        public string OrderBy { get; set; }

        public string UserId { get; set; }

        public List<SelectListItem> Makes { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Regions { get; set; } = new List<SelectListItem>();

        public List<ModelsDropDown> Models { get; set; } = new List<ModelsDropDown>();
    }
}