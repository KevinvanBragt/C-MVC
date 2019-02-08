using System;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.FormModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(NameModel nameModel)
        {
            HttpCookie namesCookie = new HttpCookie("namesCookie");
            if (nameModel.player1 != null) { namesCookie["player1"] = nameModel.player1; }
            if (nameModel.player2 != null) { namesCookie["player2"] = nameModel.player2; }
            namesCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(namesCookie);
            return RedirectToAction("newGame", "playMancala");
        }

    }

}
