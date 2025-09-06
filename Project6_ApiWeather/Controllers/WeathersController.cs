using Microsoft.AspNetCore.Mvc;
using Project6_ApiWeather.context;

// yanlış olan satır: using Project6_ApiWeather.context;
using Project6_ApiWeather.context;   // ✅ büyük harf ile doğru
using Project6_ApiWeather.Entities;

namespace Project6_ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly WeatherContext context;

        // ✅ Context constructor’dan alınmalı
        public WeathersController(WeatherContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Şehir eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value=context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir silindi");
        }

        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value=context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.Detail = city.Detail;
            value.Tempruter = city.Tempruter;
            value.Country = city.Country;
            context.SaveChanges();
            return Ok("Şehir Güncellendi");

        }
        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIIWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }



        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var value = context.Cities.Count();
            return Ok(value);
        }
        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value = context.Cities.OrderByDescending(x=>x.Tempruter).Select(y=>y.CityName).FirstOrDefault();
            return Ok(value);
        }

        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.Tempruter).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }
    }
}
