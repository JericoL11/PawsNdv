using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.DTOs
{
    internal class OwnerDtos
    {
    }

    public class OwnerCreateDto
    {
        [Required]
        public PersonCreateDto Person { get; set; } = new();

        public List<PetCreateDto>? Pets { get; set; }
    }

    public class OwnerUpdateDto
    {
        [Required]
        public int Id { get; set; }

        public PersonUpdateDto Person { get; set; } = new();

        public List<PetUpdateDto>? Pets { get; set; }
    }

    public class OwnerDisplayDto
    {
        public PersonDisplayDto Person { get; set; } = new();

 
    }

}
