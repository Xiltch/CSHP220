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
        [HttpGet]
        public ActionResult New()
        {
            Card card = new Card();
            return View(card);
        }

        [HttpPost]
        public ActionResult New(Card card)
        {
            if (!ModelState.IsValid)
                return View(card);

            return View("Sent", card);
        }
    }
}