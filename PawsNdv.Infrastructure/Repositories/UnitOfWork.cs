using PawsNdv.Domain.Entites;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;


namespace PawsNdv.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PawsNdvContext _context;

        public UnitOfWork(PawsNdvContext context)
        {
            this._context = context;

            Persons = new GenericRepository<Person>(_context);
            //follow the from chatgpt

        }
        public IGenericRepository<Person> Persons { get; private set; }

        public IGenericRepository<Pet> Pets { get; private set; }

        public IGenericRepository<Contact> Contacts { get; private set; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    }
}
