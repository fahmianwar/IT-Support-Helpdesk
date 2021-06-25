using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class TicketVM
    {
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Review { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string DescriptionAtt { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ConvertationId { get; set; }

    }
}
