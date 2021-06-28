using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ConvertationRepository : GeneralRepository<MyContext, Convertation, int>
    {
        private readonly MyContext context;
        public ConvertationRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        public int CreateConvertation(Convertation convertation)
        {
            context.Convertations.Add(convertation);
            return context.SaveChanges();
        }

        public IEnumerable<Convertation> ViewConvertations()
        {
            var view = context.Convertations.ToList();
            return view;
        }

        public IEnumerable<Convertation> ViewConvertationsByCaseId(int id)
        {
            var find = context.Convertations.Where(x => x.CaseId == id);
            return find;
        }

        public IEnumerable<Convertation> ViewConvertationsByUserIdAndCaseId(int userId, int caseId)
        {
            var find = context.Convertations.Where(x => x.UserId == userId && x.CaseId == caseId);
            return find;
        }
    }
}
