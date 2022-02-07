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

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _TContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult AddTask(Tasks ar)
        {
            if(!ModelState.IsValid)
            {
                _TContext.Add(ar);
                _TContext.SaveChanges();
                return View();
            }
            else
            {
                ViewBag.Categories = _TContext.Categories.ToList();

                return View(ar);
            }
            
        }
        [HttpGet]
        public IActionResult ViewTasks()
        {
            var form = _TContext.Tasks
                 .Include(x => x.Category)
                 .OrderBy(x => x.Quadrent).ToList();
            return View(form);

            
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _TContext.Categories.ToList();

            var form = _TContext.Tasks.Single(x => x.TaskId == taskid);

            return View("ViewTasks", form);
        }

        [HttpPost]
        public IActionResult Edit(AddTask blah)
        {
            _TContext.Update(blah);
            _TContext.SaveChanges();

            return RedirectToAction("ViewTasks");

        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var form = _TContext.Tasks.Single(x => x.TaskId == taskid);

            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(Tasks ar)
        {
            _TContext.Tasks.Remove(ar);
            _TContext.SaveChanges();

            return RedirectToAction("ViewTasks");
        }



    }
}
