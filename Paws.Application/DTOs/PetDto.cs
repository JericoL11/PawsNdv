using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    internal class PetDto
    {
    }
    public class PetCreateDto
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

        [Required]
        public int OwnerId { get; set; }
    }

    public class PetUpdateDto : PetCreateDto { }

    public class PetDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Specie Specie { get; set; }

        public int OwnerId { get; set; }
    }

}
