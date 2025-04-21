using AutoMapper;
using Paws.Application.DTOs;
using Paws.Application.Interfaces;
using PawsNdv.Domain.Entites;
using PawsNdv.Domain.Interfaces;

namespace Paws.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OwnerService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }


        public async Task<IEnumerable<OwnerDisplayDto>> GetAllOwnerAsync()
        {
            var owner = await _uow.Owners.GetAllAsync();
            return _mapper.Map<IEnumerable<OwnerDisplayDto>>(owner);
        }
        public async Task<OwnerDisplayDto?> CreateOwnerAsync(OwnerCreateDto ownerCreateDto)
        {
            //map nested Person
            var person = _mapper.Map<Person>(ownerCreateDto.Person);
            person.IContacts = _mapper.Map<ICollection<Contact>>(ownerCreateDto.Person.Contacts);

            var owner = new Owner
            {
                Person = person,  // // 👈 create the person automatically
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IPet = _mapper.Map<ICollection<Pet>>(ownerCreateDto.Pets)
                
            };

            await _uow.Owners.AddAsync(owner);
            await _uow.CompleteAsync();

            return _mapper.Map<OwnerDisplayDto?>(owner);
        }

        public Task<bool> DeleteOwnerAsync(int id)
        {
            throw new NotImplementedException();
        }

      

        public Task<OwnerDisplayDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOwnerAsync(int id, OwnerUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
