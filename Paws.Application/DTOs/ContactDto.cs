using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    internal class ContactDto
    {
    }

    public class ContactCreateDto
    {
        [Phone, MaxLength(11)]
        public string? PhoneNumber { get; set; }

        [EmailAddress, StringLength(100)]
        public string? Email { get; set; }

        [Required, StringLength(200)]
        public string HomeAddress { get; set; } = string.Empty;
    }

    public class ContactUpdateDto : ContactCreateDto { }

    public class ContactDisplayDto
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string HomeAddress { get; set; } = string.Empty;
    }

}
