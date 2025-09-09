### ASP.NET Core Identity metrics

<xref:security/authentication/identity> observability has been improved in .NET 10 with metrics. Metrics are counters, histograms and gauges that provide time-series measurements of system or application behavior.

For example, you can use the new ASP.NET Core Identity metrics to observe:

* **User management**: New user creations, password changes, and role assignments.
* **Login/session handling**: Login attempts, sign ins and sign outs, and users using two factor authentication.

The new metrics are in the `Microsoft.AspNetCore.Identity` meter:

* `aspnetcore.identity.user.create.duration`
* `aspnetcore.identity.user.update.duration`
* `aspnetcore.identity.user.delete.duration`
* `aspnetcore.identity.user.check_password_attempts`
* `aspnetcore.identity.user.generated_tokens`
* `aspnetcore.identity.user.verify_token_attempts`
* `aspnetcore.identity.sign_in.authenticate.duration`
* `aspnetcore.identity.sign_in.check_password_attempts`
* `aspnetcore.identity.sign_in.sign_ins`
* `aspnetcore.identity.sign_in.sign_outs`
* `aspnetcore.identity.sign_in.two_factor_clients_remembered`
* `aspnetcore.identity.sign_in.two_factor_clients_forgotten`

For more information about using metrics in ASP.NET Core, see <xref:log-mon/metrics/metrics>.
