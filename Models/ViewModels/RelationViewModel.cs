using System;
using System.ComponentModel.DataAnnotations;

namespace AndersenCoreApp.Models.ViewModels
{
    public class RelationViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string EMail { get; set; }
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
    }
}
