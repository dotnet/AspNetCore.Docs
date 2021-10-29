using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPoliciesSample.Policies.Requirements;

public class ReadPermission : IAuthorizationRequirement
{
    // Code omitted for brevity
}

public class EditPermission : IAuthorizationRequirement
{
    // Code omitted for brevity
}

public class DeletePermission : IAuthorizationRequirement
{
    // Code omitted for brevity
}
