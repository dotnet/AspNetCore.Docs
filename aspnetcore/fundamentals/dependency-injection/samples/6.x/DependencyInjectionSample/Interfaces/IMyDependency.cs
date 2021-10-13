using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    #region snippet1
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
    #endregion
}
