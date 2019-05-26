using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {

        private readonly ITaskRepository repository;

        public UserController(ITaskRepository context)
        {
            this.repository = context;
        }

        // GET: User
        public ActionResult Index()
        {
            IEnumerable<IUser> users = repository.GetUsers();
            return View(users);
        }
    }
}