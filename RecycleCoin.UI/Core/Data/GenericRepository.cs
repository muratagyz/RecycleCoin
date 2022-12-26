﻿using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using System.Linq.Expressions;

namespace RecycleCoin.UI.Core.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly RecycleCoinDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(RecycleCoinDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsTracking().AsQueryable();
        }

        public async Task<T> GetFirstOrDefault()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}