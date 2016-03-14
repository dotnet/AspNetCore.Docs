using System;

namespace TestingControllersSample.ClientModels
{
    public class IdeaDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTimeOffset dateCreated { get; set; }
    }
}