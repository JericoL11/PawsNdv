using Microsoft.EntityFrameworkCore;
using PawsNdv.Domain.Entites;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;

namespace PawsNdv.Infrastructure.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly PawsNdvContext _context;

        public OwnerRepository(PawsNdvContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<Owner?> GetOwnerWithPetsAsync(int id)
        {
           var owner = await _context.Owners
             .Include(o => o.IPet)
             .Include(o => o.Person)
                .ThenInclude(p => p.IContacts)
             .FirstOrDefaultAsync(o => o.Id == id);

            if (owner == null)
            {
                return null;
            }

            return owner;
        }

        public async Task<(IEnumerable<Owner>? Owners, int TotalCount)> GetAllOwnersAsync(string? search, int pageNo, int pageSize)
        {
            //declare queryable
            var query = _context.Owners
                  .Include(o => o.Person)
                      .ThenInclude(p => p.IContacts)
                  .AsQueryable();

            //check search
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o => o.Person.FirstName.Contains(search) || o.Person.LastName.Contains(search));
            }

            var totalCount = await query.CountAsync();

            var owners = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (owners, totalCount);

        }

        public async Task<Owner> GetOwnerById(int id)
        {
            var owner = await _context.Owners
                .Include(o => o.Person)
                .ThenInclude(p => p.IContacts)
                .FirstOrDefaultAsync( o => o.Id == id);

            if (owner is null)
            {
                return null;
            }

            return owner;
        }
    }
}
