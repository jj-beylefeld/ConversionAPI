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
    public class SpeedConverter : IConverter
    {
        public async Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType)
        {
            double resultValue;
            switch (fromType)
            {
                case SupportedTypes.Speed.KilometersPerHour:
                    resultValue = convertValue(Speed.FromKilometersPerHour(fromValue), toType);
                    break;
                case SupportedTypes.Speed.MilesPerHour:
                    resultValue = convertValue(Speed.FromMilesPerHour(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Speed conversion for enum {0} is not supported", fromType));
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
            return await Convert(convertRequest.getFromType(), convertRequest.fromValue, convertRequest.getToType()).ConfigureAwait(false);
        }

        private double convertValue(Speed fromSpeed, Enum toType)
        {
            double returnValue;
            switch (toType)
            {
                case SupportedTypes.Speed.KilometersPerHour:
                    returnValue = fromSpeed.KilometersPerHour;
                    break;
                case SupportedTypes.Speed.MilesPerHour:
                    returnValue = fromSpeed.MilesPerHour;
                    break;
                default:
                    throw new NotImplementedException(string.Format("Speed conversion for enum {0} is not supported", toType));
            }
            return Math.Round(returnValue, 5);
        }
    }
}
