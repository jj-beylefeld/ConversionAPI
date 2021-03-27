﻿using ConversionAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConversionAPI.Classes;
using ConversionAPI.Classes.Interfaces;

namespace ConversionAPITests
{
    public class TemperatureConverterTests
    {
        [Fact]
        public void UnsupportedConversionFromTypeThrowsException()
        {
            ITemperatureConverter temperatureConverter = new TemperatureConverter();
            Assert.Throws<NotImplementedException>(() => temperatureConverter.Convert(SupportedTypes.Temperature.Unsupported,2.25,SupportedTypes.Temperature.Celsius));
        }

        [Fact]
        public void UnsupportedConversionToTypeThrowsException()
        {
            ITemperatureConverter temperatureConverter = new TemperatureConverter();
            Assert.Throws<NotImplementedException>(() => temperatureConverter.Convert(SupportedTypes.Temperature.Fahrenheit, 2.25, SupportedTypes.Temperature.Unsupported));
        }

        [Theory]
        [InlineData(SupportedTypes.Temperature.Celsius,0, SupportedTypes.Temperature.Fahrenheit,32)]
        [InlineData(SupportedTypes.Temperature.Fahrenheit,32, SupportedTypes.Temperature.Celsius,0)]
        public void testSupportedTemperatureConversions(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType, double expectedResult)
        {
            ITemperatureConverter temperatureConverter = new TemperatureConverter();
            IConverterResult convertResult = temperatureConverter.Convert(fromType, fromValue, toType);

            Assert.Equal(expectedResult, convertResult.resultValue);
        }
    }
}
