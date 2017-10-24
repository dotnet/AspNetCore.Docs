using System;
using Microsoft.Extensions.Primitives;
using ChangeTokenSample.Enums;

namespace ChangeTokenSample.Extensions
{
    #region snippet1
    public class MessageChangeTokenNoState : IChangeToken
    {
        private Action _callback;

        public bool ActiveChangeCallbacks { get; set; }
        public bool HasChanged { get; set; }

        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
        {
            _callback = () => callback(state);
            return null;
        }

        public void Changed(MessageChangeType messageChangeType)
        {
            ChangeTokens.ChangeTokens.LastMessageChangeType = messageChangeType;
            HasChanged = true;
            _callback();
        }
    }
    #endregion
}
