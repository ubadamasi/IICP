using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.Dtos
{
    public class CompanyDto
    {
        
        public string Name { get; set; }

        public string RcNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
