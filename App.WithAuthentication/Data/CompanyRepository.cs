using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WithAuthentication.Dtos;
using App.WithAuthentication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.WithAuthentication.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            return companies;
            //var companies = _dbContext.Companies.ToList().Select(Mapper.Map<Company, CompanyDto>);
            //var companies2 = companies.ToList();
            //var companies3 = await companies2.tolist

        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _dbContext.Companies.SingleOrDefaultAsync(c => c.Id == id);
            return company;
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
