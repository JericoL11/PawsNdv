using FluentValidation;
using Paws.Application.DTOs;

namespace Paws.Application.Validators
{
    public class OwnerCreateValidator : AbstractValidator<OwnerCreateDto>
    {
        public OwnerCreateValidator() 
        {
            RuleFor(x => x.Person)
                .SetValidator(new PersonCreateValidator());

            RuleFor(x => x.Pets)
                // Validate that IPet is not empty before checking individual pet validation
                .NotEmpty().WithMessage("At least one pet is required")
                .ForEach(pet => pet.SetValidator(new PetCreateValidators()));
        }

    }

    public class OwnerUpdateValidator : AbstractValidator<OwnerUpdateDto>
    {
        public OwnerUpdateValidator()
        {
            RuleFor(X => X.Person)
                .SetValidator(new PersonCreateValidator());
        }
    }
 }
