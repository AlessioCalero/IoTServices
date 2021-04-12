using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("mia/{deviceId}")]
        public DeviceResult MyApi(string deviceId)
        {
            DeviceResult res = new DeviceResult();
            res.Nome = "Alessio";
            res.Cognome = "Calero";
            res.Response = "OK";
            res.Status = 3;
            res.IDTessera = deviceId;
            return res;
        }

        [HttpPost("swipe")]
        public DeviceResult Swipe([FromBody] SwipeInput input)
        {
            DeviceResult res = new DeviceResult();
            res.IDTessera = input.IDTessera;
            res.IDGateway = input.IDGateway;
            res.Nome = "Alessio ";
            res.Cognome = "Calero "+ input.IDGateway;
            res.Response = "OK";
            res.Status = 3;
            return res;
        }

        [HttpGet("prova/{file}")]
        public string prova (string file)
        {
            string riga = System.IO.File.ReadAllText(@"C:\Users\STUDENTE\Desktop\" + file);
            return riga;
        }
    }
}
