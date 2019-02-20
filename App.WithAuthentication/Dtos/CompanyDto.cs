using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Company name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "RC number is required ")]
        public string RcNumber { get; set; }

        [Required(ErrorMessage = "Company physical address is required")]
        public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime LogDate { get; set; }
    }
}
