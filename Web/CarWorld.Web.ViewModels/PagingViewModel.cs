namespace CarWorld.Web.ViewModels.Cars
{
    using System;

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
    }
}