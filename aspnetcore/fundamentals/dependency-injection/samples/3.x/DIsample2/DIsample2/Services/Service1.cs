using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIsample2.Services
{
    public class Service1 : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Service1.Dispose");
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public class Service2 : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Service2.Dispose");

            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public interface IService3 { }
    public class Service3 : IService3, IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Service3.Dispose");

            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
