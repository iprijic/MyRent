using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyRent.API.Business.Model
{
    [Index(nameof(InterierObjectID), Name = "IX_FK_ApartmentInterierObject")]
    [Index(nameof(RegionID), Name = "IX_FK_ApartmentRegion")]
    [Index(nameof(OwnerID), Name = "IX_FK_OwnerApartment")]
    public partial class Apartment
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReservedTo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReservedFrom { get; set; }
        public long OwnerID { get; set; }
        public long RegionID { get; set; }
        public long InterierObjectID { get; set; }
        [Required]
        public string Address { get; set; }

        [ForeignKey(nameof(InterierObjectID))]
        [InverseProperty("Apartments")]
        public virtual InterierObject InterierObject { get; set; }
        [ForeignKey(nameof(OwnerID))]
        [InverseProperty("Apartments")]
        public virtual Owner Owner { get; set; }
        [ForeignKey(nameof(RegionID))]
        [InverseProperty("Apartments")]
        public virtual Region Region { get; set; }
    }
}
