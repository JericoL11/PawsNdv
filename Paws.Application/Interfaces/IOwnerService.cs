using PawsNdv.Domain.Enums;

namespace Paws.Application.Interfaces
{
    public class IOwnerService
    {
      
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

    
        public string? MiddleName { get; set; }

        public Gender Gender { get; set; }

     
        public DateTime BirthDate { get; set; }
    }
}
