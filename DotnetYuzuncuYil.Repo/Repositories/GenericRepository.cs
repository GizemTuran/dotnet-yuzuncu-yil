﻿using DotnetYuzuncuYil.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Repo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); //dbseti verir
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll()
        {
            //asnotracking ile performansta iyileşme olur çekilen veriler okunur,önbelleğe alınmaz.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id) 
        {
           return await _dbSet.FindAsync(id);
        }
        //remove ve update'te entitynin sadece durumu değişir işaretleme yapılır ve veritabanından siler veya günceller.
        public void Remove(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
