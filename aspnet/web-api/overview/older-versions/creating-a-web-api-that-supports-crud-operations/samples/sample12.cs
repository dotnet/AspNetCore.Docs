public void DeleteProduct(int id)
{
	Product item = repository.Get(id);
	if (item == null)
	{
		throw new HttpResponseException(HttpStatusCode.NotFound);
	}

	repository.Remove(id);
}