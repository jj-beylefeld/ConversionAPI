using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Classes.Implementation
{
    public class TemperatureConverterRequest : IConverterRequest
    {
        [Required]
        public string fromType { get ; set ; }
        [Required]
        public double fromValue { get ; set ; }
        [Required]
        public string toType { get ; set ; }

        public Enum getFromType()
        {
            if (Enum.TryParse(fromType, true, out SupportedTypes.Temperature thefromType))
                return thefromType;
            return SupportedTypes.Temperature.Unsupported;
        }

        public Enum getToType()
        {
            if (Enum.TryParse(toType, true, out SupportedTypes.Temperature thetoType))
                return thetoType;
            return SupportedTypes.Temperature.Unsupported;
        }

        public void validate()
        {
            if (!Enum.TryParse(fromType, true, out SupportedTypes.Temperature _))
                throw new ArgumentOutOfRangeException(nameof(fromType));
            if (!Enum.TryParse(toType, true, out SupportedTypes.Temperature _))
                throw new ArgumentOutOfRangeException(nameof(toType));
        }
    }
}
