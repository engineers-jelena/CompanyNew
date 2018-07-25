using CompanyNew.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CompanyNew.Core
{
    public class CompanyManager
    {

        #region Register Company

        public Data.Model.Company Register(Data.Model.Company company)
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
                Data.Model.Company company = uow.CompanyRepository.GetById(companyId);
                Common.Helpers.ValidationHelper.ValidateNotNull(company);

                company.DateDeleted = DateTime.UtcNow;
                uow.CompanyRepository.Update(company);

                uow.Save();
            }
        }

        #endregion

        #region add Employee


        public Data.Model.Company CompanyAddPEmployee(int companyId, List<string> employees)
        {

            using (UnitOfWork uow = new UnitOfWork())
            {
                Data.Model.Company companyDb = uow.CompanyRepository.Find(u => u.Id == companyId).FirstOrDefault();
                Common.Helpers.ValidationHelper.ValidateNotNull(companyDb);

                DateTime now = DateTime.UtcNow;

                foreach (string employee in employees)
                {
                    Data.Model.Employee newEmployee = new Data.Model.Employee { DateCreated = now, DateModified = now, NameOfEmployee = employee, CompanyId = companyId };
                    uow.EmployeeRepository.Insert(newEmployee);
                }

                uow.Save();

                return companyDb;
            }
        }


        #endregion


    }
}