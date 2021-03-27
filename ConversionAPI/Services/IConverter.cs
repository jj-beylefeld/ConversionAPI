using ConversionAPI.Classes;
using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Services
{
    public interface IConverter
    {
        public Task<IConverterResult> Convert(Enum fromType, double fromValue, Enum toType);
        public Task<IConverterResult> Convert(IConverterRequest convertRequest);

    }
}
