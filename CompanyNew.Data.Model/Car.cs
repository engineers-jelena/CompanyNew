using CompanyNew.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyNew.Data.Model
{
    
     public class Car : BaseModel
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public MarkCar MarkOfCar { get; set; }

    }
}
