﻿using ConversionAPI.Classes;
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
        //protected readonly IConverter _temperatureConverter;
        protected readonly IConverterFactory _converterFactory;

        public TemperatureController(IConverterFactory converterFactory)
        {
            _converterFactory = converterFactory ?? throw new ArgumentNullException(nameof(converterFactory));
        }

        [HttpPost]
        [Route("convert")]
        [Produces("application/json", Type = typeof(ConverterResult))]
        public async Task<IActionResult> convert([FromBody]TemperatureConverterRequest request)
        {
            var res = await _converterFactory.getConverter(SupportedTypes.ConverterTypes.Temperature).Convert(request).ConfigureAwait(false);
            return Ok(res);
        }

        [HttpPost]
        [Route("converterTypes")]
        [Produces("application/json", Type = typeof(List<string>))]
        public async Task<IActionResult> getConverterTypes()
        {
            return Ok(Enum.GetNames(typeof(SupportedTypes.Temperature)));
        }
    }
}
