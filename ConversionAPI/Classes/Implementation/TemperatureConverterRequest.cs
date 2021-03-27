using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Classes.Implementation
{
    public class TemperatureConverterRequest : IConverterRequest
    {
        public string fromType { get ; set ; }
        public double fromValue { get ; set ; }
        public string toType { get ; set ; }

        public void validate()
        {
            if (!Enum.TryParse(fromType, true, out SupportedTypes.Temperature thefromType))
                throw new ArgumentOutOfRangeException(nameof(fromType));

            if (!Enum.TryParse(toType, true, out SupportedTypes.Temperature thetoType))
                throw new ArgumentOutOfRangeException(nameof(toType));
        }
    }
}
