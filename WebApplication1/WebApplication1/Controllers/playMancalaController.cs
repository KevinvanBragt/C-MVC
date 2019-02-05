using ServiceStack;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class playMancalaController : Controller
    {
        private APIConnector apiConnector = new APIConnector();

        public playMancalaController()
        {
            fetchSessionData();
            fetchGameState();
        }
        
        // GET: playMancala
        public ViewResult playMancala()
        {
            return View();
        }

        // GET: makeMove()
        public ViewResult makeMove(int id)
        {
            //code to make move
            return View("playMancala");
        }

        public static int[] fetchGameState()
        {
            // fetch gamestate...
            return new int[] { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0, 1 };
        }

        public ViewResult newGame()
        {
            apiConnector.createNewGame();
            //returns an ID
            return View("playmancala");
        }

        public void saveGame()
        {

        }

        public void loadGame()
        {

        }

        private void fetchSessionData()
        {
            //
        }

    }
}