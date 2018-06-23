using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    #region snippet1
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
    #endregion
}
