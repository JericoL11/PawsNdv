using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Entites
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Phone, MaxLength(11)]
        public string? PhoneNumber { get; set; } = string.Empty;


        [ForeignKey("Person")]
        public int PersonId { get; set; }
     
    }
}
