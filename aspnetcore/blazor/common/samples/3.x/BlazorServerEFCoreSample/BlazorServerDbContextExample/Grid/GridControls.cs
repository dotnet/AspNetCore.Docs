namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// State of grid filters.
    /// </summary>
    public class GridControls : IContactFilters
    {
        /// <summary>
        /// Keep state of paging.
        /// </summary>
        public IPageHelper PageHelper { get; set; }

        public GridControls(IPageHelper pageHelper)
        {
            PageHelper = pageHelper;
        }

        /// <summary>
        /// Avoid multiple concurrent requests.
        /// </summary>
        public bool Loading { get; set; }

        /// <summary>
        /// Firstname Lastname, or Lastname, Firstname.
        /// </summary>
        public bool ShowFirstNameFirst { get; set; }

        /// <summary>
        /// Column to sort by.
        /// </summary>
        public ContactFilterColumns SortColumn { get; set; }
            = ContactFilterColumns.Name;

        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
        public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
        public ContactFilterColumns FilterColumn { get; set; }
            = ContactFilterColumns.Name;

        /// <summary>
        /// Text to filter on.
        /// </summary>
        public string FilterText { get; set; }
    }
}
