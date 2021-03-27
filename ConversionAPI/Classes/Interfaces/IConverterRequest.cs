using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionAPI.Classes.Interfaces
{
    public interface IConverterRequest
    {
        [Required]
        public string fromType { get; set; }
        [Required]
        public double fromValue { get; set; }
        [Required]
        public string toType { get; set; }

        public void validate();
    }
}
