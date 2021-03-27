using ConversionAPI.Classes;
using ConversionAPI.Classes.Implementation;
using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitsNet;

namespace ConversionAPI.Services
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public IConverterResult Convert(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType)
        {
            double resultValue;
            switch (fromType)
            {
                case SupportedTypes.Temperature.Celsius:
                    resultValue = convertValue(Temperature.FromDegreesCelsius(fromValue), toType);
                    break;
                case SupportedTypes.Temperature.Fahrenheit:
                    resultValue = convertValue(Temperature.FromDegreesFahrenheit(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Temperature conversion for enum {0} is not supported", fromType));
            }

            return new ConverterResult
            {
                fromType = fromType.ToString(),
                fromValue = fromValue,
                resultType = toType.ToString(),
                resultValue = resultValue
            };
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
