using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Entites
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? FirstName { get; set; }

        [Required, StringLength(50)]
        public string? LastName { get; set; }

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

        //navigations
        public ICollection<Contact>? IContacts { get; set; }

        public Owner? Owner { get; set; }
    }

}
