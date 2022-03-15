using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Template.Application;
using Template.Application.Services;

namespace Template.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public IServiceProvider ServiceProvider => _serviceProvider;
        public ILogger<WeatherForecastController> Logger => _logger;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(int? days = null)
        {
            using var scope = ServiceProvider.CreateScope();
            using var service = scope.ServiceProvider.GetRequiredService<WeatherForecastService>();
            return service.Get(days);
        }
    }
}
