using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet;
using System.Threading.Tasks;
using ConversionAPI.Classes.Implementation;
using ConversionAPI.Classes;

namespace ConversionAPI.Services
{
    public class LengthConverter : IConverter
    {
        public async Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType)
        {
            double resultValue;
            switch (fromType)
            {
                case SupportedTypes.Length.Meters:
                    resultValue = convertValue(Length.FromMeters(fromValue), toType);
                    break;
                case SupportedTypes.Length.Feet:
                    resultValue = convertValue(Length.FromFeet(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Length conversion for enum {0} is not supported", fromType));
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

        private double convertValue(Length fromLength, Enum toType)
        {
            double returnValue;
            switch (toType)
            {
                case SupportedTypes.Length.Meters:
                    returnValue = fromLength.Meters;
                    break;
                case SupportedTypes.Length.Feet:
                    returnValue = fromLength.Feet;
                    break;
                default:
                    throw new NotImplementedException(string.Format("Length conversion for enum {0} is not supported", toType));
            }
            return Math.Round(returnValue, 5);
        }
    }
}
