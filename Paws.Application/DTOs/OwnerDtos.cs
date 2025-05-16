
using System.ComponentModel.DataAnnotations;


namespace Paws.Application.DTOs
{
    internal class OwnerDtos
    {
    }      

    public class OwnerCreateDto
    {
        public PersonCreateDto Person { get; set; } = new();

        public List<PetCreateDto>? Pets { get; set; }
    }

    public class OwnerUpdateDto
    {
        public PersonUpdateDto Person { get; set; } = new();
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class OwnerDisplayDto
    {
        public int Id { get; set; }
        public PersonDisplayDto Person { get; set; } = new();
    }

    public class OwnerProfileDto { 
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public PersonDisplayDto Person { get; set; } = new();
        public ICollection<PetDisplayDto> Pets { get; set; }

    }

}
