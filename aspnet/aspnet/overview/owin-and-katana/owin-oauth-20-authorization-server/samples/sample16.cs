using Constants;
using DotNetOpenAuth.OAuth2;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace AuthorizationCodeGrant.Controllers
{
   public class HomeController : Controller
   {
      private WebServerClient _webServerClient;

      public ActionResult Index()
      {
         ViewBag.AccessToken = Request.Form["AccessToken"] ?? "";
         ViewBag.RefreshToken = Request.Form["RefreshToken"] ?? "";
         ViewBag.Action = "";
         ViewBag.ApiResponse = "";

         InitializeWebServerClient();
         var accessToken = Request.Form["AccessToken"];
         if (string.IsNullOrEmpty(accessToken))
         {
            var authorizationState = _webServerClient.ProcessUserAuthorization(Request);
            if (authorizationState != null)
            {
               ViewBag.AccessToken = authorizationState.AccessToken;
               ViewBag.RefreshToken = authorizationState.RefreshToken;
               ViewBag.Action = Request.Path;
            }
         }

         if (!string.IsNullOrEmpty(Request.Form.Get("submit.Authorize")))
         {
            var userAuthorization = _webServerClient.PrepareRequestUserAuthorization(new[] { "bio", "notes" });
            userAuthorization.Send(HttpContext);
            Response.End();
         }
         else if (!string.IsNullOrEmpty(Request.Form.Get("submit.Refresh")))
         {
            var state = new AuthorizationState
            {
               AccessToken = Request.Form["AccessToken"],
               RefreshToken = Request.Form["RefreshToken"]
            };
            if (_webServerClient.RefreshAuthorization(state))
            {
               ViewBag.AccessToken = state.AccessToken;
               ViewBag.RefreshToken = state.RefreshToken;
            }
         }
         else if (!string.IsNullOrEmpty(Request.Form.Get("submit.CallApi")))
         {
            var resourceServerUri = new Uri(Paths.ResourceServerBaseAddress);
            var client = new HttpClient(_webServerClient.CreateAuthorizingHandler(accessToken));
            var body = client.GetStringAsync(new Uri(resourceServerUri, Paths.MePath)).Result;
            ViewBag.ApiResponse = body;
         }

         return View();
      }

      private void InitializeWebServerClient()
      {
         var authorizationServerUri = new Uri(Paths.AuthorizationServerBaseAddress);
         var authorizationServer = new AuthorizationServerDescription
         {
            AuthorizationEndpoint = new Uri(authorizationServerUri, Paths.AuthorizePath),
            TokenEndpoint = new Uri(authorizationServerUri, Paths.TokenPath)
         };
         _webServerClient = new WebServerClient(authorizationServer, Clients.Client1.Id, Clients.Client1.Secret);
      }
   }
}