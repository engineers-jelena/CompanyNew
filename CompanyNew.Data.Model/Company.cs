using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyNew.Data.Model
{
    public class Company : BaseModel
    {

        public string nameOfCompany { get; set; }

        public virtual List<Employee> Employees { get; set; }

    }
}
