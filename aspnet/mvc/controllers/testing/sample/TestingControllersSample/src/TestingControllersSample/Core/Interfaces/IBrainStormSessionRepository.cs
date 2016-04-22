using System.Collections.Generic;
using Microsoft.AspNet.Razor.Chunks.Generators;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Core.Interfaces
{
    public interface IBrainStormSessionRepository
    {
        BrainStormSession GetById(int id);
        List<BrainStormSession> List();
        void Add(BrainStormSession session);
        void Update(BrainStormSession session);
    }
}