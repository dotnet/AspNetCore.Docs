using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Infrastructure
{
    public class EfStormSessionRepository :IBrainstormSessionRepository
    {
        private readonly AppDbContext _dbContext;

        public EfStormSessionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BrainstormSession GetById(int id)
        {
            return _dbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<BrainstormSession> List()
        {
            return _dbContext.BrainstormSessions
                .Include(s=>s.Ideas)
                .OrderByDescending(s => s.DateCreated)
                .ToList();
        }

        public void Add(BrainstormSession session)
        {
            int maxId = 0;
            if (_dbContext.BrainstormSessions.Any())
            {
                maxId = _dbContext.BrainstormSessions.Max(s => s.Id);
            }
            session.Id = maxId + 1;
            _dbContext.BrainstormSessions.Add(session);
            _dbContext.SaveChanges();
        }

        public void Update(BrainstormSession session)
        {
            _dbContext.Entry(session).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}