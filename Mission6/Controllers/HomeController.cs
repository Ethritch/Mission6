using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //this is the get method to get to the view that has the task form
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _TContext.Categories.ToList();

            return View();
        }
        //This is the part of the controller that handles the info posted from the form
        [HttpPost]
        public IActionResult AddTask(Tasks ar)
        {
            if(ModelState.IsValid)
            {
                _TContext.Add(ar);
                _TContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = _TContext.Categories.ToList();

                return View(ar);
            }
            
        }
        //This Get access the viewtask list
        [HttpGet]
        public IActionResult ViewTasks()
        {
            var form = _TContext.Tasks
                 .Include(x => x.Category)
                 .OrderBy(x => x.Quadrant)
                 .ToList();
            return View(form);

            
        }
        //This is the edit controller stuff
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _TContext.Categories.ToList();

            var form = _TContext.Tasks.Single(x => x.TaskID == taskid);

            return View("AddTask", form);
        }

        [HttpPost]
        public IActionResult Edit(Tasks blah)
        {

            _TContext.Update(blah);
            _TContext.SaveChanges();

            return RedirectToAction("ViewTasks");

        }
        //delete controller stuff
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var form = _TContext.Tasks.Single(x => x.TaskID == taskid);

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
