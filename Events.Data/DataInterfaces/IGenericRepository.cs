using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.DataInterfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity item);
        
        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Delete(Guid id);

        Task Edit(TEntity item);

        public TEntity GetEntityById(Guid id);
    }
}