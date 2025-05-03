using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    internal class PersonDto
    {
    }
        public class PersonCreateDto
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



            public List<ContactCreateDto>? Contacts { get; set; }
        }

    public class PersonUpdateDto : PersonCreateDto //INHERIT
    {
        public int Id { get; set; }
    }

    public class PersonDisplayDto
    {
     
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }

        public List<ContactDisplayDto>? IContacts { get; set; }
    }


}
