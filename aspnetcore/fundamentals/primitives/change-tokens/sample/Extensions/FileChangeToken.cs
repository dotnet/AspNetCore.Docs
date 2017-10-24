using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace ChangeTokenSample.Extensions
{
    #region snippet1
    public class FileChangeToken : IChangeToken
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        // Indicates if this token will proactively raise callbacks.
        // Callbacks are still guaranteed to be invoked, eventually.
        public bool ActiveChangeCallbacks => true;

        // Gets a value that indicates if a change has occurred.
        public bool HasChanged => _cts.IsCancellationRequested;

        // Registers for a callback that will be invoked when the entry has changed.
        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => 
            _cts.Token.Register(callback, state);

        // Used to trigger the change token when a reload occurs.
        public void OnReload() => _cts.Cancel();
    }
    #endregion
}
