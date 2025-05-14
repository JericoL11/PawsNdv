using FluentValidation;

namespace Paws.Application.Helpers
{
    public  static class ValidationHelper
    {
        //helper for validation handler
        public static async Task EnsureValid<T>(this IValidator<T> validator, T dto)
        {
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
//this is a static class, which means you cannot instantiate it.
//It’s meant to provide utility methods (i.e., helper methods) to make your code cleaner.

//note this can be executed in the middle ware (program.cs located)