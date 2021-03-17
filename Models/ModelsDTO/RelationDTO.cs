using System;

namespace AndersenCoreApp.Models.ModelsDTO
{
    public class RelationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EMail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int StreetNumber { get; set; }
    }
}
