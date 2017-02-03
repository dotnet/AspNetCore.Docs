[Authorize]
public async Task UserProfile()
{
	string tenantId = ClaimsPrincipal.Current.FindFirst(TenantIdClaimType).Value;

	// Get a token for calling the Azure Active Directory Graph
	AuthenticationContext authContext = new AuthenticationContext(String.Format(CultureInfo.InvariantCulture, LoginUrl, tenantId));
	ClientCredential credential = new ClientCredential(AppPrincipalId, AppKey);
	AuthenticationResult assertionCredential = authContext.AcquireToken(GraphUrl, credential);
	string authHeader = assertionCredential.CreateAuthorizationHeader();
	string requestUrl = String.Format(
		CultureInfo.InvariantCulture,
		GraphUserUrl,
		HttpUtility.UrlEncode(tenantId),
		HttpUtility.UrlEncode(User.Identity.Name));

	HttpClient client = new HttpClient();
	HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
	request.Headers.TryAddWithoutValidation("Authorization", authHeader);
	HttpResponseMessage response = await client.SendAsync(request);
	string responseString = await response.Content.ReadAsStringAsync();
	UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseString);

	return View(profile);
}