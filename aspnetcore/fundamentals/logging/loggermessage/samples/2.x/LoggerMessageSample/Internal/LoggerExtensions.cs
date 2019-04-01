using System;
using Microsoft.Extensions.Logging;

namespace LoggerMessageSample.Internal
{
    public static class LoggerExtensions
    {
        #region snippet1
        private static readonly Action<ILogger, Exception> _indexPageRequested;
        #endregion

        #region snippet2
        private static readonly Action<ILogger, string, Exception> _quoteAdded;
        #endregion

        #region snippet3
        private static readonly Action<ILogger, string, int, Exception> _quoteDeleted;
        private static readonly Action<ILogger, int, Exception> _quoteDeleteFailed;
        #endregion

        #region snippet4
        private static Func<ILogger, int, IDisposable> _allQuotesDeletedScope;
        #endregion

        static LoggerExtensions()
        {
            #region snippet5
            _indexPageRequested = LoggerMessage.Define(
                LogLevel.Information, 
                new EventId(1, nameof(IndexPageRequested)), 
                "GET request for Index page");
            #endregion

            #region snippet6
            _quoteAdded = LoggerMessage.Define<string>(
                LogLevel.Information, 
                new EventId(2, nameof(QuoteAdded)), 
                "Quote added (Quote = '{Quote}')");
            #endregion

            // Reserve EventId: 3 (QuoteModified)

            #region snippet7
            _quoteDeleted = LoggerMessage.Define<string, int>(
                LogLevel.Information, 
                new EventId(4, nameof(QuoteDeleted)), 
                "Quote deleted (Quote = '{Quote}' Id = {Id})");

            _quoteDeleteFailed = LoggerMessage.Define<int>(
                LogLevel.Error, 
                new EventId(5, nameof(QuoteDeleteFailed)), 
                "Quote delete failed (Id = {Id})");
            #endregion

            #region snippet8
            _allQuotesDeletedScope = 
                LoggerMessage.DefineScope<int>("All quotes deleted (Count = {Count})");
            #endregion
        }

        #region snippet9
        public static void IndexPageRequested(this ILogger logger)
        {
            _indexPageRequested(logger, null);
        }
        #endregion

        #region snippet10
        public static void QuoteAdded(this ILogger logger, string quote)
        {
            _quoteAdded(logger, quote, null);
        }
        #endregion

        public static void QuoteModified(this ILogger logger, string id, string priorQuote, string newQuote)
        {
            // Reserve for future feature
        }

        #region snippet11
        public static void QuoteDeleted(this ILogger logger, string quote, int id)
        {
            _quoteDeleted(logger, quote, id, null);
        }

        public static void QuoteDeleteFailed(this ILogger logger, int id, Exception ex)
        {
            _quoteDeleteFailed(logger, id, ex);
        }
        #endregion

        #region snippet12
        public static IDisposable AllQuotesDeletedScope(
            this ILogger logger, int count)
        {
            return _allQuotesDeletedScope(logger, count);
        }
        #endregion
    }
}
