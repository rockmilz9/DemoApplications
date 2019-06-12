using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WeatherApplication.Class;
using WeatherApplication.Models;

namespace WeatherApplication.Class
{
    public class WeatherBehaviour
    {
        public OpenWeatherMap GetDataFromOpenWeatherApi(string cities)
        {
            OpenWeatherMap openWeatherMap = FillCity();
            string key = string.Empty;

            foreach (KeyValuePair<string, string> city in openWeatherMap.Cities)
            {
                if (city.Value == cities)
                {
                    key = city.Key;
                    break;
                }
            }

            if (cities != null)
            {
                /*Calling API http://openweathermap.org/api */
                String apiKey = "aa69195559bd4f88d79f9aadeb77a8f6";
                HttpWebRequest apiRequest =
                WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" +
                key + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                /*End*/

                /*http://json2csharp.com*/
                ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);

                StringBuilder sb = new StringBuilder();
                sb.Append("Weather Description");
                sb.Append(Environment.NewLine);
                sb.Append("City: " +
                rootObject.name);
                sb.Append(Environment.NewLine);
                sb.Append("Country: " +
                rootObject.sys.country);
                sb.Append(Environment.NewLine);
                sb.Append("Wind: " +
                rootObject.wind.speed);
                sb.Append(Environment.NewLine);
                sb.Append("Current Temperature: " +
                rootObject.main.temp + " °C");
                sb.Append(Environment.NewLine);
                sb.Append("Humidity: " +
                rootObject.main.humidity);
                sb.Append(Environment.NewLine);
                sb.Append("Weather: " +
                rootObject.weather[0].description);
                openWeatherMap.ApiResponse = sb.ToString();

            }
            return openWeatherMap;
        }

        public OpenWeatherMap FillCity()
        {
            OpenWeatherMap openWeatherMap = new OpenWeatherMap
            {
                Cities = new Dictionary<string, string>()
            };
            openWeatherMap.Cities.Add("2643741", "City of London");
            openWeatherMap.Cities.Add("2988507", "Paris");
            openWeatherMap.Cities.Add("2964574", "Dublin");
            openWeatherMap.Cities.Add("4229546", "Washington");
            openWeatherMap.Cities.Add("5128581", "New York");
            openWeatherMap.Cities.Add("1273294", "Delhi");
            openWeatherMap.Cities.Add("1275339", "Mumbai");
            openWeatherMap.Cities.Add("6539761", "Rome");
            openWeatherMap.Cities.Add("2950159", "Berlin");
            openWeatherMap.Cities.Add("292223", "Dubai");
            return openWeatherMap;
        }
    }
}