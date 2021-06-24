using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Staff")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Detail { get; set; }

        public virtual 
    }
}
