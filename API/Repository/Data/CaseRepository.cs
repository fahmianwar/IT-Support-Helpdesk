﻿using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<TicketVM> entities;
        public CaseRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
            entities = context.Set<TicketVM>();
        }
        public int CreateTicket(TicketVM ticketVM)
        {
            var result = 0;
                Case cases = new Case()
                {
                    Description = ticketVM.Description,
                    StartDateTime = ticketVM.StartDateTime,
                    EndDateTime = ticketVM.EndDateTime,
                    Review = ticketVM.Review,
                    PriorityId = 1,
                    CategoryId = ticketVM.CategoryId
                };
                context.Add(cases);
                result = context.SaveChanges();

                Convertation convertation = new Convertation()
                {
                    DateTime = ticketVM.DateTime,
                    Message = ticketVM.Message,
                    CaseId = cases.Id,
                    UserId = ticketVM.UserId
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
            return result;
        }
    }
}
