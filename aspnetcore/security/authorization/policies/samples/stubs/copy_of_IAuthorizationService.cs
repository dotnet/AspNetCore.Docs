﻿// THIS IS A COPY OF https://github.com/aspnet/AspNetCore/blob/v2.2.4/src/Security/Authorization/Core/src/IAuthorizationService.cs
// USED FOR DOCUMENTAION
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    // <snippet>
    /// <summary>
    /// Checks policy based permissions for a user
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Checks if a user meets a specific set of requirements for the specified resource
        /// </summary>
        /// <param name="user">The user to evaluate the requirements against.</param>
        /// <param name="resource">
        /// An optional resource the policy should be checked with.
        /// If a resource is not required for policy evaluation you may pass null as the value
        /// </param>
        /// <param name="requirements">The requirements to evaluate.</param>
        /// <returns>
        /// A flag indicating whether authorization has succeeded.
        /// This value is <value>true</value> when the user fulfills the policy; 
        /// otherwise <value>false</value>.
        /// </returns>
        /// <remarks>
        /// Resource is an optional parameter and may be null. Please ensure that you check 
        /// it is not null before acting upon it.
        /// </remarks>
        Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, 
                                         IEnumerable<IAuthorizationRequirement> requirements);

        /// <summary>
        /// Checks if a user meets a specific authorization policy
        /// </summary>
        /// <param name="user">The user to check the policy against.</param>
        /// <param name="resource">
        /// An optional resource the policy should be checked with.
        /// If a resource is not required for policy evaluation you may pass null as the value
        /// </param>
        /// <param name="policyName">The name of the policy to check against a specific 
        /// context.</param>
        /// <returns>
        /// A flag indicating whether authorization has succeeded.
        /// Returns a flag indicating whether the user, and optional resource has fulfilled 
        /// the policy.    
        /// <value>true</value> when the policy has been fulfilled; 
        /// otherwise <value>false</value>.
        /// </returns>
        /// <remarks>
        /// Resource is an optional parameter and may be null. Please ensure that you check
        /// it is not null before acting upon it.
        /// </remarks>
        Task<AuthorizationResult> AuthorizeAsync(
                                    ClaimsPrincipal user, object resource, string policyName);
    }
    // </snippet>
}