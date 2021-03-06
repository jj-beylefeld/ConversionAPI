using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Classes
{
    public static class SupportedTypes
    {
        public enum Temperature
        {
            Celsius,
            Fahrenheit,
            Unsupported
        }
        public enum Mass
        {
            Kilograms,
            Pounds,
            Unsupported
        }
        public enum Speed
        {
            KilometersPerHour,
            MilesPerHour,
            Unsupported
        }
        public enum Length
        {
            Feet,
            Meters,
            Unsupported
        }
        public enum Volume
        {
            CubicCentimeters,
            CubicInches,
            Unsupported
        }

        public enum ConverterTypes
        {
            Temperature,
            Length,
            Mass,
            Speed,
            Volume
        }
    }
}
