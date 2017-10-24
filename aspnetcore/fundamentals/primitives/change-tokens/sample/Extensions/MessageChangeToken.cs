using System;
using Microsoft.Extensions.Primitives;
using ChangeTokenSample.Enums;

namespace ChangeTokenSample.Extensions
{
    #region snippet1
    public class MessageChangeToken : IChangeToken
    {
        private Action<MessageChangeType> _callback;

        public bool ActiveChangeCallbacks { get; set; }
        public bool HasChanged { get; set; }

        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
        {
            _callback = (messageChangeType) => callback(messageChangeType);
            return null;
        }

        public void Changed(MessageChangeType messageChangeType)
        {
            ChangeTokens.ChangeTokens.LastMessageChangeType = messageChangeType;
            HasChanged = true;
            _callback(messageChangeType);
        }
    }
    #endregion
}
