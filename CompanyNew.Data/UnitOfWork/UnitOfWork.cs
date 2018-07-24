﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyNew.Data.Model;
using CompanyNew.Data.Repository;

namespace CompanyNew.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        /// <summary>
        /// Data context
        /// </summary>
        private CompanyNewContext context;


        private GenericRepository<Company> companyRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Car> carRepository;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Data context
        /// </summary>
        public CompanyNewContext DataContext
        {
            get
            {
                return context ?? (context = new CompanyNewContext());
            }
        }

        #region Repository



        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                return employeeRepository ?? (employeeRepository = new GenericRepository<Employee>(DataContext));
            }
        }
        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                return companyRepository ?? (companyRepository = new GenericRepository<Company>(DataContext));
            }
        }

        public GenericRepository<Car> CarRepository
        {
            get
            {
                return carRepository ?? (carRepository = new GenericRepository<Car>(DataContext));
            }
        }
        #endregion Repository

        #endregion Properties

        #region Methods

        /// <summary>
        /// Save changes for unit of work async
        /// </summary>
        public async Task SaveAsync()
        {
            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();
        }

        public void Save()
        {
            try
            {
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Methods


        #region IDisposable Members

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context?.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}

