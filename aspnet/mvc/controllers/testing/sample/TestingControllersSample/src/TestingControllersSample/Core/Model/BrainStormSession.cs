using System;
using System.Collections.Generic;

namespace TestingControllersSample.Core.Model
{
    public class BrainStormSession
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Idea> Ideas { get; private set; } = new List<Idea>();

        public void AddIdea(Idea idea)
        {
            Ideas.Add(idea);
        }
    }

    public class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}