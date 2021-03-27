using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UnitsNet;

namespace ConversionAPITests
{
    public class UnitsNetLearningTests
    {
        [Fact]
        public void convertCelsiusToFahrenheit()
        {
            Assert.Equal(32, Math.Round(Temperature.FromDegreesCelsius(0).DegreesFahrenheit,2));
        }

        [Fact]
        public void convertFahrenheitToCelcius()
        {
            Assert.Equal(0, Math.Round(Temperature.FromDegreesFahrenheit(32).DegreesCelsius,2));
        }

        [Fact]
        public void convertKFToPound()
        {
            Assert.Equal(2.20462, Math.Round(Mass.FromKilograms(1).Pounds,5));
        }

        [Fact]
        public void convertPoundToKG()
        {
            Assert.Equal(1, Math.Round(Mass.FromPounds(2.20462).Kilograms,5));
        }
    }
}
