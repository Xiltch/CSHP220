using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITaskRepository repository;

        public HomeController(ITaskRepository context)
        {
            this.repository = context;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<SelectListItem> users = new List<SelectListItem>();

            users.Add(new SelectListItem() { Value = "0", Text = "Select Current User" });
            repository.GetUsers()
                .Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.ToString() })
                .ToList()
                .ForEach(x => users.Add(x));

            ViewBag.UserSelection = users;

            return View();
        }

        public ActionResult CurrentUser(int id)
        {
            Session["CurrentUser"] = id;

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        } 
    }
}