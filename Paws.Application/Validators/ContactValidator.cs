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


    public class ContactUpdateValidator : AbstractValidator<ContactUpdateDto> 
    {
        public ContactUpdateValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Contact # is required");
        }
    }
}

/*
    as you've notice, rules are the same.
    the only reason why we separate them is bcs,
    ContactCreateDto and ContactUpdateDto have different fields.
 */
