using ServiceStack;
using System;

namespace WebApplication1.Models
{
    public class APIConnector
    {
        //http://docs.servicestack.net/http-utils#parsing-custom-responses

        private UrlBuilder urlBuilder = new UrlBuilder();
    

        public int createNewGame()
        {
            var response = UrlBuilder.getNewGameUrl().PostToUrl("");
            int id = 0;
            System.Diagnostics.Debug.WriteLine("created new game with id: " + response);
            if (Int32.TryParse(response, out id)) { return id; }
            else { throw new Exception(); }
        }

        public int[] fetchGameState(int id)
        {
            var response = UrlBuilder.getGameStateUrl(id).GetJsonFromUrl();
            int[] gameState = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(response);
            System.Diagnostics.Debug.WriteLine("gamestate fetched");
            System.Diagnostics.Debug.WriteLine("gamestate[4] = " + gameState[4].ToString());
            return gameState;
        }

        public void makeMove(int gameId, int cupId)
        {
            System.Diagnostics.Debug.WriteLine(UrlBuilder.getMakeMoveUrl(gameId, cupId));
            var response = UrlBuilder.getMakeMoveUrl(gameId, cupId).PutToUrl("");
            System.Diagnostics.Debug.WriteLine("request url: " + UrlBuilder.getMakeMoveUrl(gameId, cupId) + "      response: " +response);
        }
    }
}