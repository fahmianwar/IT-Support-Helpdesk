using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
        public int StaffId { get; set; }
        public int ClientId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Convertation> Convertation { get; set; }

    }
}
