using System;

namespace DIsample2.Services
{
    #region snippet
    public class Service1 : IDisposable
    {
        private bool disposedValue;

        public void Write(string message)
        {
            Console.WriteLine($"Service1: {message}");
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                Console.WriteLine("Service1.Dispose");
                disposedValue = true;
            }
        }
    }

    public class Service2 : IDisposable
    {
        private bool disposedValue;

        public void Write(string message)
        {
            Console.WriteLine($"Service2: {message}");
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                Console.WriteLine("Service2.Dispose");
                disposedValue = true;
            }
        }
    }

    public interface IService3 {
        public void Write(string message);
    }

    public class Service3 : IService3, IDisposable
    {
        private bool disposedValue;

        public void Write(string message)
        {
            Console.WriteLine($"Service3: {message}");
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                Console.WriteLine("Service3.Dispose");
                disposedValue = true;
            }
        }
    }
    #endregion
}
