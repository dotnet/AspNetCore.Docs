using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ProcessesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<ProcessInfoViewModel> Get()
        {
            var processList = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();

            return processList.Select(p => new ProcessInfoViewModel() { Name = p.ProcessName });
        }
    }
}
