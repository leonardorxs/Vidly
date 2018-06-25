using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext Context { get; set; }

        public RentalsController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New()
        {
            return View();
        }
    }
}