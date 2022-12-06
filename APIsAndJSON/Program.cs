
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IO;

namespace APIsAndJSON
{
    
    public class Program
    {
		static void Main(string[] args)
        {
			AppSettings.Initialize();

			KanyeAndRonConversation();
            OpenWeatherMapAPI.Forecast("Springfield", "Mo", "", "en");
            COD_MWAPI.GetCODUserDetails();
		}
		public static void KanyeAndRonConversation()
		{
			for (int i = 0; i < 5; i++)
			{
				RonVSKanyeAPI.KanyeQuote();
				RonVSKanyeAPI.RonSwansonQuote();
				Console.WriteLine();
			}
		}
	}
}
