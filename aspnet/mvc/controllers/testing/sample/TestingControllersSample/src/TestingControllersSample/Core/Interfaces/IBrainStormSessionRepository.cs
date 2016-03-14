using System.Collections.Generic;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Core.Interfaces
{
    public interface IBrainstormSessionRepository
    {
        BrainstormSession GetById(int id);
        List<BrainstormSession> List();
        void Add(BrainstormSession session);
        void Update(BrainstormSession session);
    }
}