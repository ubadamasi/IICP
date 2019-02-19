using App.WithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.ViewModels
{
    public class CompanyViewModel
    {
        public IEnumerable<ApplicationStatus> ApplicationStatuses { get; set; }
        public Company Company { get; set; }
    }
}
