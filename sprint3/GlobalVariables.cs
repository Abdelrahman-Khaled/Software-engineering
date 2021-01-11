using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace sprint3
{
    public static class GlobalVariables
    {   //creating the Client to communicate with the Web Api
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalVariables()
        {
            //setting up the port number with the Api
            WebApiClient.BaseAddress = new Uri("https://localhost:44385/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}