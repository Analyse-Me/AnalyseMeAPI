using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AnalyseMeAPI.Models;
using AnalyseMeAPI.Services;

namespace AnalyseMeAPI.Controllers
{
    [ApiController]
    [Route("weatherforecastt")]
    public class WeatherForecastController : ControllerBase {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastService WeatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger) {
            _logger = logger;
            WeatherForecastService = new WeatherForecastService();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() {
            return WeatherForecastService.Get();
        }
    }
}
