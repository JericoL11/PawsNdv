using AutoMapper;
using FluentValidation;
using Paws.Application.DTOs;
using Paws.Application.Helpers;
using Paws.Application.Interfaces;
using Paws.Application.Validators;
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
            return new PagedResponse<OwnerDisplayDto>(ownersDto, totalCount); //return to frontend (CONSTRUCTOR)
        }

        public async Task<OwnerDisplayDto?> CreateOwnerAsync(OwnerCreateDto ownerCreateDto)
        {

            // Validate the OwnerCreateDto using the injected validator
            await ValidationHelper.EnsureValid(ownerCreateDto, new OwnerCreateValidator());

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

      

        public async Task<OwnerProfileDto?> GetByIdAsync(int id)
        {
            var owner = await _uow.Owners.GetOwnerWithPetsAsync(id);

            if (owner == null)
            {
                return null;
            }
            return _mapper.Map<OwnerProfileDto?>(owner);

        }

        public async Task<bool> UpdateOwnerAsync(int id, OwnerUpdateDto ownerDto)
        {
            // validate to to helper validator
            await ValidationHelper.EnsureValid(ownerDto, new OwnerUpdateValidator());

         
            // Get existing Owner
            var owner = await _uow.Owners.GetOwnerById(id);


            if (owner == null)
            {
                return false;
            }

            // Update Person
            _mapper.Map(ownerDto.Person, owner.Person);

            // Update Contacts (optional: replace or sync)
            if (ownerDto.Person.Contacts != null)
            {
                foreach (var contactDto in ownerDto.Person.Contacts)
                {
                    var existingOwnerContact = owner.Person.IContacts.FirstOrDefault(c => c.Id == contactDto.Id);

                    if(existingOwnerContact != null)
                    {
                        // ✅ AutoMapper updates the tracked entity
                        _mapper.Map(contactDto, existingOwnerContact); //OwnerUpdateDto <-> Owner 

                    }
                    else
                    {
                        //if new contact
                        var newContact = _mapper.Map<Contact>(contactDto);  // ✅ AutoMapper creates a new one

                        owner.Person.IContacts.Add(newContact); //insert to database
                    }
                }
            }

            //  Save changes
            _uow.Owners.Update(owner);
            await _uow.CompleteAsync();

            return true;
        }

    }
}
