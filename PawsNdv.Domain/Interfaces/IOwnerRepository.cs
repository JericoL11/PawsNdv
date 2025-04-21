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
        Task<Owner?> GestOwnerWithPetsAsync(int id);

    }
}
