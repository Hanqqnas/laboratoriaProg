namespace laboratoriaProg.Models.Paging
{
    public class PagingListAsync<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public bool IsPrevious { get; set; }
        public bool IsNext { get; set; }

        public static PagingListAsync<T> Create(
            Func<int, int, IEnumerable<T>> fetchData,
            int totalItems,
            int currentPage,
            int pageSize)
        {
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            return new PagingListAsync<T>
            {
                Data = fetchData(currentPage, pageSize),
                Page = currentPage,
                Size = pageSize,
                TotalPages = totalPages,
                IsPrevious = currentPage > 1,
                IsNext = currentPage < totalPages
            };
        }
    }
}