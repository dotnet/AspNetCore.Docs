namespace StaticFilesAuth;

public class JwtAuthenticationOptions
{
    public const string Options = "JwtAuthenticationOptions";

    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public string SymmetricSecurityKey { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public int TokenExpirationInMinutes { get; set; }
}
