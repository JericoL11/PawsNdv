using AutoMapper;
using Paws.Application.DTOs;
using PawsNdv.Domain.Entites;


namespace Paws.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Person
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();
            CreateMap<Person, PersonDisplayDto>().ReverseMap();

            // Contact
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<Contact, ContactDisplayDto>().ReverseMap();

            // Pet
            CreateMap<Pet, PetCreateDto>().ReverseMap();
            CreateMap<Pet, PetUpdateDto>().ReverseMap();
            CreateMap<Pet, PetDisplayDto>().ReverseMap();

            // Owner
            CreateMap<Owner, OwnerCreateDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();

            CreateMap<Owner, OwnerUpdateDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();

            CreateMap<Owner, OwnerDisplayDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.IPet))
                .ReverseMap();
        }

    }
}