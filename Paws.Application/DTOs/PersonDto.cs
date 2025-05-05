using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    public abstract class PersonBaseDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [EmailAddress, StringLength(100)]
        public string? Email { get; set; }

        [Required, StringLength(200)]
        public string? HomeAddress { get; set; }
    }

    public class PersonCreateDto : PersonBaseDto
    {
        public List<ContactCreateDto>? Contacts { get; set; }
    }

    public class PersonUpdateDto : PersonBaseDto //INHERIT
    {
        public List<ContactUpdateDto>? Contacts { get; set; }
    }

    public class PersonDisplayDto : PersonBaseDto
    {

        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
        public List<ContactDisplayDto>? IContacts { get; set; }
    }

}
