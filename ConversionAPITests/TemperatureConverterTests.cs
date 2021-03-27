using ConversionAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConversionAPI.Classes;
using ConversionAPI.Classes.Interfaces;
using System.Threading.Tasks;

namespace ConversionAPITests
{
    public class TemperatureConverterTests
    {
        [Fact]
        public void UnsupportedConversionFromTypeThrowsException()
        {
            IConverter temperatureConverter = new TemperatureConverter();
            Assert.ThrowsAsync<NotImplementedException>(() => temperatureConverter.Convert(SupportedTypes.Temperature.Unsupported,2.25,SupportedTypes.Temperature.Celsius));
        }

        [Fact]
        public void UnsupportedConversionToTypeThrowsException()
        {
            IConverter temperatureConverter = new TemperatureConverter();
            Assert.ThrowsAsync<NotImplementedException>(() => temperatureConverter.Convert(SupportedTypes.Temperature.Fahrenheit, 2.25, SupportedTypes.Temperature.Unsupported));
        }

        [Theory]
        [InlineData(SupportedTypes.Temperature.Celsius,0, SupportedTypes.Temperature.Fahrenheit,32)]
        [InlineData(SupportedTypes.Temperature.Fahrenheit,32, SupportedTypes.Temperature.Celsius,0)]
        public void testSupportedTemperatureConversions(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType, double expectedResult)
        {
            IConverter temperatureConverter = new TemperatureConverter();
            Task<IConverterResult> convertResult = temperatureConverter.Convert(fromType, fromValue, toType);
            Assert.Equal(expectedResult, convertResult.Result.resultValue);
        }

        [Fact]
        public void ConvertMustReturnIConverterResult()
        {
            IConverter temperatureConverter = new TemperatureConverter();
            Assert.IsAssignableFrom<Task<IConverterResult>>(temperatureConverter.Convert(SupportedTypes.Temperature.Fahrenheit, 2.25, SupportedTypes.Temperature.Celsius));
        }
    }
}
