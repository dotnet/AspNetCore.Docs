namespace ValidationSample.Data
{
    public interface IUserRepository
    {
        bool VerifyEmail(string email);
        bool VerifyName(string firstName, string lastName);
    }
}