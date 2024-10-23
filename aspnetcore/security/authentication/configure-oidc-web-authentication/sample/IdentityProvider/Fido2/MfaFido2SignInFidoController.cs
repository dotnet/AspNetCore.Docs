using System.Text;
using Fido2NetLib;
using Fido2NetLib.Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpeniddictServer.Data;

namespace Fido2Identity;

[Route("api/[controller]")]
public class MfaFido2SignInFidoController : Controller
{
    private readonly Fido2 _lib;
    private readonly Fido2Store _fido2Store;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IOptions<Fido2Configuration> _optionsFido2Configuration;

    public MfaFido2SignInFidoController(
        Fido2Store fido2Store,
        SignInManager<ApplicationUser> signInManager,
        IOptions<Fido2Configuration> optionsFido2Configuration)
    {
        _optionsFido2Configuration = optionsFido2Configuration;
        _signInManager = signInManager;
        _fido2Store = fido2Store;

        _lib = new Fido2(new Fido2Configuration()
        {
            ServerDomain = _optionsFido2Configuration.Value.ServerDomain,
            ServerName = _optionsFido2Configuration.Value.ServerName,
            Origins = _optionsFido2Configuration.Value.Origins,
            TimestampDriftTolerance = _optionsFido2Configuration.Value.TimestampDriftTolerance
        });
    }

    private static string FormatException(Exception e)
    {
        return string.Format("{0}{1}", e.Message, e.InnerException != null ? " (" + e.InnerException.Message + ")" : "");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/mfaassertionOptions")]
    public async Task<ActionResult> AssertionOptionsPost([FromForm] string username, [FromForm] string userVerification)
    {
        try
        {
            var ApplicationUser = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (ApplicationUser == null)
            {
                throw new InvalidOperationException($"Unable to load two-factor authentication user.");
            }

            var existingCredentials = new List<PublicKeyCredentialDescriptor>();

            if (!string.IsNullOrEmpty(ApplicationUser.UserName))
            {

                var user = new Fido2User
                {
                    DisplayName = ApplicationUser.UserName,
                    Name = ApplicationUser.UserName,
                    Id = Encoding.UTF8.GetBytes(ApplicationUser.UserName) // byte representation of userID is required
                };

                if (user == null) throw new ArgumentException("Username was not registered");

                // 2. Get registered credentials from database
                var items = await _fido2Store.GetCredentialsByUserNameAsync(ApplicationUser.UserName);
                existingCredentials = items.Select(c => c.Descriptor).NotNull().ToList();
            }

            var exts = new AuthenticationExtensionsClientInputs
            {
                UserVerificationMethod = true,
            };
            // 3. Create options
            var uv = string.IsNullOrEmpty(userVerification) ? UserVerificationRequirement.Discouraged : userVerification.ToEnum<UserVerificationRequirement>();
            var options = _lib.GetAssertionOptions(
                existingCredentials,
                uv,
                exts
            );

            // 4. Temporarily store options, session/in-memory cache/redis/db
            HttpContext.Session.SetString("fido2.assertionOptions", options.ToJson());

            // 5. Return options to client
            return Json(options);
        }

        catch (Exception e)
        {
            return Json(new AssertionOptions { Status = "error", ErrorMessage = FormatException(e) });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/mfamakeAssertion")]
    public async Task<JsonResult> MakeAssertion([FromBody] AuthenticatorAssertionRawResponse clientResponse)
    {
        try
        {
            // 1. Get the assertion options we sent the client
            var jsonOptions = HttpContext.Session.GetString("fido2.assertionOptions");
            var options = AssertionOptions.FromJson(jsonOptions);

            // 2. Get registered credential from database
            var creds = await _fido2Store.GetCredentialByIdAsync(clientResponse.Id);

            if (creds == null)
            {
                throw new Exception("Unknown credentials");
            }

            // 3. Get credential counter from database
            var storedCounter = creds.SignatureCounter;

            // 4. Create callback to check if userhandle owns the credentialId
            IsUserHandleOwnerOfCredentialIdAsync callback = async (args, cancellationToken) =>
            {
                var storedCreds = await _fido2Store.GetCredentialsByUserHandleAsync(args.UserHandle);
                return storedCreds.Any(c => c.Descriptor != null && c.Descriptor.Id.SequenceEqual(args.CredentialId));
            };

            if (creds.PublicKey == null)
            {
                throw new InvalidOperationException($"No public key");
            }

            // 5. Make the assertion
            var res = await _lib.MakeAssertionAsync(
                clientResponse, options, creds.PublicKey, storedCounter, callback);

            // 6. Store the updated counter
            await _fido2Store.UpdateCounterAsync(res.CredentialId, res.Counter);

            // complete sign-in
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Unable to load two-factor authentication user.");
            }

            var result = await _signInManager.TwoFactorSignInAsync("FIDO2", string.Empty, false, false);

            // 7. return OK to client
            return Json(res);
        }
        catch (Exception e)
        {
            return Json(new AssertionVerificationResult { Status = "error", ErrorMessage = FormatException(e) });
        }
    }
}
