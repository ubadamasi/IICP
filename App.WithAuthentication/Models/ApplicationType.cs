using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.Models
{
    public class ApplicationType
    {
        public int Id { get; set; }
        public short RegistrationFee { get; set; }
        public byte DurationInMonths { get; set; }
    }
}
