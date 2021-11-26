using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Application
{
    [ApiController]
    [Route("forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;
        private IForecastProvider _provider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IForecastProvider provider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _provider.GetForecastAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка");
            }
        }
    }
}
