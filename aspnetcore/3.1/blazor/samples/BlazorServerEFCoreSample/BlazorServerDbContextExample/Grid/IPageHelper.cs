namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// To keep these consistent.
    /// </summary>
    public interface IPageHelper
    {
        /// <summary>
        /// Current page, 0-based.
        /// </summary>
        int DbPage { get; }

        /// <summary>
        /// Current page, 1-based.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Previous page, 1-based.
        /// </summary>
        int PrevPage { get; }

        /// <summary>
        /// Next page, 1-based.
        /// </summary>
        int NextPage { get; }

        /// <summary>
        /// <c>true</c> when a previous page exists.
        /// </summary>
        bool HasPrev { get; }

        /// <summary>
        /// <c>true</c> when a next page exists.
        /// </summary>
        bool HasNext { get; }

        /// <summary>
        /// Total page count.
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// Items on current page.
        /// </summary>
        int PageItems { get; set; }

        /// <summary>
        /// Items per page.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// How many items to skip.
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Total items based on filter.
        /// </summary>
        int TotalItemCount { get; set; }
    }
}
