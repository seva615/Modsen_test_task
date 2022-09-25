using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Events.Data.DataInterfaces;



namespace Events.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        
        protected IQueryable<TEntity> CollectionWithInclude { get; set; }

        protected GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await CollectionWithInclude.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await CollectionWithInclude.FirstOrDefaultAsync(entity => id == entity.Id);
        }
        
        public TEntity GetEntityById(Guid id)
        {
            return CollectionWithInclude.FirstOrDefault(entity => id == entity.Id);
        }
        

        public async Task Add(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TEntity item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}