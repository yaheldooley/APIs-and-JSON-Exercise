using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Xml.Linq;

namespace APIsAndJSON
{
	public static partial class COD_MWAPI
	{
		private static  string _apiKey;
		public static string APIKey 
		{
			get { return _apiKey; }  
			set { _apiKey = value; }
		}
		public static void GetCODUserDetails()
		{
			var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");
			var request = new RestRequest();
			request.AddHeader("X-RapidAPI-Key", _apiKey);
			request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");

			var response = client.Execute(request);
			
			Console.WriteLine($"Kill/Death Ratio = {BRCoDParse(response).properties.kdRatio}");
		}
		public static Gamer BRCoDParse(RestResponse response)
		{

			var deserialized = JObject.Parse(response.Content);
			Gamer gamer = JsonConvert.DeserializeObject<Gamer>(deserialized["data"]["lifetime"]["mode"]["br"].ToString());
			return gamer;
		}


	}
}
