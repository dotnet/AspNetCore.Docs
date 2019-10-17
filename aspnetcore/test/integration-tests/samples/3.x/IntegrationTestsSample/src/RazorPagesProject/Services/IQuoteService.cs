using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    #region snippet1
    public interface IQuoteService
    {
        Task<string> GenerateQuote();
    }
    #endregion
}
