using ConversionAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitsNet;

namespace ConversionAPI.Services
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public double Convert(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType)
        {
            switch (fromType)
            {
                case SupportedTypes.Temperature.Celsius: 
                    return convertValue(Temperature.FromDegreesCelsius(fromValue), toType);
                case SupportedTypes.Temperature.Fahrenheit:
                    return convertValue(Temperature.FromDegreesFahrenheit(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Temperature conversion for enum {0} is not supported", fromType));
            }
        }

        private double convertValue(Temperature fromTemperature, SupportedTypes.Temperature toType)
        {
            double returnValue=0;
            switch (toType)
            {
                case SupportedTypes.Temperature.Fahrenheit:
                    returnValue = fromTemperature.DegreesFahrenheit;
                    break;
                case SupportedTypes.Temperature.Celsius:
                    returnValue = fromTemperature.DegreesCelsius;
                    break;
                default:
                    throw new NotImplementedException(string.Format("Temperature conversion for enum {0} is not supported", toType));
            }
            return Math.Round(returnValue,5);
        }

    }
}
