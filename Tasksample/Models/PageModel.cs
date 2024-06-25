using Microsoft.EntityFrameworkCore;
namespace Tasksample.Models
{
    public class PageModel<T>:List<T>
    {
        public int PageIndex { get; }
        public int TotalPages { get; }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
        public PageModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }

        public static PageModel<T> Create(List<T> source, int pageIndex, int pageSize,int totalcount)
        {
            return new PageModel<T>(source, totalcount, pageIndex, pageSize);
        }
    }
}
