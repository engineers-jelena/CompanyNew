﻿using CompanyNew.Data.Model;
using CompanyNew.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CompanyNew.Core
{
    public class CompanyManager
    {

        #region Register Company

        public Company Register(Company company)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                company.DateModified = DateTime.UtcNow;
                company.DateCreated = DateTime.UtcNow;
                uow.CompanyRepository.Insert(company);
                uow.Save();
                uow.CompanyRepository.GetById(company.Id);
                return company;
            }
        }

        #endregion

        #region Delete Company


        public void DeleteCompanyById(int companyId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Company company = uow.CompanyRepository.GetById(companyId);
                Common.Helpers.ValidationHelper.ValidateNotNull(company);

                company.DateDeleted = DateTime.UtcNow;
                uow.CompanyRepository.Update(company);

                uow.Save();
            }
        }

        #endregion

        #region

       
            public List<Company> PreviewAllCompanies()
        {

            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<Company> allCompanies = uow.CompanyRepository.GetAll();

                    return allCompanies;
                }
            }
        }


        #endregion

        #region add Employee


        public Data.Model.Company CompanyAddPEmployee(int companyId, List<string> employees)
        {

            using (UnitOfWork uow = new UnitOfWork())
            {
                Company companyDb = uow.CompanyRepository.Find(u => u.Id == companyId).FirstOrDefault();
                Common.Helpers.ValidationHelper.ValidateNotNull(companyDb);

                //DateTime now = DateTime.UtcNow;

                foreach (string employee in employees)
                {
                    Employee newEmployee = new Employee { /*DateCreated = now, DateModified = now,*/ NameOfEmployee = employee, CompanyId = companyId };
                    uow.EmployeeRepository.Insert(newEmployee);
                }

                uow.Save();

                return companyDb;
            }
        }


        #endregion


    }
}