using Microsoft.EntityFrameworkCore;
using PawsNdv.Domain.Entites;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Infrastructure.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly PawsNdvContext _context;

        public OwnerRepository(PawsNdvContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Owner?> GestOwnerWithPetsAsync(int id)
        {
            return await _context.Owners
             .Include(o => o.IPet)
             .Include(o => o.Person)
             .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
