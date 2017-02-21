public bool SaveContact(Contact contact)
{
	var ctx = HttpContext.Current;

	if (ctx != null)
	{
		 try
		 {
			  var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
			  currentData.Add(contact);
			  ctx.Cache[CacheKey] = currentData.ToArray();

			  return true;
		 }
		 catch (Exception ex)
		 {
			  Console.WriteLine(ex.ToString());
			  return false;
		 }
	}

	return false;
}