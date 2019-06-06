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
            TaskStatus[] include = new TaskStatus[]
            {
                TaskStatus.IN_PROGRESS,
                TaskStatus.PENDING,
                TaskStatus.DRAFT,
                TaskStatus.COMPLETED
            };
            IEnumerable<ITask> tasks = repository.GetTasks()
                .Where(x => include.Contains(x.Status))
                .OrderByDescending(x => x.Modified)
                .ThenByDescending(x => x.Created);
            return View(tasks);
        }

        public ActionResult FiveMostRecent()
        {
            TaskStatus[] include = new TaskStatus[]
            {
                TaskStatus.IN_PROGRESS,
                TaskStatus.PENDING
            };

            IEnumerable<ITask> tasks = repository.GetTasks()
                .Where(x => include.Contains(x.Status))
                .OrderByDescending(x => x.Modified)
                .Take(5);
            var c = tasks.Count();
            return PartialView("_DisplayOnly", tasks);
        }

        public ActionResult List()
        {

            IEnumerable<ITask> tasks = repository.GetTasks()
                .OrderByDescending(x => x.Modified)
                .ThenByDescending(x => x.Created);
            return View(tasks);
        }

        public ActionResult Details(int id)
        {
            ITask task = repository.GetTask(id);

            var comments = repository.GetComments(task.ID).OrderByDescending(x => x.Created);

            task.Comments = comments;

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

            List<SelectListItem> users = new List<SelectListItem>();
            users.Add(new SelectListItem() { Value = "0", Text = "-- Unassigned --" });
            repository.GetUsers()
                .Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.ToString() })
                .ToList()
                .ForEach(x => users.Add(x));

            ViewBag.UserSelection = users;

            if (task.AssignedTo != null)
                ((Task)task).AssignedUserID = task.AssignedTo.ID;

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (!ModelState.IsValid)
                return View();

            // Not assigned user is ID  = 0
            if (task.AssignedUserID.Equals(0))
            {
                task.AssignedTo = null;
            }
            else
            {
                task.AssignedTo = repository.GetUser(task.AssignedUserID);
            }

            task.Modified = DateTime.Now;

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

        public ActionResult AddComment(int id)
        {
            Comment comment = new Comment() { TaskID = id };

            if (Session["CurrentUser"] is int)
            {
                comment.CreatedByID = (int)Session["CurrentUser"];
                comment.CreatedBy = repository.GetUser(comment.CreatedByID);
            }

            return View(comment);
        }

        [HttpPost]
        public ActionResult AddComment(int id, Comment comment)
        {

            comment.CreatedBy = new User() { ID = comment.CreatedByID };

            repository.AddComment(id, comment);
            repository.Save();

            return RedirectToAction("Details", new { id = id });
        }

    }
}