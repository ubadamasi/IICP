using App.WithAuthentication.Dtos;
using App.WithAuthentication.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WithAuthentication.AutoMapperProfile
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
