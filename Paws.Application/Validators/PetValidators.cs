using FluentValidation;
using Paws.Application.DTOs;
using PawsNdv.Domain.Enums;


namespace Paws.Application.Validators
{
    public class PetCreateValidators: AbstractValidator<PetCreateDto>
    {
        public PetCreateValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pet name is required");

            RuleFor(x => x.BirthDate)
              .NotEmpty().WithMessage("Birth Date is required");

            RuleFor(x => x.Gender)
                 .NotEqual(Gender.Unknown)
                 .WithMessage("Gender is required.");


            RuleFor(x => x.Breed)
              .NotEmpty().WithMessage("Breed is required");

            RuleFor(x => x.Specie)
           .NotEmpty().WithMessage("Specie is required");
        }
    }
}
