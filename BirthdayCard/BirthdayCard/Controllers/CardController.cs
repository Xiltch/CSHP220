using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Card = BirthdayCard.Models.BirthayCard;

namespace BirthdayCard.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult New()
        {
            Card card = new Card();
            return View(card);
        }

        
    }
}