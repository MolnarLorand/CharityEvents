using CharityEvents.Data.Base;
using CharityEvents.Data.ViewModels;
using CharityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public interface IBandsService:IEntityBaseRepository<Band>
    {
        //signature
        Task<Band> GetBandByIdAsync(int id);

        Task<NewBandDropdownsVM> GetNewBandDropdownsValues();

        Task AddNewBandAsync(NewBandVM info);

        Task UpdateBandAsync(NewBandVM info);
    }
}
