using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Detail { get; set; }
        public virtual User User { get; set; }
    }
}
