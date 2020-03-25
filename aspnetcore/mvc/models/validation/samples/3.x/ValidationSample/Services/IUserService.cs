namespace ValidationSample.Services
{
    public interface IUserService
    {
        bool VerifyEmail(string email);
        bool VerifyName(string firstName, string lastName);
    }
}
