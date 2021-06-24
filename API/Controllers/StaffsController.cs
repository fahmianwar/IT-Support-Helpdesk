using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class StaffsController : BaseController<Staff, StaffRepository, int>
    {
        private readonly StaffRepository staffRepository;
        public StaffsController(StaffRepository staffRepository) : base(staffRepository)
        {
            this.staffRepository = staffRepository;
        }
    }
}