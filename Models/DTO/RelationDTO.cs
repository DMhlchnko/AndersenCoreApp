using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndersenCoreApp.Models.DTO
{
    public class RelationDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public int StreetNumber { get; set; }
        
        [Required]
        public List<string> Categories { get; set; }
    }
}
