using ServiceStack;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication1.Models;
using RouteAttribute = ServiceStack.RouteAttribute;

namespace WebApplication1.Controllers
{
    public class playMancalaController : Controller
    {
        private APIConnector apiConnector = new APIConnector();

        //mancala game ended and winner options

        // GET: playMancala
        public ViewResult playMancala(int id)
        {
            ViewData["gameState"] = fetchGameState(id);
            ViewData["gameId"] = id;
            return View();
        }

        public ActionResult newGame()
        {
            int gameId = apiConnector.createNewGame();
            return RedirectToAction("playMancala", "playMancala", new { id = gameId });
        }

        public ActionResult makeMove(int CollectionId, int unitId)
        {
            apiConnector.makeMove(CollectionId, unitId);
            return RedirectToAction("playMancala", "playMancala", new { id = CollectionId });
        }

        public void saveGame()
        {

        }

        public void loadGame()
        {

        }

        private int[] fetchGameState(int gameId)
        {
            return apiConnector.fetchGameState(gameId);
        }

    }
}