using CompanyNew.Common.Enums;
using CompanyNew.Data.Model;
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

        #region preview companies

       
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

                DateTime now = DateTime.UtcNow;

                foreach (string employee in employees)
                {
                    Employee newEmployee = new Employee { DateCreated = now, DateModified = now, NameOfEmployee = employee, CompanyId = companyId };
                    uow.EmployeeRepository.Insert(newEmployee);
                }

                uow.Save();

                return companyDb;
            }
        }


        #endregion
        #region add Cars


        public Car AddCars(int employeeId, List<MarkCar> cars)
        {

            using (UnitOfWork uow = new UnitOfWork())
            {
                Employee employeeDb = uow.EmployeeRepository.Find(u => u.EmployeeId == employeeId).FirstOrDefault();
                Common.Helpers.ValidationHelper.ValidateNotNull(employeeDb);

                DateTime now = DateTime.UtcNow;
                Car newCar = null;
                foreach (MarkCar car in cars)
                {
                     newCar = new Car { DateCreated = now, DateModified = now, EmployeeId = employeeId,MarkOfCar = car};
                    uow.CarRepository.Insert(newCar);
                }

                uow.Save();

                return newCar;
            }
        }


        #endregion

        #region preview employees by company


        public List<Employee> PreviewEmployees()
        {

            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<Employee> allEmployee = uow.EmployeeRepository.GetAll();

                    return allEmployee;
                }
            }
        }


        #endregion
    

    }
}