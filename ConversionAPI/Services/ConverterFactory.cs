using ConversionAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Services
{
    public class ConverterFactory : IConverterFactory
    {
        public IConverter getConverter(SupportedTypes.ConverterTypes converterType)
        {
            switch(converterType)
            {
                case SupportedTypes.ConverterTypes.Temperature:
                    return new TemperatureConverter();
                case SupportedTypes.ConverterTypes.Mass:
                    return new MassConverter();
                case SupportedTypes.ConverterTypes.Speed:
                    return new SpeedConverter();
                case SupportedTypes.ConverterTypes.Length:
                    return new LengthConverter();
                case SupportedTypes.ConverterTypes.Volume:
                    return new VolumeConverter();
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Converter of type {0} is not supported", converterType));
            }
        }
    }
}
