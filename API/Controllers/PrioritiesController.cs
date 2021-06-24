using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PrioritiesController : BaseController<Priority, PriorityRepository, int>
    {
        private readonly PriorityRepository priorityRepository;
        public PrioritiesController(PriorityRepository priorityRepository) : base(priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }
    }
}