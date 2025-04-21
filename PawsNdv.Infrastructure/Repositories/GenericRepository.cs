using Microsoft.EntityFrameworkCore;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PawsNdvContext _context;
        private readonly DbSet<T> _dbSet;  //for checking if the context is valid
        //direct to Db connection
        public GenericRepository(PawsNdvContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();  //set from _context
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) =>  _dbSet.Remove(entity);


        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
