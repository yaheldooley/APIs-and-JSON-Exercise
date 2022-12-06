using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {

		private static readonly string kanyeURL = "https://api.kanye.rest";
	
		public static void KanyeQuote()
        {
			var client = new HttpClient();
			var swansonQuote = client.GetStringAsync(kanyeURL).Result;

			var quoteString = JObject.Parse(swansonQuote).GetValue("quote").ToString();
			Console.WriteLine($"KANYE: \"{quoteString}\"");
		}

		private static readonly string swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
		public static void RonSwansonQuote()
		{
			var client = new HttpClient();
			var ronResponse = client.GetStringAsync(swansonURL).Result;
			var quoteString = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
			Console.WriteLine($"RON: {quoteString}");
		}
    }
}
