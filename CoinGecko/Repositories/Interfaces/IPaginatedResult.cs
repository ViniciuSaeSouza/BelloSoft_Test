namespace Domain.Interfaces
{
    public interface IPaginatedResult<T>
    {
        bool HasNext { get; }
        bool HasPrevious { get; }
        IEnumerable<T> Items { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
        int TotalPages { get; }
    }
}