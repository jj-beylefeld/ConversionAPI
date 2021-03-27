using ConversionAPI.Classes.Implementation;
using ConversionAPI.Classes.Interfaces;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        protected readonly ITemperatureConverter _temperatureConverter;

        public TemperatureController(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter ?? throw new ArgumentNullException(nameof(temperatureConverter));
        }

        [HttpPost]
        //[Route("convert")]
        [Produces("application/json", Type = typeof(ConverterResult))]
        public async Task<IActionResult> convert([FromBody]TemperatureConverterRequest request)
        {
            var res = await _temperatureConverter.Convert(request).ConfigureAwait(false);
            return Ok(res);
        }
    }
}
