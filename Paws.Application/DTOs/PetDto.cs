using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    public class PetBaseDto
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Breed { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Specie Specie { get; set; }
    }
    public class PetCreateDto : PetBaseDto
    {

    }

    public class PetUpdateDto : PetBaseDto 
    {

    }

    public class PetDisplayDto : PetBaseDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
    }

}
