using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConversionAPI.Classes.SupportedTypes;

namespace ConversionAPI.Services
{
    public interface IConverterFactory
    {
        public IConverter getConverter(ConverterTypes converterType);
    }
}
