using CharityEvents.Data.Base;
using CharityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public class CharityCausesService:EntityBaseRepository<CharityCause> , ICharityCauseService
    {
        public CharityCausesService(AppDbContext context) : base(context)//inject dbcontext, pass in the base class
        { }
    }
}
