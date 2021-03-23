using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersenCoreApp.Models.Domain
{
    [Table("tblCountry")]
    public class Country
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column("ISO3166_2")]
        public string Iso31662 { get; set; }
        [Column("ISO3166_3")]
        public string Iso31663 { get; set; }
        public Guid? DefaultVatId { get; set; }
        public string PostalCodeFormat { get; set; }
    }
}
