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
        public ViewResult playMancala(int id)
        {
            int[] gameState = fetchGameState(id);
            ViewData["gameState"] = gameState;
            ViewData["viewMessage"] = getViewMessage(gameState);
            //ViewData["gameId"] = id;
            ViewData["gameId"] = Session["gameId"];                                                    //                     
            return View();
        }

        public ActionResult newGame()
        {
            int gameId = apiConnector.createNewGame();
            Session["gameId"] = gameId;                                                                 //
            return RedirectToAction("playMancala", "playMancala", new { id = gameId });
        }

        public ActionResult makeMove(int CollectionId, int unitId)
        {
            CollectionId = (int)(Session["gameId"]);                                                    //
            System.Diagnostics.Debug.WriteLine("debugging session id: " + CollectionId);
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