namespace CarWorld.Web.ViewModels.Paging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    public class PaginationList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }

        public PaginationList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool NextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public static async Task<PaginationList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationList<T>(items, count, pageIndex, pageSize);
        }
    }
}
