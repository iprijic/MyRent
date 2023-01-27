using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyRent.API.Business.Model
{
    public partial class Owner
    {
        public Owner()
        {
            Apartments = new HashSet<Apartment>();
        }

        [Key]
        public long ID { get; set; }
        [Required]
        public string OIB { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PrincipalName { get; set; }

        [InverseProperty(nameof(Apartment.Owner))]
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
