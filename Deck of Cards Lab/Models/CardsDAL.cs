using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Deck_of_Cards_Lab.Models
{
    public class CardsDAL
    {
        public CardsModel GetData()
        {
            // bad practice but just for today

            // urls in C# need https://
            string site = "https://deckofcardsapi.com/api/deck/6t2cgu7t1cif/draw/?count=5";

            // request is called request
            HttpWebRequest request = WebRequest.CreateHttp(site);

            //response is called response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //this will allow it to read the response but won't be readable for humans
            StreamReader reader = new StreamReader(response.GetResponseStream());

            //This converts the data read in the stream reader into a c# class
            string JSON = reader.ReadToEnd();

            // takes the string and turns it into an object
            CardsModel cards = JsonConvert.DeserializeObject<CardsModel>(JSON);

            return cards;



        }


    }

}
