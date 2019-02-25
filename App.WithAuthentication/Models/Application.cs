using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.Models
{
    public class Application
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public int ApplicationTypeId { get; set; }
        public DateTime LogDate { get; set; }

    }
}
