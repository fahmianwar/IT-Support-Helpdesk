using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Convertations")]
    public class Convertation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
    }
}
