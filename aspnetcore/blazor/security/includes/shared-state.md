Server-side Blazor apps live in server memory, and multiple app sessions are hosted within the same process. For each app session, Blazor starts a circuit with its own dependency injection container scope, thus scoped services are unique per Blazor session.

> [!WARNING]
> We don't recommend apps on the same server share state using singleton services unless extreme care is taken, as this can introduce security vulnerabilities, such as leaking user state across circuits.

You can use stateful singleton services in Blazor apps if they're specifically designed for it. For example, use of a singleton memory cache is acceptable because a memory cache requires a key to access a given entry. Assuming users don't have control over the cache keys that are used with the cache, state stored in the cache doesn't leak across circuits.

For general guidance on state management, see <xref:blazor/state-management>.
