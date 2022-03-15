using Infrastructure.Configuration.Configurations;
using Infrastructure.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Application.Constants;
using Template.Application.Services.Base;

namespace Template.Application.Services
{
    public class WeatherForecastService : ServiceBase<WeatherForecast>
    {
        private MainConfiguration _options;
        private DapperOptions _dapperOptions;
        private string[] Summaries => Weather.Summaries;

        public WeatherForecastService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory, IOptionsSnapshot<MainConfiguration> options)
            : base(loggerFactory, serviceProvider)
        {
            _options = options.Value;
            _dapperOptions = _options.DapperOptions;
        }

        public IEnumerable<WeatherForecast> Get(int? days)
        {
            var rng = new Random();
            return Enumerable.Range(1, (int)(days.HasValue ? days : 5)).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
