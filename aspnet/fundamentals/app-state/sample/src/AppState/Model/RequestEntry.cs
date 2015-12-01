using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppState.Model
{
    [Serializable]
    public class RequestEntry
    {
        public string Path { get; set; }
        public int Count { get; set; }
    }
}
