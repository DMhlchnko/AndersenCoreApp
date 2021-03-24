using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersenCoreApp.Models.Domain
{
    [Table("tblRelationAddress")]
    public class RelationAddress
    {
        public Guid Id { get; set; }
        public Guid? AddressTypeId { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string NumberSuffix { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public virtual Country Country { get; set; }
    }
}
