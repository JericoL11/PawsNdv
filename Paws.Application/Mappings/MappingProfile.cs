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
            CreateMap<Pet, PetDisplayDto>()
                .ForMember(dest => dest.PetId , opt => opt.MapFrom(src => src.Id)) //assigned the Id
                .ReverseMap();

            #endregion

            #region == OWNER ==

            // Owner
            CreateMap<Owner, OwnerCreateDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))  //dest (from dto) -> src.person(entity navigation)
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))  //Maps the IPet collection from the Owner entity to the Pets collection in your DTO.
                .ReverseMap();

            CreateMap<Owner, OwnerUpdateDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();

            CreateMap<Owner, OwnerDisplayDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                //.ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();


            CreateMap<Owner, OwnerProfileDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();

            #endregion 
        }

    }
}