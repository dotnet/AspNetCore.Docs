using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySharedApp.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Message from shared assembly!");
        }
    }
}