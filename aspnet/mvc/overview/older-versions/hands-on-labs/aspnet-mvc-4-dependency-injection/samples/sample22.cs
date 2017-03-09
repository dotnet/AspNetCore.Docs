public class FilterProvider : IFilterProvider
{
	private IUnityContainer container;

	public FilterProvider(IUnityContainer container)
	{
		this.container = container;
	}

	public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
	{
		foreach (IActionFilter actionFilter in this.container.ResolveAll<IActionFilter>())
		{
			yield return new Filter(actionFilter, FilterScope.First, null);
		}
	}
}