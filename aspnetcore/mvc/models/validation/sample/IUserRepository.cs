namespace MVCMovie.Controllers
{
    public interface IUserRepository
    {
        bool VerifyEmail(string email);
        bool VerifyName(string firstName, string lastName);
    }
}