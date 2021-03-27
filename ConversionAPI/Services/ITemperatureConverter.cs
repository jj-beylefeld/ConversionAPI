using ConversionAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Services
{
    public interface ITemperatureConverter
    {
        public double Convert(SupportedTypes.Temperature fromType, double fromValue, SupportedTypes.Temperature toType);
    }
}
