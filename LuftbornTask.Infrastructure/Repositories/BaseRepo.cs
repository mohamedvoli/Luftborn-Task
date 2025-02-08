using LuftbornTask.Domain.Entities;
using LuftbornTask.Domain.Interfaces;
using LuftbornTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Infrastructure.Repositories
{
    public class BaseRepo<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);
        public async Task DeleteAsync(T entity)
        {
            if (entity is BaseClass baseEntity)
            {
                baseEntity.IsDeleted = true; 
                _context.Set<T>().Update(entity);
            }
            else
            {
                _context.Set<T>().Remove(entity); 
            }
        }
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
