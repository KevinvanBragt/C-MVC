using System.Web.Mvc;
using System.Web.Services;

namespace WebApplication1.Controllers
{
    public class playMancalaController : Controller
    {

        public playMancalaController()
        {
            fetchResources();
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

        public void newGame()
        {
            //newgame code
        }

        public void saveGame()
        {

        }

        public void loadGame()
        {

        }

        private void fetchResources()
        {
            //
        }

        private void fetchSessionData()
        {
            //
        }

        private void APIConnector(string url)
        {
            var response = url.GetJsonFromUrl().

        }

    }
}