using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
                    Level = 1,
                    UserId = ticketVM.UserId,
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
        public IEnumerable<CaseVM> GetCase()
        {
            Case cases = new Case();
            var all = (
                from c in context.Cases
                join u in context.Users on c.UserId equals u.Id
                join p in context.Priorities on c.PriorityId equals p.Id
                join ct in context.Categories on c.CategoryId equals ct.Id 
                select new CaseVM
                {
                    Id = c.Id,
                    Description = c.Description,
                    StartDateTime = c.StartDateTime,
                    EndDateTime = c.EndDateTime,
                    Review = c.Review,
                    Level = c.Level,
                    UserId = u.Id,
                    UserName = u.Name,
                    PriorityName = p.Name,
                    CategoryName = ct.Name
                }).ToList();
            return all;
        }

        public IEnumerable<CaseVM> ViewTicketsByUserId(int userId)
        {
            Case cases = new Case();
            var all = (
                from c in context.Cases
                join u in context.Users on c.UserId equals u.Id
                join p in context.Priorities on c.PriorityId equals p.Id
                join ct in context.Categories on c.CategoryId equals ct.Id
                select new CaseVM
                {
                    Id = c.Id,
                    Description = c.Description,
                    StartDateTime = c.StartDateTime,
                    EndDateTime = c.EndDateTime,
                    Review = c.Review,
                    Level = c.Level,
                    UserId = u.Id,
                    UserName = u.Name,
                    PriorityName = p.Name,
                    CategoryName = ct.Name
                }).ToList();
            return all.Where(x => x.UserId == userId);
        }

        public IEnumerable<Case> GetCases()
        {
            var all = context.Cases.Where(x => x.EndDateTime == null).OrderByDescending(x => x.StartDateTime);
            return all;
        }

        public IEnumerable<CaseVM> ViewTicketsByStaffId(int userId)
        {
            var history = context.Histories.OrderByDescending(e => e.DateTime).Where(x => x.UserId == userId).Select(c => c.CaseId);
            Case cases = new Case();
            var all = (
                from c in context.Cases
                join u in context.Users on c.UserId equals u.Id
                join p in context.Priorities on c.PriorityId equals p.Id
                join ct in context.Categories on c.CategoryId equals ct.Id
                select new CaseVM
                {
                    Id = c.Id,
                    Description = c.Description,
                    StartDateTime = c.StartDateTime,
                    EndDateTime = c.EndDateTime,
                    Review = c.Review,
                    Level = c.Level,
                    UserId = u.Id,
                    UserName = u.Name,
                    PriorityName = p.Name,
                    CategoryName = ct.Name
                }).ToList();
            return all.Where(x => history.Contains(x.Id));
        }

        public IEnumerable<CaseVM> ViewTicketsByLevel(int level)
        {
            Case cases = new Case();
            var all = (
                from c in context.Cases
                join u in context.Users on c.UserId equals u.Id
                join p in context.Priorities on c.PriorityId equals p.Id
                join ct in context.Categories on c.CategoryId equals ct.Id
                //join h in context.Histories on c.Id equals h.CaseId orderby h.DateTime descending
                select new CaseVM
                {
                    Id = c.Id,
                    Description = c.Description,
                    StartDateTime = c.StartDateTime,
                    EndDateTime = c.EndDateTime,
                    Review = c.Review,
                    Level = c.Level,
                    UserId = u.Id,
                    UserName = u.Name,
                    PriorityName = p.Name,
                    CategoryName = ct.Name
                }).ToList();
            return all.Where(x => x.EndDateTime == null && x.Level == level).OrderByDescending(x => x.StartDateTime);
        }

        public int AskNextLevel(int caseId)
        {
            int result = 0;

            var get = context.Histories.OrderByDescending(e => e.DateTime).FirstOrDefault(x => x.CaseId == caseId);
            if(get == null)
            {
                return 0;
            }
            var cases = context.Cases.Find(caseId);
            if(cases == null)
            {
                return 0;
            }
            cases.Level = cases.Level + 1;

            context.Cases.Update(cases);
            context.SaveChanges();

            if (get.Level < 3) {
                var history = new History()
                {
                    DateTime = DateTime.Now,
                    Level = get.Level + 1,
                    Description = $"[STAFF] UserId #{get.UserId} Ask Help CaseId #{caseId} to Level #{get.Level + 1}",
                    UserId = get.UserId,
                    CaseId = get.CaseId,
                    StatusCodeId = 2
                };

                context.Histories.Add(history);
                result = context.SaveChanges();
            }
            return result;
        }

        public int HandleTicket(CloseTicketVM closeTicketVM)
        {
            int result = 0;

            var get = context.Histories.OrderByDescending(e => e.DateTime).FirstOrDefault(x => x.CaseId == closeTicketVM.CaseId);
            if (get.Level < 3)
            {
                var history = new History()
                {
                    DateTime = DateTime.Now,
                    Description = $"[STAFF] StaffId #{closeTicketVM.UserId} Handling CaseId #{closeTicketVM.CaseId}",
                    UserId = closeTicketVM.UserId,
                    Level = get.Level,
                    CaseId = get.CaseId,
                    StatusCodeId = 2
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
                    StatusCodeId = 3
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
            if(cases == null)
            {
                return result;
            }
            if (cases.EndDateTime != null)
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
