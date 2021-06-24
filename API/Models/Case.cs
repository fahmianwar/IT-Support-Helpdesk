using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Cases")]
    public class Case
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Review { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
    }
}
