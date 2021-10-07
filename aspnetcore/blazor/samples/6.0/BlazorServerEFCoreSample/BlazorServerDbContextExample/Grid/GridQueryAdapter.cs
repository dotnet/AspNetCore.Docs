using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    public class GridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        private readonly IContactFilters _controls;

        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ContactFilterColumns, Expression<Func<Contact, string>>> _expressions
            = new()
            {
                { ContactFilterColumns.City, c => c != null && c.City != null ? c.City : string.Empty },
                { ContactFilterColumns.Phone, c => c != null && c.Phone != null ? c.Phone : string.Empty },
                { ContactFilterColumns.Name, c => c != null && c.LastName != null ? c.LastName : string.Empty },
                { ContactFilterColumns.State, c => c != null && c.State != null ? c.State : string.Empty },
                { ContactFilterColumns.Street, c => c != null && c.Street != null ? c.Street : string.Empty },
                { ContactFilterColumns.ZipCode, c => c != null && c.ZipCode != null ? c.ZipCode : string.Empty }
            };

        /// <summary>
        /// Queryables for filtering.
        /// </summary>
        private readonly Dictionary<ContactFilterColumns, Func<IQueryable<Contact>, IQueryable<Contact>>> _filterQueries = 
            new Dictionary<ContactFilterColumns, Func<IQueryable<Contact>, IQueryable<Contact>>>();

        /// <summary>
        /// Creates a new instance of the <see cref="GridQueryAdapter"/> class.
        /// </summary>
        /// <param name="controls">The <see cref="IContactFilters"/> to use.</param>
        public GridQueryAdapter(IContactFilters controls)
        {
            _controls = controls;

            // set up queries
            _filterQueries = new()
            {
                { ContactFilterColumns.City, cs => cs.Where(c => c != null && c.City != null && _controls.FilterText != null ? c.City.Contains(_controls.FilterText) : false ) },
                { ContactFilterColumns.Phone, cs => cs.Where(c => c != null && c.Phone != null && _controls.FilterText != null ? c.Phone.Contains(_controls.FilterText) : false ) },
                { ContactFilterColumns.Name, cs => cs.Where(c => c != null && c.FirstName != null && _controls.FilterText != null ? c.FirstName.Contains(_controls.FilterText) : false ) },
                { ContactFilterColumns.State, cs => cs.Where(c => c != null && c.State != null && _controls.FilterText != null ? c.State.Contains(_controls.FilterText) : false ) },
                { ContactFilterColumns.Street, cs => cs.Where(c => c != null && c.Street != null && _controls.FilterText != null ? c.Street.Contains(_controls.FilterText) : false ) },
                { ContactFilterColumns.ZipCode, cs => cs.Where(c => c != null && c.ZipCode != null && _controls.FilterText != null ? c.ZipCode.Contains(_controls.FilterText) : false ) }
            };
        }

        /// <summary>
        /// Uses the query to return a count and a page.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to work from.</param>
        /// <returns>The resulting <see cref="ICollection{Contact}"/>.</returns>
        public async Task<ICollection<Contact>> FetchAsync(IQueryable<Contact> query)
        {
            query = FilterAndQuery(query);
            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }

        /// <summary>
        /// Get total filtered items count.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to use.</param>
        /// <returns>Asynchronous <see cref="Task"/>.</returns>
        public async Task CountAsync(IQueryable<Contact> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        /// <summary>
        /// Build the query to bring back a single page.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to modify.</param>
        /// <returns>The new <see cref="IQueryable{Contact}"/> for a page.</returns>
        public IQueryable<Contact> FetchPageQuery(IQueryable<Contact> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <param name="root">The <see cref="IQueryable{Contact}"/> to start with.</param>
        /// <returns>
        /// The resulting <see cref="IQueryable{Contact}"/> with sorts and
        /// filters applied.
        /// </returns>
        private IQueryable<Contact> FilterAndQuery(IQueryable<Contact> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?
            if (!string.IsNullOrWhiteSpace(_controls.FilterText))
            {
                var filter = _filterQueries[_controls.FilterColumn];
                sb.Append($"Filter: '{_controls.FilterColumn}' ");
                root = filter(root);
            }

            // apply the expression
            var expression = _expressions[_controls.SortColumn];
            sb.Append($"Sort: '{_controls.SortColumn}' ");

            // fix up name
            if (_controls.SortColumn == ContactFilterColumns.Name && _controls.ShowFirstNameFirst)
            {
                sb.Append($"(first name first) ");
                expression = c => c.FirstName != null ? c.FirstName : string.Empty;
            }

            var sortDir = _controls.SortAscending ? "ASC" : "DESC";
            sb.Append(sortDir);

            Debug.WriteLine(sb.ToString());
            // return the unfiltered query for total count, and the filtered for fetching
            return _controls.SortAscending ? root.OrderBy(expression)
                : root.OrderByDescending(expression);
        }
    }
}
