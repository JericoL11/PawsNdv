using AutoMapper;
using Paws.Application.DTOs;
using PawsNdv.Domain.Entites;


namespace Paws.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region == PERSON ==
            // Person
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();
            CreateMap<Person, PersonDisplayDto>().ReverseMap();

            #endregion

            #region == CONTACT ==
            // Contact
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<Contact, ContactDisplayDto>().ReverseMap();

            #endregion

            #region == PET ==
            // Pet
            CreateMap<Pet, PetCreateDto>().ReverseMap();
            CreateMap<Pet, PetUpdateDto>().ReverseMap();
            CreateMap<Pet, PetDisplayDto>().ReverseMap();

            #endregion

            #region == OWNER ==

            // Owner
            CreateMap<Owner, OwnerCreateDto>()
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();

            CreateMap<Owner, OwnerUpdateDto>()
                .ReverseMap();

            CreateMap<Owner, OwnerDisplayDto>()
                .ReverseMap();


            CreateMap<Owner, OwnerProfileDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();


            #endregion 
        }

    }
}