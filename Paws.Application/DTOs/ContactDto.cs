using System.ComponentModel.DataAnnotations;

namespace Paws.Application.DTOs
{
    public class ContactCreateDto
    {
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }

    }

    public class ContactUpdateDto : ContactCreateDto    //inherit the contact CreateDto
    {
        public int Id { get; set; }

    }
    
    public class ContactDisplayDto  
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
