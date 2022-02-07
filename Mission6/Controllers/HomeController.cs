using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
       
        private TaskContext _TContext { get; set; } 

        public HomeController(TaskContext passTask)
        {
            _TContext = passTask;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult ViewTasks()
        {
            return View();
        }
       
    }
}
