using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WithAuthentication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WithAuthentication.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repo;

        public CompanyController(ICompanyRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return Ok(await _repo.GetCompanies());
        }
    }
}