using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Message Message { get; set; }

        public IReadOnlyList<Message> Messages { get; private set; }

        [TempData]
        public string Result { get; set; }

        #region snippet1
        public async Task OnGetAsync()
        {
            Messages = await _db.Messages.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            _db.Messages.Add(Message);
            await _db.SaveChangesAsync();

            Result = $"{nameof(OnPostAddMessageAsync)} handler: Message '{Message.Text}' added.";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAllMessagesAsync()
        {
            foreach (Message message in _db.Messages)
            {
                _db.Messages.Remove(message);
            }
            await _db.SaveChangesAsync();

            Result = $"{nameof(OnPostDeleteAllMessagesAsync)} handler: All messages deleted.";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            var message = await _db.Messages.FindAsync(id);

            if (message != null)
            {
                _db.Messages.Remove(message);
                await _db.SaveChangesAsync();
            }

            Result = $"{nameof(OnPostDeleteMessageAsync)} handler: Message with Id: {id} deleted.";

            return RedirectToPage();
        }
        #endregion
    }
}
