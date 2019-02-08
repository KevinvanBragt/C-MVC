using ServiceStack;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication1.Models;
using RouteAttribute = ServiceStack.RouteAttribute;

namespace WebApplication1.Controllers
{
    public class playMancalaController : Controller
    {
        /**
         * id is niet meer nodig bij gebruik van sessie. 
         * 
         **/

        private APIConnector apiConnector = new APIConnector();

        [HttpGet]
        public ViewResult playMancala()
        {
            int gameId = (int)Session["gameId"];
            ViewData["gameId"] = gameId;
            int[] gameState = fetchGameState(gameId);
            ViewData["gameState"] = gameState;
            ViewData["viewMessage"] = getViewMessage(gameState);
            return View();
        }

        public ActionResult newGame()
        {
            Session["gameId"] = apiConnector.createNewGame();           
            return RedirectToAction("playMancala", "playMancala");
        }

        public ActionResult makeMove(int unitId)
        {
            int gameId = (int)(Session["gameId"]);                       
            apiConnector.makeMove(gameId, unitId);
            return RedirectToAction("playMancala", "playMancala");
        }

        private int[] fetchGameState(int gameId)
        {
            return apiConnector.fetchGameState(gameId);
        }

        private string getViewMessage(int[] gameState)
        {
            HttpCookie namesCookie = Request.Cookies["namesCookie"];
            string player1 = namesCookie["player1"];
            string player2 = namesCookie["player2"];
            Boolean gameHasWinner = (gameState[15] != 0);
            int playerHavingTurn = (gameState[14]);
            string viewMessage = "";

            if (gameHasWinner)
            {
                if (gameState[15] == -1)
                {
                    viewMessage = "it's a draw!";
                }
                else if (gameState[15] == 2)
                {
                    viewMessage = player2 + " has won!";
                }
                else if (gameState[15] == 1)
                {
                    viewMessage = player1 + " has won!";
                }
                return viewMessage;
            }
            else
            {
                if (gameState[14] == 1)
                {
                    viewMessage = player1 + " it's your turn";
                }
                else if (gameState[14] == 2)
                {
                    viewMessage = player2 + " it's your turn";
                }
            }
            return viewMessage;
        }

    }
}