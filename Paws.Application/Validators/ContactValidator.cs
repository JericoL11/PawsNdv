using FluentValidation;
using Paws.Application.DTOs;

namespace Paws.Application.Validators
{
    public class ContactCreateValidator : AbstractValidator<ContactCreateDto>
    {
        //constructor
        public ContactCreateValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Contact # is required");
        }
    }
}
