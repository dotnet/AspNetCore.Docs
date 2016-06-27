namespace MVCMovie.Controllers
{
    public interface IUserRepository
    {
        bool VerifyEmail(string email);
    }
}