﻿namespace APIsAndJSON
{
	public static partial class OpenWeatherMapAPI
    {
		public class Sys
		{
			public int type { get; set; }
			public int id { get; set; }
			public string country { get; set; }
			public int sunrise { get; set; }
			public int sunset { get; set; }
		}
	}
}
