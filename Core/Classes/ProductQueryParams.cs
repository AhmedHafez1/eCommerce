namespace Core.Classes
{
    public class ProductQueryParams
    {
        private const int _maxPageSize = 50;
        private int _pageSize = 6;
        private string? _search;

        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > _maxPageSize ? _maxPageSize : value;
            }
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value?.ToLower();
            }
        }
    }
}
