using PawsNdv.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Interfaces
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        Task<(IEnumerable<Owner>? Owners, int TotalCount)> GetAllOwnersAsync( string? search, int pageNo, int pageSize);
        Task<Owner?> GestOwnerWithPetsAsync(int id);

    }
}
