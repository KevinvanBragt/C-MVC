using System;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        // GET: web
        public ViewResult Index()
        {
            return View();
        }

        protected string playMancala(object sender, EventArgs e)
        {
            return "you requested to play mancala";
        }

    }

}
