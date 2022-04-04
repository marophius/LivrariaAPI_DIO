using LivrariaAPI_DIO.Data;
using LivrariaAPI_DIO.Models;
using LivrariaAPI_DIO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI_DIO.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbset;

        public Repository(DataContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            _dbset.Add(entity);
            await Commit();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await Commit();
            return entity;
        }

        public async Task Delete(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            if(entity == null)
            {
                
            }
            _dbset.Remove(entity);
            await Commit();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbset.AsNoTracking().FirstOrDefaultAsync<T>(x => x.Id == id);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
