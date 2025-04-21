using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Entites
{
    public class Owner
    {
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //navigation

        public Person Person { get; set; }
        public ICollection<Pet>? IPet { get; set; }

    }
}
