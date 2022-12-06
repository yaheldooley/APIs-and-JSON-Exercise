using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
	public static partial class OpenWeatherMapAPI
    {
		private static readonly string openWeatherUrl = "https://api.openweathermap.org/data/2.5/weather?q=";
        private static string _apiKey;
		public static string APIKey
		{
			get { return _apiKey; } 
			set { _apiKey = value; }
		}
		public static void Forecast(string cityName, string stateCode, string countryCode, string language)
        {
			//API can recieve City only, City and CountryCode, or City State and CountryCode

			string weatherURL = $"{openWeatherUrl}";
			if (cityName == null || cityName == string.Empty) // Doesn't meet minimum API criteria
			{
				Console.WriteLine("City name is empty and is required to call API");
				return;
			}
			weatherURL += cityName;
			if (countryCode != null && countryCode != "")
			{
				if (stateCode != null && stateCode != "") weatherURL += $",{stateCode}";
				weatherURL += $",{countryCode}";
			}
			weatherURL += $"{_apiKey}&units=imperial";
			var client = new HttpClient();
			try
			{
				var forecastResponse = client.GetStringAsync(weatherURL).Result;
				WeatherAPIModel model = JsonConvert.DeserializeObject<WeatherAPIModel>(forecastResponse);
				Console.WriteLine($"== Current Weather =================");
				Console.WriteLine($"Temp: {model.main.temp} F");
				Console.WriteLine($"Pressure: {model.main.pressure}");
				Console.WriteLine($"Humidity: {model.main.humidity}");
				Console.WriteLine($"Low: {model.main.temp_min} Fahr, High: {model.main.temp_max} Fahr");
				foreach(var weather in model.weather)
				{
					Console.WriteLine($"{weather.description}");
				}
				Console.WriteLine($"Wind Speed: {model.wind.speed} MPH");

			}
			catch (Exception E)
			{
				Console.WriteLine(E);
				
			}
		}
	}
}
