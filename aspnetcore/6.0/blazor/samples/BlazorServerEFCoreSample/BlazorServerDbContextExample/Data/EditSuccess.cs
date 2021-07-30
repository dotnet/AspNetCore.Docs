namespace BlazorServerDbContextExample.Data
{
    /// <summary>
    /// Service to communicate success status between pages.
    /// </summary>
    public class EditSuccess
    {
        /// <summary>
        /// <c>true</c> when the last edit operation was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
