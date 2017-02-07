public void SaveChanges()
{
	try
	{
		context.SaveChanges();
	}
	catch (OptimisticConcurrencyException ocex)
	{
		context.Refresh(RefreshMode.StoreWins, ocex.StateEntries[0].Entity);
		throw ocex;
	}
}