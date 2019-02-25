using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WithAuthentication.Data;
using App.WithAuthentication.Dtos;
using App.WithAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WithAuthentication.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region MyRegion
        private readonly ICompanyRepository _repo;

        public CompanyController(ICompanyRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> Companies()
        {
            var companies = await _repo.GetCompanies();
            return Ok(companies);
        }


        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _repo.GetCompany(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyDto vm)
        //public async Task<IActionResult> CreateCompany(string name, string address, string rcNumber, string email, string phone)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = new Company()
            {
                Name = vm.Name,
                Address = vm.Address,
                RcNumber = vm.RcNumber,
                Email = vm.Email,
                Phone = vm.Phone,
                IsActive = true,
                LogDate = DateTime.Now
        };
            _repo.Add(company);
            await _repo.SaveAll();

            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CompanyInDb = await _repo.GetCompany(id);

            if (CompanyInDb == null)
                return NotFound();

            CompanyInDb.Name = company.Name;
            CompanyInDb.RcNumber = company.RcNumber;
            CompanyInDb.Address = company.Address;
            CompanyInDb.Email = company.Email;
            CompanyInDb.Phone = company.Phone;
            CompanyInDb.IsActive = company.IsActive;


            await _repo.SaveAll();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CompanyInDb = await _repo.GetCompany(id);

            _repo.Delete(CompanyInDb);

            await _repo.SaveAll();

            return Ok();
        }
    }
}