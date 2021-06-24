﻿using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class HistoriesController : BaseController<History, HistoryRepository, int>
    {
        private readonly HistoryRepository historyRepository;
        public HistoriesController(HistoryRepository historyRepository) : base(historyRepository)
        {
            this.historyRepository = historyRepository;
        }
    }
}