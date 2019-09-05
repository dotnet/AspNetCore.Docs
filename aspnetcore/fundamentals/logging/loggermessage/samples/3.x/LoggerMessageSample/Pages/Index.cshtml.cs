using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LoggerMessageSample.Data;
using LoggerMessageSample.Internal;

namespace LoggerMessageSample.Pages
{
    public class IndexModel : PageModel
    {
        #region snippet1
        private readonly AppDbContext _db;
        private readonly ILogger _logger;

        public IndexModel(AppDbContext db, ILogger<IndexModel> logger)
        {
            _db = db;
            _logger = logger;
        }
        #endregion

        [BindProperty]
        public Quote Quote { get; set; }

        public IList<Quote> Quotes { get; private set; }

        #region snippet2
        public async Task OnGetAsync()
        {
            _logger.IndexPageRequested();

            Quotes = await _db.Quotes.AsNoTracking().ToListAsync();
        }
        #endregion

        #region snippet3
        public async Task<IActionResult> OnPostAddQuoteAsync()
        {
            _db.Quotes.Add(Quote);
            await _db.SaveChangesAsync();

            _logger.QuoteAdded(Quote.Text);

            return RedirectToPage();
        }
        #endregion

        #region snippet4
        public async Task<IActionResult> OnPostDeleteAllQuotesAsync()
        {
            var quoteCount = await _db.Quotes.CountAsync();

            using (_logger.AllQuotesDeletedScope(quoteCount))
            {
                foreach (Quote quote in _db.Quotes)
                {
                    _db.Quotes.Remove(quote);

                    _logger.QuoteDeleted(quote.Text, quote.Id);
                }
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        #endregion

        #region snippet5
        public async Task<IActionResult> OnPostDeleteQuoteAsync(int id)
        {
            try
            {
                var quote = await _db.Quotes.FindAsync(id);
                _db.Quotes.Remove(quote);
                await _db.SaveChangesAsync();

                _logger.QuoteDeleted(quote.Text, id);
            }
            catch (NullReferenceException ex)
            {
                _logger.QuoteDeleteFailed(id, ex);
            }

            return RedirectToPage();
        }
        #endregion
    }
}
