using ConversionAPI.Classes.Interfaces;
using ConversionAPI.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConversionAPI.Classes.Implementation;

namespace ConversionAPITests
{
    public class TemperatureConverterRequestTests
    {
        [Fact]
        public void InvalidFromTypeThrowsArgumentOutOfRangeException()
        {
            IConverterRequest converterRequest = new TemperatureConverterRequest { 
                fromType = "Notsupported"
                , fromValue = 0.00
                , toType = "celsius"
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => converterRequest.validate());
        }

        [Fact]
        public void InvaliToTypeThrowsArgumentOutOfRangeException()
        {
            IConverterRequest converterRequest = new TemperatureConverterRequest
            {
                fromType = "celsius"
                , fromValue = 0.00
                , toType = "Notsupported"
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => converterRequest.validate());
        }

        [Fact]
        public void ValidPasses()
        {
            IConverterRequest converterRequest = new TemperatureConverterRequest
            {
                fromType = "celsius"
                , fromValue = 0.00
                , toType = "fahrenheit"
            };
            converterRequest.validate();
        }
    }
}
