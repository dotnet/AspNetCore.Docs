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

        [HttpGet]
		[AllowAnonymous]
        public async Task<IActionResult> Test()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            Guid userId = user.Id; // No cast here, the data type of the identifier of the user is Guid
            throw new NotImplementedException();
        }
    }
}
