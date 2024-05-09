namespace API.Helpers
{
    public class Pagination<T>
    {
        public Pagination(int pageIndex, int count, int pageSize, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            Count = count;
            PageSize = pageSize;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; } = [];
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((decimal)Count / PageSize);
            }
        }
    }
}
