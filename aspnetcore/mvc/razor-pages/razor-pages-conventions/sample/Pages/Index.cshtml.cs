using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelProvidersSample.Data;
using Microsoft.EntityFrameworkCore;

namespace ModelProvidersSample.Pages
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

        public IList<Message> Messages { get; private set; }

        [TempData]
        public string Result { get; set; }

        #region snippet1
        public async Task Get()
        {
            Messages = await _db.Messages.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> PostMessageAsync()
        {
            _db.Messages.Add(Message);
            await _db.SaveChangesAsync();

            Result = $"{nameof(PostMessageAsync)} handler: Message '{Message.Text}' added.";

            return RedirectToPage();
        }

        public async Task<IActionResult> DeleteAllMessages()
        {
            foreach (Message message in _db.Messages)
            {
                _db.Messages.Remove(message);
            }
            await _db.SaveChangesAsync();

            Result = $"{nameof(DeleteAllMessages)} handler: All messages deleted.";

            return RedirectToPage();
        }

        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            var message = await _db.Messages.FindAsync(id);

            if (message != null)
            {
                _db.Messages.Remove(message);
                await _db.SaveChangesAsync();
            }

            Result = $"{nameof(DeleteMessageAsync)} handler: Message with Id: {id} deleted.";

            return RedirectToPage();
        }
        #endregion
    }
}
