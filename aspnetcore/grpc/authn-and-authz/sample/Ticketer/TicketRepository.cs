using Microsoft.Extensions.Logging;

namespace Ticketer
{
    public class TicketRepository
    {
        private readonly ILogger<TicketRepository> _logger;
        private int _availableTickets = 5;

        public TicketRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TicketRepository>();
        }

        public int GetAvailableTickets()
        {
            return _availableTickets;
        }

        public bool BuyTickets(string user, int count)
        {
            var updatedCount = _availableTickets - count;

            // Negative ticket count means there weren't enough available tickets
            if (updatedCount < 0)
            {
                _logger.LogWarning("{User} failed to purchase tickets. Not enough available tickets.", user);
                return false;
            }

            _availableTickets = updatedCount;

            _logger.LogInformation("{User} successfully purchased tickets.", user);
            return true;
        }
    }
}
