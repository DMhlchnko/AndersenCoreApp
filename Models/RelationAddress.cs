﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AndersenCoreApp.Models
{
    [Table("tblRelationAddress")]
    public partial class RelationAddress
    {
       
        public Guid RelationId { get; set; }
        [Key]
        public Guid AddressTypeId { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string NumberSuffix { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("RelationId")]
        public virtual Relation Relation { get; set; }
    }
}