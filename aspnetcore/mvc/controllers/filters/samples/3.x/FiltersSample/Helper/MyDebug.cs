using System.Diagnostics;
using System.Reflection;

namespace FiltersSample.Helper
{
    public static class MyDebug
    {
        public static void Write(MethodBase m, string path)
        {
            Debug.WriteLine(m.ReflectedType.Name + "." + m.Name + " " +
                path);
        }
    }
}
