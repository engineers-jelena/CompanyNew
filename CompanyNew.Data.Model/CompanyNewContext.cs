using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CompanyNew.Data.Model
{

    public class CompanyNewContext : DbContext
    {
        public CompanyNewContext() : base("name=CompanyNewConnection")
        {
          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
