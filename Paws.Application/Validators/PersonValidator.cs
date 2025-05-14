using FluentValidation;
using Paws.Application.DTOs;
using PawsNdv.Domain.Enums;

namespace Paws.Application.Validators
{

    public class PersonCreateValidator : AbstractValidator<PersonCreateDto>
    {
        public PersonCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(x => x.Gender)
                 .NotEqual(Gender.Unknown)
                 .WithMessage("Gender is required.");

            RuleFor(x => x.BirthDate)
                 .NotEmpty().WithMessage("Birth date is required");

            RuleFor(x => x.HomeAddress)
                .NotEmpty().WithMessage("Home address is required");

            RuleFor(x => x.Contacts)
                .NotEmpty().WithMessage("At least 1 contact number")
                .ForEach(c => c.SetValidator(new ContactCreateValidator()));
        }
    }
}

