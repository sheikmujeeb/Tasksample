using Microsoft.EntityFrameworkCore;
namespace Tasksample.Models
{
    public class PageModel<T>:List<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; private set; }

        public PageModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;

        }
        public bool HasPerviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);


        //public int FirstItem => (PageIndex - 1) * PageSize + 1;
        //public int LastItem => Math.Min(PageIndex * PageSize, TotalItems);

        public static PageModel<T> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PageModel<T>(items, count, pageIndex, pageSize);
        }
    }
}
