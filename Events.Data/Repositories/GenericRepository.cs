﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Events.Data.DataInterfaces;
using Events.Data.Entities;

namespace Events.Data.Repositories
{
    public abstract class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;
        protected Microsoft.EntityFrameworkCore.DbSet<TEntity> _dbSet;
        
        protected IQueryable<TEntity> CollectionWithInclude { get; set; }

        public EFGenericRepository(DataContext context)
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

        public async Task Add(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TEntity item)
        { 
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
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