namespace iShipping.Ly.Application.Dtos
{
    public class Response<TItem> where TItem : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public IReadOnlyList<TItem> Results { get; set; } = Array.Empty<TItem>();
    }
}
