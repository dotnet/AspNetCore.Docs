namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// Because math is hard. Holds the state for paging.
    /// </summary>
    public class PageHelper : IPageHelper
    {
        /// <summary>
        /// Items on a page.
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Current page, 1-based.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// <c>true</c> when previous page exists.
        /// </summary>
        public bool HasPrev => Page > 1;

        /// <summary>
        /// Previous page number.
        /// </summary>
        public int PrevPage => Page <= 1 ? Page : Page - 1;

        /// <summary>
        /// <c>true</c> when next page exists.
        /// </summary>
        public bool HasNext => Page < PageCount;

        /// <summary>
        /// Next page number.
        /// </summary>
        public int NextPage => Page < PageCount ? Page + 1 : Page;

        /// <summary>
        /// Total items across all pages.
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// Items on the current page (should be less than or equal to
        /// <see cref="PageSize"/>).
        /// </summary>
        public int PageItems { get; set; }

        /// <summary>
        /// Current page, 0-based.
        /// </summary>
        public int DbPage => Page - 1;

        /// <summary>
        /// How many records to skip to start current page.
        /// </summary>
        public int Skip => PageSize * DbPage;

        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int PageCount => (TotalItemCount + PageSize - 1) / PageSize;
    }
}
