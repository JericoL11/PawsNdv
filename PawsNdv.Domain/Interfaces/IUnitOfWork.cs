using PawsNdv.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Interfaces
{
    public interface IUnitOfWork
    {

        IOwnerRepository Owners { get; }
        IGenericRepository<Person> Persons {  get; }

        IGenericRepository<Pet> Pets { get; }

        IGenericRepository<Contact> Contacts { get; }

        Task<int> CompleteAsync();
    }
}
