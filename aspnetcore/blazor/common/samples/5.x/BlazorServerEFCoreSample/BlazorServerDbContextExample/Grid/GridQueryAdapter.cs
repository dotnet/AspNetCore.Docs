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
                { ContactFilterColumns.City, c => c.City },
                { ContactFilterColumns.Phone, c => c.Phone },
                { ContactFilterColumns.Name, c => c.LastName },
                { ContactFilterColumns.State, c => c.State },
                { ContactFilterColumns.Street, c => c.Street },
                { ContactFilterColumns.ZipCode, c => c.ZipCode }
            };

        /// <summary>
        /// Queryables for filtering.
        /// </summary>
        private readonly Dictionary<ContactFilterColumns, Func<IQueryable<Contact>, IQueryable<Contact>>> _filterQueries;

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
                { ContactFilterColumns.City, cs => cs.Where(c => c.City.Contains(_controls.FilterText)) },
                { ContactFilterColumns.Phone, cs => cs.Where(c => c.Phone.Contains(_controls.FilterText)) },
                { ContactFilterColumns.Name, cs => cs.Where(c => c.FirstName.Contains(_controls.FilterText) || c.LastName.Contains(_controls.FilterText)) },
                { ContactFilterColumns.State, cs => cs.Where(c => c.State.Contains(_controls.FilterText)) },
                { ContactFilterColumns.Street, cs => cs.Where(c => c.Street.Contains(_controls.FilterText)) },
                { ContactFilterColumns.ZipCode, cs => cs.Where(c => c.ZipCode.Contains(_controls.FilterText)) }
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
                expression = c => c.FirstName;
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
