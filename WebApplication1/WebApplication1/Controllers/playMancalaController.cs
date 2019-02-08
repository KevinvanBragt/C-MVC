using ServiceStack;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication1.Models;
using RouteAttribute = ServiceStack.RouteAttribute;

namespace WebApplication1.Controllers
{
    public class playMancalaController : Controller
    {
        private APIConnector apiConnector = new APIConnector();


        // GET: playMancala
        public ViewResult playMancala(int id)
        {
            int[] gameState = fetchGameState(id);
            ViewData["gameState"] = gameState;
            ViewData["viewMessage"] = getViewMessage(gameState);
            ViewData["gameId"] = id;
            HttpCookie namesCookie = Request.Cookies["namesCookie"];
            ViewData["namePlayer1"] = namesCookie["player1"];
            ViewData["namePlayer2"] = namesCookie["player2"];

            //Session["gameId"] = id;                                                               
            return View();
        }

        public ActionResult newGame()
        {
            int gameId = apiConnector.createNewGame();
            return RedirectToAction("playMancala", "playMancala", new { id = gameId });
        }

        public ActionResult makeMove(int CollectionId, int unitId)
        {
            //CollectionId = (int)(Session["gameId"]);
            System.Diagnostics.Debug.WriteLine("debugging session id: " + unitId);
            apiConnector.makeMove(CollectionId, unitId);
            return RedirectToAction("playMancala", "playMancala", new { id = CollectionId });
        }

        //session can be used for loading previous games.
        public void loadGame()
        {

        }

        private int[] fetchGameState(int gameId)
        {
            return apiConnector.fetchGameState(gameId);
        }

        private string getViewMessage(int[] gameState)
        {
            return " ";
        }

    }
}