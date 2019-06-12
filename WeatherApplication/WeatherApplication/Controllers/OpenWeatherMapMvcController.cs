using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using WeatherApplication.Class;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        private WeatherBehaviour weatherBehaviour { get; set; }
        private FileCreation FileCreation { get; set; }
        private OpenWeatherMap OpenWeatherMap { get; set; }

        // Constructor type Dependency Injection can be applied, so that you have to create objects here 
        public OpenWeatherMapMvcController()
        {
            weatherBehaviour = new WeatherBehaviour();
            FileCreation = new FileCreation();
        }
        
        // GET: OpenWeatherMapMvc
        public ActionResult Index()
        {
            OpenWeatherMap = weatherBehaviour.FillCity();
            return View(OpenWeatherMap);
        }

        

        [HttpPost]
        public ActionResult Index(OpenWeatherMap openWeatherMap, string cities)
        {
            openWeatherMap = weatherBehaviour.GetDataFromOpenWeatherApi(cities);
            FileCreation.CreateFileByCityName(openWeatherMap.ApiResponse, cities);
            return View(openWeatherMap);
        }

        
    }
}