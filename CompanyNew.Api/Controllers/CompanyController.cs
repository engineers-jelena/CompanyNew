using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using CompanyNew.Data.Model;
using System.Net.Mail;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Http.Results;
using AutoMapper;
using CompanyNew.Common.Enums;
using CompanyNew.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using CompanyNew.Models;
using CompanyNew.Helpers;
using System.Web.Util;

namespace CompanyNew.Controllers
{
    public class CompanyController : BaseController
    {

        #region Company Register


        [ValidateModel]
        [HttpPost]
        public object Register(RegisterCompanyModel model)
        {
         
            Company company = new Company { nameOfCompany = model.nameOfCompany };
            Company registeredCompany = CompanyManager.Register(company);
            RegisterCompanyModel modelNew = Mapper.Map<RegisterCompanyModel>(company);

            return new { modelNew };

        }



        #endregion

        #region Preview all companies

        [AllowAnonymous]
        [HttpGet]
        public List<Company> PreviewCompanies()
        {
            List<Company> listOfAllCompanies = CompanyManager.PreviewAllCompanies();
            return listOfAllCompanies;
        }


        #endregion

        #region Company Delete

        [AllowAnonymous]
        [HttpGet]
        public bool DeleteCompany(int companyId)
        {
            CompanyManager.DeleteCompanyById(companyId);
            return true;
        }

        #endregion

        #region

        [AllowAnonymous]
        [HttpPost]
        public CompanyEmployeeModel AddEmployees(CompanyEmployeeModel model)
        {
            Company companyDb = CompanyManager.CompanyAddPEmployee(model.idCompany, model.NameEmployee);
            CompanyEmployeeModel viewModel = Mapper.Map<CompanyEmployeeModel>(companyDb);
            viewModel.NameEmployee = companyDb.Employees.Select(u => u.NameOfEmployee).ToList();

            return viewModel;
        }

        #endregion

    }
}