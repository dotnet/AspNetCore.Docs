using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace ObjectPoolSample
{
    #region snippet
    public class StringBuilderPooledObjectPolicy : IPooledObjectPolicy<StringBuilder>
    {
        public StringBuilder Create()
        {
            return new StringBuilder();
        }

        public bool Return(StringBuilder obj)
        {
            obj.Clear(); // Resets the StringBuilder for the next consumer.

            return true;
        }
    }
    #endregion
}
