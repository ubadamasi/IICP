using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WithAuthentication.Data;
using App.WithAuthentication.Models;
using App.WithAuthentication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.WithAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        #region Declaration

        private readonly ApplicationDbContext _context;
        public ApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Applications(int Id)
        {
            var newList = new List<ApplicationViewModel>();

            var counter = 1;
            var applications = await _context.Applications.Include(a => a.ApplicationType).Where(x => x.CompanyId == Id).ToListAsync();

            if (applications == null)
                return NotFound();

            foreach (var rec in applications)
            {
                var newRec = new ApplicationViewModel()
                {
                    Counter = counter++,
                    ApplicationType = rec.ApplicationType.Description,
                    ApplicationDate = rec.LogDate.ToLongDateString()
                };

                newList.Add(newRec);
            }

            

            return Ok(newList);
        }
    }
}