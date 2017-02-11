public class ContactController : ApiController
{
    private ContactRepository contactRepository;

    public ContactController()
    {
        this.contactRepository = new ContactRepository();
    } 
    ...
}