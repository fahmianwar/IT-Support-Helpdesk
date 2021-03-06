using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? EndDateTime { get; set; }
        public int? Review { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }
        public int? StaffId { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Convertation> Convertation { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Category Category { get; set; }
    }
}
