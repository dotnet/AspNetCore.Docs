using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using webapptemplate.Models;
using webapptemplate.Services;
using webapptemplate.ViewModels.Account;

namespace webapptemplate.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        #region snippet_GetCurrentUserId
        [HttpGet]
        [AllowAnonymous]
        public async Task<Guid> GetCurrentUserId()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            return user.Id; // No need to cast here because user.Id is already a Guid, and not a string
        }
        #endregion
    }
}
