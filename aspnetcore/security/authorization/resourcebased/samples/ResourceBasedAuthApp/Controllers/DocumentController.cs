using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceBasedAuthApp.Data;
using ResourceBasedAuthApp.Models;
using System;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IAuthorizationService authorizationService,
            IDocumentRepository documentRepository)
        {
            _authorizationService = authorizationService;
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid documentId)
        {
            Document document = _documentRepository.Find(documentId);

            if (document == null)
            {
                return new NotFoundResult();
            }

            if ((await _authorizationService.AuthorizeAsync(User, document, "EditPolicy")).Succeeded)
            {
                return View(document);
            }
            else
            {
                return new ChallengeResult();
            }
        }

        public IActionResult Index() => View();
    }
}