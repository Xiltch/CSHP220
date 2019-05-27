using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {

        private readonly ITaskRepository repository;

        public UserController(ITaskRepository context)
        {
            this.repository = context;
        }

        // GET: Users
        public ActionResult List()
        {
            IEnumerable<IUser> users = repository.GetUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {

            if (!ModelState.IsValid)
                return View();

            repository.AddUser(user);
            repository.Save();

            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            IUser user = repository.GetUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            IUser user = repository.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {

            repository.DeleteUser(user.ID);
            repository.Save();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            IUser user = repository.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            repository.UpdateUser(user);
            repository.Save();
            return RedirectToAction("List");
        }

    }
}