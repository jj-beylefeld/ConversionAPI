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
    public class VolumeConverter : IConverter
    {
        public async Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType)
        {
            double resultValue;
            switch (fromType)
            {
                case SupportedTypes.Volume.CubicCentimeters:
                    resultValue = convertValue(Volume.FromCubicCentimeters(fromValue), toType);
                    break;
                case SupportedTypes.Volume.CubicInches:
                    resultValue = convertValue(Volume.FromCubicInches(fromValue), toType);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Volume conversion for enum {0} is not supported", fromType));
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

        private double convertValue(Volume fromVolume, Enum toType)
        {
            double returnValue;
            switch (toType)
            {
                case SupportedTypes.Volume.CubicCentimeters:
                    returnValue = fromVolume.CubicCentimeters;
                    break;
                case SupportedTypes.Volume.CubicInches:
                    returnValue = fromVolume.CubicInches;
                    break;
                default:
                    throw new NotImplementedException(string.Format("Volume conversion for enum {0} is not supported", toType));
            }
            return Math.Round(returnValue, 5);
        }
    }
}
