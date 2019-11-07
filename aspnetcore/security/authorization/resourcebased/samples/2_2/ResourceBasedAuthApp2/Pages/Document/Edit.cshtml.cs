using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResourceBasedAuthApp2.Data;
using System;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp2.Pages.Document
{
    public class EditModel : PageModel
    {
        public Models.Document Document { get; private set; }

        private readonly IAuthorizationService _authorizationService;
        private readonly IDocumentRepository _documentRepository;

        public EditModel(IAuthorizationService authorizationService,
                         IDocumentRepository documentRepository)
        {
            _authorizationService = authorizationService;
            _documentRepository = documentRepository;
        }

        #region snippet_DocumentEditHandler
        public async Task<IActionResult> OnGetAsync(Guid documentId)
        {
            Document = _documentRepository.Find(documentId);

            if (Document == null)
            {
                return new NotFoundResult();
            }

            var authorizationResult = await _authorizationService
                    .AuthorizeAsync(User, Document, "EditPolicy");

            if (authorizationResult.Succeeded)
            {
                return Page();
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
        #endregion
    }
}