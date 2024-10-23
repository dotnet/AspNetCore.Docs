using System.Text;
using Fido2NetLib;
using Fido2NetLib.Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpeniddictServer.Data;
using static Fido2NetLib.Fido2;

namespace Fido2Identity;

[Route("api/[controller]")]
public class MfaFido2RegisterController : Controller
{
    private readonly Fido2 _lib;
    public static IMetadataService? _mds;
    private readonly Fido2Store _fido2Store;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOptions<Fido2Configuration> _optionsFido2Configuration;

    public MfaFido2RegisterController(
        Fido2Store fido2Store,
        UserManager<ApplicationUser> userManager,
        IOptions<Fido2Configuration> optionsFido2Configuration)
    {
        _userManager = userManager;
        _optionsFido2Configuration = optionsFido2Configuration;
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
    [Route("/mfamakeCredentialOptions")]
    public async Task<JsonResult> MakeCredentialOptions([FromForm] string username, [FromForm] string displayName, [FromForm] string attType, [FromForm] string authType, [FromForm] bool requireResidentKey, [FromForm] string userVerification)
    {
        try
        {
            if (string.IsNullOrEmpty(username))
            {
                username = $"{displayName} (Usernameless user created at {DateTime.UtcNow})";
            }

            var ApplicationUser = await _userManager.FindByEmailAsync(username);
            var user = new Fido2User
            {
                DisplayName = ApplicationUser.UserName,
                Name = ApplicationUser.UserName,
                Id = Encoding.UTF8.GetBytes(ApplicationUser.UserName) // byte representation of userID is required
            };

            // 2. Get user existing keys by username
            var items = await _fido2Store.GetCredentialsByUserNameAsync(ApplicationUser.UserName);
            var existingKeys = new List<PublicKeyCredentialDescriptor>();
            foreach (var publicKeyCredentialDescriptor in items)
            {
                if (publicKeyCredentialDescriptor.Descriptor != null)
                    existingKeys.Add(publicKeyCredentialDescriptor.Descriptor);
            }

            // 3. Create options
            var authenticatorSelection = new AuthenticatorSelection
            {
                RequireResidentKey = requireResidentKey,
                UserVerification = userVerification.ToEnum<UserVerificationRequirement>()
            };

            if (!string.IsNullOrEmpty(authType))
                authenticatorSelection.AuthenticatorAttachment = authType.ToEnum<AuthenticatorAttachment>();

            var exts = new AuthenticationExtensionsClientInputs
            {
                Extensions = true,
                UserVerificationMethod = true,
            };

            var options = _lib.RequestNewCredential(
                user, existingKeys,
                authenticatorSelection, attType.ToEnum<AttestationConveyancePreference>(), exts);

            // 4. Temporarily store options, session/in-memory cache/redis/db
            HttpContext.Session.SetString("fido2.attestationOptions", options.ToJson());

            // 5. return options to client
            return Json(options);
        }
        catch (Exception e)
        {
            return Json(new CredentialCreateOptions { Status = "error", ErrorMessage = FormatException(e) });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/mfamakeCredential")]
    public async Task<JsonResult> MakeCredential([FromBody] AuthenticatorAttestationRawResponse attestationResponse)
    {
        try
        {
            // 1. get the options we sent the client
            var jsonOptions = HttpContext.Session.GetString("fido2.attestationOptions");
            var options = CredentialCreateOptions.FromJson(jsonOptions);

            // 2. Create callback so that lib can verify credential id is unique to this user
            async Task<bool> callback(IsCredentialIdUniqueToUserParams args, CancellationToken cancellationToken)
            {
                var users = await _fido2Store.GetUsersByCredentialIdAsync(args.CredentialId);
                if (users.Count > 0) return false;

                return true;
            }

            // 2. Verify and make the credentials
            var success = await _lib.MakeNewCredentialAsync(attestationResponse, options, callback);

            if (success.Result != null)
            {
                // 3. Store the credentials in db
                await _fido2Store.AddCredentialToUserAsync(options.User, new FidoStoredCredential
                {
                    UserName = options.User.Name,
                    Descriptor = new PublicKeyCredentialDescriptor(success.Result.CredentialId),
                    PublicKey = success.Result.PublicKey,
                    UserHandle = success.Result.User.Id,
                    SignatureCounter = success.Result.Counter,
                    CredType = success.Result.CredType,
                    RegDate = DateTime.Now,
                    AaGuid = success.Result.Aaguid
                });
            }

            // 4. return "ok" to the client

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new CredentialMakeResult("error",
                        $"Unable to load user with ID '{_userManager.GetUserId(User)}'.",
                        success.Result));
            }

            await _userManager.SetTwoFactorEnabledAsync(user, true);
            var userId = await _userManager.GetUserIdAsync(user);

            return Json(success);
        }
        catch (Exception e)
        {
            return Json(new CredentialMakeResult("error", FormatException(e), null));
        }
    }
}