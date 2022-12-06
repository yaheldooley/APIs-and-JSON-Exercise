using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
	public static partial class AppSettings
	{
		public static readonly string appsettings = "C:\\Users\\ydool\\Desktop\\Repos\\APIs-and-JSON-Exercise\\APIsAndJSON\\appsettings.json";
		public static void Initialize()
		{
			if (File.Exists(appsettings))
			{
				var jsonText = File.ReadAllText(appsettings);
				var apiKeys = JsonConvert.DeserializeObject<APIKeys>(jsonText);
				OpenWeatherMapAPI.APIKey = apiKeys.APIData.Weather;
				COD_MWAPI.APIKey = apiKeys.APIData.COD;
			}
		}
	}
}
