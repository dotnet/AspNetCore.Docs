using System;

namespace HttpRequestsSample.Models
{
    #region snippet_Types
    public interface IOperationScoped 
    {
        string OperationId { get; }
    }

    public class OperationScoped : IOperationScoped
    {
        public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
    }
    #endregion
}
