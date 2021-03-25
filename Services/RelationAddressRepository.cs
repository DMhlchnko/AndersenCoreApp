using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Models.DTO;
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RelationAddressRepository(RelationContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<RelationAddress> CreateAsync(RelationDTO relation, Guid countryId)
        {
            var relationAddress = new RelationAddress 
            {
                City = relation.City,
                Street = relation.Street,
                Number = relation.StreetNumber,
                PostalCode = relation.PostalCode,
                CountryId = countryId
            };
            await _db.RelationAddresses.AddAsync(relationAddress);
            await _db.SaveChangesAsync();

            return relationAddress;
        }

        /// <inheritdoc />
        public async Task<RelationAddress> FindAsync(Guid id)
        {
            return await _db.RelationAddresses.FirstOrDefaultAsync(ra => ra.Id == id);
        }

        /// <inheritdoc />
        public async Task<RelationAddress> UpdateAsync(RelationDTO relation,Guid relationAddressId)
        {
            var relationAddressToUpdate = await _db.RelationAddresses.FirstOrDefaultAsync(ra => ra.Id == relationAddressId);
            relationAddressToUpdate.City = relation.City;
            relationAddressToUpdate.Street = relation.Street;
            relationAddressToUpdate.Number = relation.StreetNumber;
            relationAddressToUpdate.PostalCode = relation.PostalCode;
            _db.Entry(relationAddressToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return relationAddressToUpdate;
        }
    }
}
