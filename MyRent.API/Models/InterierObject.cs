using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyRent.API.Business.Model
{
    public partial class InterierObject
    {
        public InterierObject()
        {
            Apartments = new HashSet<Apartment>();
        }

        [Key]
        public long ID { get; set; }
        public short NoOfBedrooms { get; set; }
        public short NoOfBathrooms { get; set; }

        [InverseProperty(nameof(Apartment.InterierObject))]
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
