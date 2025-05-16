
using Paws.Application.DTOs;
using PawsNdv.Domain.Enums;
using FluentValidation;

namespace Paws.Application.Validators
{
    // Base validator
    public class PersonBaseValidator<T> : AbstractValidator<T> where T: PersonBaseDto //T must be inherit on the PersonBaseDto
    {
        public PersonBaseValidator()
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

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email format");
        }
    }

    // Create validator
    public class PersonCreateValidator : AbstractValidator<PersonCreateDto>
    {
        public PersonCreateValidator()
        {
            //inherit the base validator
            Include(new PersonBaseValidator<PersonCreateDto>());  //make sure that PersonCreateDto is inherit the PersonBaseDto


            RuleFor(x => x.Contacts)
                .NotEmpty().WithMessage("At least 1 contact number")
                .ForEach(c => c.SetValidator(new ContactCreateValidator()));
        }
    }

    public class PersonUpdateValidator : AbstractValidator<PersonUpdateDto>
    {
        public PersonUpdateValidator()
        {
            Include(new PersonBaseValidator<PersonUpdateDto>()); //check base

            RuleFor(X => X.Contacts)
                .NotEmpty().WithMessage("At least 1 contact number")
                .ForEach(c => c.SetValidator(new ContactUpdateValidator()));
        }
    }
}

