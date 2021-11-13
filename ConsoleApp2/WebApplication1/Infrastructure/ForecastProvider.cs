using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Infrastructure
{
    public class ForecastProvider : IForecastProvider
    {
        private IConfiguration _configuration;

        public ForecastProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        public async Task<string> GetForecastAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(
                    $"{_configuration.GetSection("WeatherForecastHost").Value}/weatherforecast");

                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
