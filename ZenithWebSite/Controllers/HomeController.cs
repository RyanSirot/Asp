using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            startOfWeek = startOfWeek.AddDays(1);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var events = db.Events.Where(e => e.FromDateTime >= startOfWeek && e.ToDateTime <= endOfWeek && e.IsActive == true)
                                .OrderBy(d => d.FromDateTime)
                                .Select(e => e);
            ViewBag.activities = db.Activities.Select(e => e);
            return View(events.ToList());
        }
    }
}