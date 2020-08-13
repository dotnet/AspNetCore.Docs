using InMemoryToSQLServer.Data;
using InMemoryToSQLServer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryToSQLServer
{
    public class LoggerProcessor
    {
        private readonly IServiceProvider _serviceProvider;
        private const int _maxQueuedMessages = 1024;
        private SQLServerDbContext _sqlServerDbContext;

        private readonly BlockingCollection<Log> _messageQueue = new BlockingCollection<Log>(_maxQueuedMessages);

        public LoggerProcessor(IServiceProvider serviceProvider, SQLServerDbContext sqlServerDbContext)
        {
            _serviceProvider = serviceProvider;
            _sqlServerDbContext = sqlServerDbContext;

            Task.Run(() => ProcessLogQueue());
        }

        public virtual void EnqueueMessage(Log log)
        {
            if(!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(log);
                }
                catch (InvalidOperationException) { }
            }
            WriteMessage(log);
        }

        internal virtual void WriteMessage(Log log)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SQLServerDbContext>();
                context.Add(log);
                context.SaveChanges();                
            }
        }

        private void ProcessLogQueue()
        {
            try
            {
                foreach (var message in _messageQueue.GetConsumingEnumerable())
                {
                    WriteMessage(message);
                }
            }
            catch { }
        }
    }
}
