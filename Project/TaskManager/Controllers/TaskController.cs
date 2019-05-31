using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository repository;
        public TaskController(ITaskRepository context)
        {
            this.repository = context;
        }

        public ActionResult Index()
        {
            IEnumerable<ITask> tasks = repository.GetTasks();
            return View(tasks);
        }

        public ActionResult TopFive()
        {
            IEnumerable<ITask> tasks = repository.GetTasks()
                .Where(x => x.Status != TaskStatus.DRAFT && x.Status != TaskStatus.COMPLETED)
                .OrderByDescending(x => x.Stop)
                .Take(5);
            var c = tasks.Count();
            return PartialView("_DisplayOnly", tasks);
        }

        public ActionResult List()
        {
            IEnumerable<ITask> tasks = repository.GetTasks()
                .OrderByDescending(x => x.Stop)
                .ThenByDescending(x => x.Start);
            return View(tasks);
        }

        public ActionResult Details(int id)
        {
            ITask task = repository.GetTask(id);
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Task task = new Task();
            return View(task);
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
                return View();

            repository.AddTask(task);
            repository.Save();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ITask task = repository.GetTask(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (!ModelState.IsValid)
                return View();

            ((TaskManager.App_Data.Repository)repository).UpdateTask(task);
            repository.Save();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ITask task = repository.GetTask(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Delete(Task task)
        {

            repository.DeleteTask(task.ID);
            repository.Save();

            return RedirectToAction("List");
        }

    }
}