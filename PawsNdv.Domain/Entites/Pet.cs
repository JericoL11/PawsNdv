﻿using PawsNdv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsNdv.Domain.Entites
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public string? Breed { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Specie Specie { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
    }
}
