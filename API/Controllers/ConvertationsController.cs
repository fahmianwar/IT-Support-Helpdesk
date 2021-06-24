using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ConvertationsController : BaseController<Convertation, ConvertationRepository, int>
    {
        private readonly ConvertationRepository convertationRepository;
        public ConvertationsController(ConvertationRepository convertationRepository) : base(convertationRepository)
        {
            this.convertationRepository = convertationRepository;
        }
    }
}