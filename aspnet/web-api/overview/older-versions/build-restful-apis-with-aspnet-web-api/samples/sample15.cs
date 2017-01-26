public HttpResponseMessage Post(Contact contact)
{
	this.contactRepository.SaveContact(contact);

	var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

	return response;
}