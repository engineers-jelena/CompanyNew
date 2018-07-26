using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.UI;
using AutoMapper;
using CompanyNew.Data.Model;
using CompanyNew.Models;

namespace CompanyNew.Helpers
{
    public class AutoMapperConfigurationProfile : Profile
    {
        public AutoMapperConfigurationProfile()
        {
            CreateMap<Company, RegisterCompanyModel>().ReverseMap();
            CreateMap<Company, CompanyEmployeeModel>().ReverseMap();
            CreateMap<Car, EmployeeCarModel>().ReverseMap();


        }
    }
}