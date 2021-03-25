using System;
using System.ComponentModel.DataAnnotations;

namespace AndersenCoreApp.Models.DTO
{
    public class RelationDTO
    {
        public Guid Id { get; set; }

        [Required,DataType(DataType.Text)]
        public string Name { get; set; }

        [Required, DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required, DataType(DataType.Text)]
        public string Street { get; set; }

        [Required, DataType(DataType.Text)]
        public string City { get; set; }

        [Required, DataType(DataType.Text)]
        public string Country { get; set; }

        [Required, DataType(DataType.Text)]
        public string PostalCode { get; set; }

        [Required]
        public int StreetNumber { get; set; }
    }
}
