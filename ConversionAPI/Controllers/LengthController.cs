using ConversionAPI.Classes;
using ConversionAPI.Classes.Implementation;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LengthController : Controller
    {
        protected readonly IConverterFactory _converterFactory;

        public LengthController(IConverterFactory converterFactory)
        {
            _converterFactory = converterFactory ?? throw new ArgumentNullException(nameof(converterFactory));
        }

        [HttpPost]
        [Route("convert")]
        [Produces("application/json", Type = typeof(ConverterResult))]
        public async Task<IActionResult> convert([FromBody] LengthConverterRequest request)
        {
            var res = await _converterFactory.getConverter(SupportedTypes.ConverterTypes.Length).Convert(request).ConfigureAwait(false);
            return Ok(res);
        }

        [HttpGet]
        [Route("converterTypes")]
        [Produces("application/json", Type = typeof(List<string>))]
        public async Task<IActionResult> getConverterTypes()
        {
            return Ok(Enum.GetNames(typeof(SupportedTypes.Length)));
        }
    }
}
