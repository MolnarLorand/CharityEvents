using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CharityEvents.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        //i mage a generic solution using T, instead of repeating the code for every view where i need the crud operations
        //pentru a elimina redundanta codului
        Task<IEnumerable<T>> GetAllAsync();

        //Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties); 

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);//id bc i check if id exist in db

        Task DeleteAsync(int id);
    }
}
