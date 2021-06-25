using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class CaseRepository : GeneralRepository<MyContext, Case, int>
    {
        private readonly MyContext context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<TicketVM> entities;
        public IConfiguration Configuration;
        public CaseRepository(MyContext myContext) : base(myContext)
        {
         
        }
        public int CreateTicket(TicketVM ticketVM)
        {
            var result = 0;
            var cek = context.Cases.FirstOrDefault(cs => cs.Description == ticketVM.Description);
            if (cek == null)
            {
                Case cases = new Case()
                {
                    Description = ticketVM.Description,
                    StartDateTime = ticketVM.StartDateTime,
                    EndDateTime = ticketVM.EndDateTime,
                    Review = ticketVM.Review
                };
                context.Add(cases);
                result = context.SaveChanges();

                Convertation convertation = new Convertation()
                {
                    DateTime = ticketVM.DateTime,
                    Message = ticketVM.Message,
                    CaseId = cases.Id,
                };
                context.Add(convertation);
                result = context.SaveChanges();

                Attachment attachment = new Attachment()
                {
                    Name = ticketVM.Name,
                    FileType = ticketVM.FileType,
                    Extension = ticketVM.Extension,
                    Description = ticketVM.Extension,
                    CreatedOn = ticketVM.CreatedOn,
                    ConvertationId = convertation.Id
                };
                context.Add(attachment);
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
