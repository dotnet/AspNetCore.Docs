using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace ObjectPoolSample
{
    public class StringBuilderPooledObjectPolicy : IPooledObjectPolicy<StringBuilder>
    {
        public StringBuilder Create()
        {
            return new StringBuilder();
        }

        public bool Return(StringBuilder obj)
        {
            obj.Clear(); // resets the StringBuilder for the next consumer

            return true;
        }
    }
}
