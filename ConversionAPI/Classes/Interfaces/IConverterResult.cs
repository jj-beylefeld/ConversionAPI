using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Classes.Interfaces
{
    public interface IConverterResult
    {
        public string fromType { get; set; }
        public double fromValue { get; set; }
        public string resultType { get; set; }
        public double resultValue { get; set; }
    }
}
