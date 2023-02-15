Blazor server apps live in server memory. That means that there are multiple apps hosted within the same process. For each app session, Blazor starts a circuit with its own DI container scope. That means that scoped services are unique per Blazor session.

> [!WARNING]
> We don't recommend apps on the same server share state using singleton services unless extreme care is taken, as this can introduce security vulnerabilities, such as leaking user state across circuits.

You can use stateful singleton services in Blazor apps if they are specifically designed for it. For example, it's ok to use a memory cache as a singleton because it requires a key to access a given entry, assuming users don't have control of what cache keys are used.

For general guidance on state management, see <xref:blazor/state-management>.
