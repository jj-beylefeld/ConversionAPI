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
    public class TemperatureConverter : IConverter
    {
        public async Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType)
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

        public async Task<IConverterResult> Convert(IConverterRequest convertRequest)
        {
            convertRequest.validate();
            return  await Convert(convertRequest.getFromType(),convertRequest.fromValue, convertRequest.getToType()).ConfigureAwait(false);

        }

        private double convertValue(Temperature fromTemperature, Enum toType)
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
