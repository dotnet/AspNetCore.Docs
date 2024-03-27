:::moniker range=">= aspnetcore-9.0"

> [!WARNING]
> With compression, which is enabled by default, avoid creating secure (authenticated/authorized) interactive server-side components that render data from untrusted sources. Untrusted sources include route parameters, query strings, data from JS interop, and any other source of data that a third-party user can control (databases, external services). For more information, see <xref:blazor/fundamentals/signalr#websocket-compression-for-interactive-server-components> and <xref:blazor/security/server/interactive-server-side-rendering?view=aspnetcore-9.0#interactive-server-components-with-websocket-compression-enabled>.

:::moniker-end
