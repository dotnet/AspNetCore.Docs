using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChangeTokenSample.Data;
using ChangeTokenSample.Enums;
using ChangeTokenSample.Extensions;
using System.Threading;
using Microsoft.Extensions.Primitives;
using static ChangeTokenSample.ChangeTokens.ChangeTokens;

namespace ChangeTokenSample.Pages
{
    public class ObjectWatchingModel : PageModel
    {
        private readonly AppDbContext _db;

        public ObjectWatchingModel(AppDbContext db)
        {
            _db = db;
        }

        public string LastMessageChangeType { get; private set; }

        [BindProperty]
        public Message Message { get; set; }

        public IList<Message> Messages { get; private set; }

        public async Task OnGetAsync()
        {
            switch (ChangeTokens.ChangeTokens.LastMessageChangeType)
            {
                case MessageChangeType.Add:
                    LastMessageChangeType = "A message was added.";
                    ViewData["LastMessageChangeTypeStyle"] = "success";
                    break;
                case MessageChangeType.Delete:
                    LastMessageChangeType = "A message was deleted.";
                    ViewData["LastMessageChangeTypeStyle"] = "warning";
                    break;
                case MessageChangeType.DeleteAll:
                    LastMessageChangeType = "All messages were deleted.";
                    ViewData["LastMessageChangeTypeStyle"] = "danger";
                    break;
                default:
                    LastMessageChangeType = "No changes have been made.";
                    ViewData["LastMessageChangeTypeStyle"] = "default";
                    break;
            }
            
            Messages = await _db.Messages.AsNoTracking().ToListAsync();
        }

        #region snippet1
        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            ChangeTokens.ChangeTokens.MessageChangeToken.Changed(MessageChangeType.Add);

            _db.Messages.Add(Message);
            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
        #endregion

        public async Task<IActionResult> OnPostDeleteAllMessagesAsync()
        {
            #region snippet2
            ChangeTokens.ChangeTokens.MessageChangeToken.Changed(MessageChangeType.DeleteAll);
            #endregion

            foreach (Message message in _db.Messages)
            {
                _db.Messages.Remove(message);
            }
            await _db.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            #region snippet3
            ChangeTokens.ChangeTokens.MessageChangeToken.Changed(MessageChangeType.Delete);
            #endregion

            var message = await _db.Messages.FindAsync(id);

            if (message != null)
            {
                _db.Messages.Remove(message);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
