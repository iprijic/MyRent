using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyRent.API.Business.Model
{
    public partial class Region
    {
        public Region()
        {
            Apartments = new HashSet<Apartment>();
        }

        [Key]
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(Apartment.Region))]
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
