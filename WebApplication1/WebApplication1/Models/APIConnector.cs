using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class APIConnector
    {
        //http://docs.servicestack.net/http-utils#parsing-custom-responses

        private UrlBuilder urlBuilder = new UrlBuilder();
        private int sessionGameId;

        public void createNewGame()
        {
            var response = UrlBuilder.getNewGameUrl().PostToUrl("");
            System.Diagnostics.Debug.WriteLine(response.ToString());

        }

    }
}