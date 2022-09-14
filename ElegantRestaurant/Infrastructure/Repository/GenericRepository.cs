using Domain.Interfaces;
using Infrastructure.Entities.Base;
using Infrastructure.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IAsyncRepository<T> where T : EntityBase<int>
    {
        private readonly RestaurantDbContext db;
        public GenericRepository()
        {
            db = new RestaurantDbContext();
        }
        public async Task<T> Add(T entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var toDelete = await db.Set<T>().Where(model => model.Id == id).FirstOrDefaultAsync();
            db.Remove(toDelete);
            await db.SaveChangesAsync();
            return toDelete;
        }

        public async Task<T> Get(int id)
        {
            return await db.Set<T>().Where(model => model.Id == id).FirstOrDefaultAsync(); 
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public IAsyncEnumerable<T> GetAll()
        {
            return db.Set<T>().AsAsyncEnumerable();
        }

        public IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).AsAsyncEnumerable();
        }
    }
}
