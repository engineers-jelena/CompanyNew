using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CompanyNew.Data.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
