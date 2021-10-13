using System;

namespace DIsample2.Services
{
    #region snippet
    public class Service1 : IDisposable
    {
        private bool _disposed;

        public void Write(string message)
        {
            Console.WriteLine($"Service1: {message}");
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Console.WriteLine("Service1.Dispose");
            _disposed = true;
        }
    }

    public class Service2 : IDisposable
    {
        private bool _disposed;

        public void Write(string message)
        {
            Console.WriteLine($"Service2: {message}");
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Console.WriteLine("Service2.Dispose");
            _disposed = true;
        }
    }

    public interface IService3
    {
        public void Write(string message);
    }

    public class Service3 : IService3, IDisposable
    {
        private bool _disposed;

        public Service3(string myKey)
        {
            MyKey = myKey;
        }

        public string MyKey { get; }

        public void Write(string message)
        {
            Console.WriteLine($"Service3: {message}, MyKey = {MyKey}");
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Console.WriteLine("Service3.Dispose");
            _disposed = true;
        }
    }
    #endregion
}
