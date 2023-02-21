using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;

namespace GunlukHavaDurumu.Controllers
{
    public class WeatherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string ApiKey = "911409a5538c3cf98e9ae9481184c935";
            string BaseUrl = "https://api.openweathermap.org/data/2.5/weather?q=burdur&mode=xml&lang=tr&units=metric&appid=" + ApiKey;
            XDocument weather = XDocument.Load(BaseUrl);

            var cityName = weather.Descendants("city").FirstOrDefault()?.Attribute("name")?.Value;
            var temp = weather.Descendants("temperature").FirstOrDefault()?.Attribute("value")?.Value;
            var feelsLike = weather.Descendants("feels_like").FirstOrDefault()?.Attribute("value")?.Value;
            var weatherState = weather.Descendants("weather").FirstOrDefault()?.Attribute("value")?.Value;

            ViewBag.cityName = cityName;
            ViewBag.temp = temp;
            ViewBag.feelsLike = feelsLike;
            ViewBag.weatherState = weatherState;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            string ApiKey = "911409a5538c3cf98e9ae9481184c935";
            string BaseUrl = "https://api.openweathermap.org/data/2.5/weather?q=" + name + "&mode=xml&lang=tr&units=metric&appid=" + ApiKey;
            XDocument weather = XDocument.Load(BaseUrl);

            var cityName = weather.Descendants("city").FirstOrDefault()?.Attribute("name")?.Value;
            var temp = weather.Descendants("temperature").FirstOrDefault()?.Attribute("value")?.Value;
            var feelsLike = weather.Descendants("feels_like").FirstOrDefault()?.Attribute("value")?.Value;
            var weatherState = weather.Descendants("weather").FirstOrDefault()?.Attribute("value")?.Value;

            ViewBag.cityName = cityName;
            ViewBag.temp = temp;
            ViewBag.feelsLike = feelsLike;
            ViewBag.weatherState = weatherState;

            return View();
        }
    }
}
