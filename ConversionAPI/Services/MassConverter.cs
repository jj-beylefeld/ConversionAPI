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
    public class MassConverter : IConverter
    {
        public async Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType)
        {
            double resultValue;
            switch (fromType)
            {
                case SupportedTypes.Mass.Kilograms:
                    resultValue = convertValue(Mass.FromKilograms(fromValue), toType);
                    break;
                case SupportedTypes.Mass.Pounds:
                    resultValue = convertValue(Mass.FromPounds(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Mass conversion for enum {0} is not supported", fromType));
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

        private double convertValue(Mass fromMass, Enum toType)
        {
            double returnValue;
            switch (toType)
            {
                case SupportedTypes.Mass.Kilograms:
                    returnValue = fromMass.Kilograms;
                    break;
                case SupportedTypes.Mass.Pounds:
                    returnValue = fromMass.Pounds;
                    break;
                default:
                    throw new NotImplementedException(string.Format("Mass conversion for enum {0} is not supported", toType));
            }
            return Math.Round(returnValue, 5);
        }
    }
}
