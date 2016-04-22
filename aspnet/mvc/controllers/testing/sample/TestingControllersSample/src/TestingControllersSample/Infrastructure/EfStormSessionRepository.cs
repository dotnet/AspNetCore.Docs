using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Infrastructure
{
    public class EfStormSessionRepository :IBrainStormSessionRepository
    {
        private readonly AppDbContext _dbContext;

        public EfStormSessionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BrainStormSession GetById(int id)
        {
            return _dbContext.BrainStormSessions
                .Include(s => s.Ideas)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<BrainStormSession> List()
        {
            return _dbContext.BrainStormSessions
                .Include(s=>s.Ideas)
                .OrderByDescending(s => s.DateCreated)
                .ToList();
        }

        public void Add(BrainStormSession session)
        {
            int maxId = 0;
            if (_dbContext.BrainStormSessions.Any())
            {
                maxId = _dbContext.BrainStormSessions.Max(s => s.Id);
            }
            session.Id = maxId + 1;
            _dbContext.BrainStormSessions.Add(session);
            _dbContext.SaveChanges();
        }

        public void Update(BrainStormSession session)
        {
            _dbContext.Entry(session).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}