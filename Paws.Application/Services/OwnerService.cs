using AutoMapper;
using Paws.Application.DTOs;
using Paws.Application.Helpers;
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

        public async Task<PagedResponse<OwnerDisplayDto>> GetAllAsync( string? search, int pageNo, int pageSize)
        {
            var (owner, totalCount) = await _uow.Owners.GetAllOwnersAsync(search,pageNo,pageSize); //get the method
            var ownersDto =  _mapper.Map<IEnumerable<OwnerDisplayDto>>(owner);  //mapped
            return new PagedResponse<OwnerDisplayDto>(ownersDto, totalCount); //return to frontend
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
