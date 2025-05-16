using FluentValidation;

namespace Paws.Application.Helpers
{
    public  static class ValidationHelper
    {
        //helper for validation handler
        public static async Task EnsureValid<T>(T dto, IValidator<T> validator)
        {
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}");
                throw new ValidationException("\n" + string.Join("\n", errors));

            }
        }
    }
}
//this is a static class, which means you cannot instantiate it.
//It’s meant to provide utility methods (i.e., helper methods) to make your code cleaner.

//note this can be executed in the middle ware (program.cs located)