using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceBasedAuthApp1.Data;
using ResourceBasedAuthApp1.Models;
using ResourceBasedAuthApp1.Services;
using System;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp1.Controllers
{
    #region snippet_IAuthServiceDI
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
        #endregion

        #region snippet_DocumentViewAction
        [HttpGet]
        public async Task<IActionResult> View(Guid documentId)
        {
            Document document = _documentRepository.Find(documentId);

            if (document == null)
            {
                return new NotFoundResult();
            }

            if (await _authorizationService
                .AuthorizeAsync(User, document, Operations.Read))
            {
                return View(document);
            }
            else
            {
                return new ChallengeResult();
            }
        }
        #endregion

        #region snippet_DocumentEditAction
        [HttpGet]
        public async Task<IActionResult> Edit(Guid documentId)
        {
            Document document = _documentRepository.Find(documentId);

            if (document == null)
            {
                return new NotFoundResult();
            }

            if (await _authorizationService
                .AuthorizeAsync(User, document, "EditPolicy"))
            {
                return View(document);
            }
            else
            {
                return new ChallengeResult();
            }
        }
        #endregion

        public IActionResult Index() => View();
    }
}