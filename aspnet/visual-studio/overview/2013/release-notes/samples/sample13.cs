public interface IUserIdProvider
{
    string GetUserId(IRequest request);
}