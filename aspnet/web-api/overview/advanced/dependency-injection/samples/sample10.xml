public IDependencyScope BeginScope()
{
    var child = container.CreateChildContainer();
    return new UnityResolver(child);
}