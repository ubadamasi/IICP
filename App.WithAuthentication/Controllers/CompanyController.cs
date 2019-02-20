using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WithAuthentication.Data;
using App.WithAuthentication.Models;
using App.WithAuthentication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.WithAuthentication.Controllers
{
    public class CompanyController : Controller
    {
        #region MyRegion
        private readonly ICompanyRepository _repo;
        private readonly ApplicationDbContext _dbContext;

        public CompanyController(ICompanyRepository repo, ApplicationDbContext dbContext)
        {
            _repo = repo;
            _dbContext = dbContext;
        } 
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //var companies = await _repo.GetCompanies();
            //return View(companies);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Company company)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CompanyViewModel()
                {
                    Company = company,
                };
                return View("CustomerForm", viewModel);
                //return BadRequest();
            }
            if (company.Id ==0)
            {
                company.LogDate = DateTime.Now;
                _repo.Add(company);
            }
            else
            {
                var CompanyInDb = await _repo.GetCompany(company.Id);
                CompanyInDb.Name = company.Name;
                CompanyInDb.RcNumber = company.RcNumber;
                CompanyInDb.Address = company.Address;
                CompanyInDb.Email = company.Email;
                CompanyInDb.Phone = company.Phone;
                CompanyInDb.IsActive = company.IsActive;
                //customerInDb.LogDate = DateTime.Now;


            }
            
            await _repo.SaveAll();

            return RedirectToAction("Index", "Company");
            //return Created(new Uri(Request.Path + "/" + company.Id), company);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var companyDetails = await _repo.GetCompany(Id);

            if (companyDetails == null)
                return NotFound();

            var viewModel = new CompanyViewModel()
            {
                Company = companyDetails,
                ApplicationStatuses = _dbContext.ApplicationStatuses.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var company = await _repo.GetCompany(Id);

            if (company == null)
                return NotFound();


            _repo.Delete(company);
            var result = await _repo.SaveAll();

            return Ok(result);
        }

        public IActionResult CustomerForm()
        {
            var applicationStatus = _dbContext.ApplicationStatuses.ToList();
            var viewModel = new CompanyViewModel()
            {
                ApplicationStatuses = applicationStatus
            };

            return View(viewModel);
        }

        [Route("Company/{Id:int}")]
        public async Task<IActionResult> Details(int Id)
        {
            //var viewModel = new Company();

            var Company = await _repo.GetCompany(Id);
            
            
            return View(Company);
        }
    }
}