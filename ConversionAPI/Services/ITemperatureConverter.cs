using ConversionAPI.Classes;
using ConversionAPI.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Services
{
    public interface ITemperatureConverter
    {
        public Task<IConverterResult> Convert(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType);
        public Task<IConverterResult> Convert(IConverterRequest convertRequest);

    }
}
