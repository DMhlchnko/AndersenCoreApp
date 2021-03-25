using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Services
{
    /// <inheritdoc />
    public class RelationAddressRepository : IRelationAddressRepository
    {
        private readonly RelationContext _db;

        public RelationAddressRepository(RelationContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<RelationAddress> CreateAsync(string city, string street, int streetNumber, string postalCode, Guid countryId)
        {
            var relationAddress = new RelationAddress 
            {
                City = city,
                Street = street,
                Number = streetNumber,
                PostalCode = postalCode,
                CountryId = countryId
            };
            await _db.RelationAddresses.AddAsync(relationAddress);
            return relationAddress;
        }

        /// <inheritdoc />
        public async Task<RelationAddress> FindAsync(Guid id)
        {
            return await _db.RelationAddresses.FirstOrDefaultAsync(ra => ra.Id == id);
        }

        /// <inheritdoc />
        public async Task<RelationAddress> UpdateAsync(RelationAddress relationAddress)
        {
            _db.Entry(relationAddress).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return relationAddress;
        }
    }
}
