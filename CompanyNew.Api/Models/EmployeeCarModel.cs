using CompanyNew.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyNew.Models
{
    public class EmployeeCarModel
    {
        public List<MarkCar> CarTypes { get; set; }

        public int EmployeeId { get; set; }

       public MarkCar MarkOfCar { get; set; }
    }
}