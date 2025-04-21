using Microsoft.EntityFrameworkCore;
using PawsNdv.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Infrastructure.Data
{
    public class PawsNdvContext : DbContext
    {
     
        public PawsNdvContext(DbContextOptions<PawsNdvContext> options) : base(options)
        {
        }

        // = null!; is: - A null-forgiving assignment to silence C# nullable warnings
        public  DbSet<Person> Person { get; set; } = null!; 
        public  DbSet<Owner> Owners { get; set; } = null!; 
        public  DbSet<Pet> Pets { get; set; } = null!; 
        public  DbSet<Contact> Contacts { get; set; } = null!; 


    }
}
