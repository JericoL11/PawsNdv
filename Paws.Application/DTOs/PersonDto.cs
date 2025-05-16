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

        public string FirstName { get; set; } = string.Empty;

     
        public string LastName { get; set; } = string.Empty;


        public string? MiddleName { get; set; }


        public Gender Gender { get; set; }


        public DateTime BirthDate { get; set; }

      
        public string? Email { get; set; }

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
