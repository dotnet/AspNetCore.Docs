public class FilterProvider : IFilterProvider
{
	private IUnityContainer container;

	public FilterProvider(IUnityContainer container)
	{
		this.container = container;
	}
}