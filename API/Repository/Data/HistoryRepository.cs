﻿using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class HistoryRepository : GeneralRepository<MyContext, History, int>
    {
        public HistoryRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
