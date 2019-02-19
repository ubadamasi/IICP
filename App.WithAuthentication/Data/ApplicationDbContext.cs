using System;
using System.Collections.Generic;
using System.Text;
using App.WithAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.WithAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        //public DbSet<ApplicationType> ApplicationTypes { get; set; }
    }
}
