using API.Context;
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

        public CaseRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }
        public int CreateTicket(TicketVM ticketVM)
        {
            var result = 0;
            {
                Case cases = new Case()
                {
                    Description = ticketVM.Description,
                    StartDateTime = DateTime.Now,
                    Review = 0,
                    PriorityId = 1,
                    CategoryId = ticketVM.CategoryId
                };
                context.Add(cases);
                result = context.SaveChanges();

                //Convertation convertation = new Convertation()
                //{
                //    DateTime = DateTime.Now,
                //    Message = ticketVM.Message,
                //    CaseId = cases.Id,
                //    UserId = ticketVM.UserId
                //};
                //context.Add(convertation);
                //result = context.SaveChanges();

                History history = new History()
                {
                    CaseId = cases.Id,
                    Description = "[SYSTEM] Client create Ticket and Ask Customer Service",
                    DateTime = DateTime.Now,
                    Level = 1,
                    UserId = ticketVM.UserId,
                    StatusCodeId = 1
                };
                context.Add(history);
                result = context.SaveChanges();

                //Attachment attachment = new Attachment()
                //{
                //    Name = ticketVM.Name,
                //    FileType = ticketVM.FileType,
                //    Extension = ticketVM.Extension,
                //    Description = ticketVM.Extension,
                //    CreatedOn = ticketVM.CreatedOn,
                //    ConvertationId = convertation.Id
                //};
                //context.Add(attachment);
                //result = context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Case> ViewTicketsByUserId(int userId)
        {
            var all = context.Cases.Where(x => x.UserId == userId);
            return all;
        }

        public IEnumerable<Case> ViewTicketsByLevel(int level)
        {
            // Cases sama HIstory, dapetin caseId di History yang levelnya sesuai parameter
            //var all = context.Cases.ToList();
            //var allHistory = context.Histories;
            //var history = allHistory.Where(x => x.Level == level);
            //return all;
            //var result = (from h in context.Histories
            //              join c in context.Cases on h.CaseId equals c.Id
            //              select new TicketByLevelVM
            //              {
            //                  RoleId = h.Level,
            //                  CaseId = c.Id,
            //                  UserId = h.UserId

            //              }).ToList();
            //var result = from blabla in context.cases
            //             select blabla.caseId;

            //var result = (from h in context.Histories
            //              join c in context.Cases on h.CaseId equals c.Id
            //              where (from h1 in context.Histories
            //                     join c1 in context.Cases on h1.CaseId equals c1.Id
            //                     orderby h.DateTime descending
            //                     select h.Level).FirstOrDefault(x => x.Id ==) == level
            //              select h.CaseId);

            //var getLatest = (from h in context.Histories
            //                 join c in context.Cases on h.CaseId equals c.Id
            //                 orderby h.DateTime descending
            //                 select h.CaseId);
            var getLatest = context.Cases.Where(x => x.Level == level);
            //List<int> caseList = result.ToList();

            return getLatest;
        }

        public int AskNextLevel(int caseId)
        {
            int result = 0;

            var get = context.Histories.OrderByDescending(e => e.DateTime).FirstOrDefault(x => x.CaseId == caseId);
            if(get.Level < 3) {
                var history = new History()
                {
                    DateTime = DateTime.Now,
                    Level = get.Level + 1,
                    Description = $"[STAFF] UserId #{get.UserId} Ask Help CaseId #{caseId} to Level #{get.Level + 1}",
                    UserId = get.UserId,
                    CaseId = get.CaseId,
                    StatusCodeId = get.StatusCodeId
                };

                context.Histories.Add(history);
                result = context.SaveChanges();
            }
            return result;
        }

            public int CloseTicketById(CloseTicketVM closeTicketVM)
        {
            var cases = context.Cases.Find(closeTicketVM.CaseId);
            if (cases.EndDateTime == null)
            {
                cases.EndDateTime = DateTime.Now;
                context.Cases.Update(cases);
                context.SaveChanges();

                var lastHistory = context.Histories.OrderByDescending(e => e.DateTime).FirstOrDefault(x => x.CaseId == closeTicketVM.CaseId);
                History newHistory = new History()
                {
                    CaseId = cases.Id,
                    Description = $"[SYSTEM] Closed Ticket By Staff #{closeTicketVM.UserId}",
                    DateTime = DateTime.Now,
                    Level = lastHistory.Level,
                    UserId = closeTicketVM.UserId,
                    StatusCodeId = lastHistory.StatusCodeId
                };
                context.Histories.Add(newHistory);
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }


        public int ReviewTicket(ReviewTicketVM reviewTicketVM)
        {
            int result = 0;
            var cases = context.Cases.Find(reviewTicketVM.CaseId);
            if (cases.EndDateTime == null)
            {
                cases.Review = reviewTicketVM.Review;
                context.Cases.Update(cases);
                result = context.SaveChanges();

                var lastHistory = context.Histories.OrderByDescending(e => e.DateTime).FirstOrDefault();
                History newHistory = new History()
                {
                    CaseId = cases.Id,
                    Description = $"[CLIENT] Ticket #{cases.Id} Reviewed by User #{reviewTicketVM.UserId}",
                    DateTime = DateTime.Now,
                    Level = lastHistory.Level,
                    UserId = reviewTicketVM.UserId,
                    StatusCodeId = lastHistory.StatusCodeId
                };
                context.Histories.Add(newHistory);
                result = context.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
