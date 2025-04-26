using System.ComponentModel.DataAnnotations;

namespace Paws.Application.DTOs
{
    internal class ContactDto
    {
    }

    public class ContactCreateDto
    {
        [Phone, MaxLength(11)]
        public string? PhoneNumber { get; set; }

    }

    public class ContactUpdateDto : ContactCreateDto { } //inherit the contact CreateDto

    public class ContactDisplayDto  
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
