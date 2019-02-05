using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UrlBuilder
    {

       /**
         * for now uses hardCoded paths, if API is extended might bring them in dynamicly?
         * 
         * GET: http://localhost:8080/MancalaAPI/webapi/mancalaservice/game/id
         * PUT: http://localhost:8080/MancalaAPI/webapi/mancalaservice/game/id/cup/cupId
         * POST: http://localhost:8080/MancalaAPI/webapi/mancalaservice/game/
         **/

        private static String _baseUrl = "http://localhost:8080/MancalaAPI/webapi/mancalaservice/game";

        private static String baseUrl
        {
            get { return _baseUrl; }
        }

        public static String getNewGameUrl()
        {
            return baseUrl;
        }

        public static String getGameStateUrl(int gameId)
        {
            return baseUrl + "/" + gameId;
        }

        public static String getmakeMoveUrl(int gameId, int cupId)
        {
            return baseUrl + "/" + gameId + "/cup/" + cupId;
        }

        public static String getSaveGameUrl()
        {
            return "not implemented";
        }

        public static String getLoadGameUrl()
        {
            return "not implemented";
        }



    }
}