using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndersenCoreApp.Models.DomainModels
{
    public partial class RelationContext : DbContext
    {
        public RelationContext() { }

        public RelationContext(DbContextOptions<RelationContext> options)
            : base(options) { }

        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<RelationAddress> RelationAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>().HasOne(r => r.RelationAddress).WithOne()
                .HasForeignKey<Relation>(r => r.RelationAddressId);

            modelBuilder.Entity<RelationCategory>().HasKey(rc => new { rc.CategoryId, rc.RelationId });
            modelBuilder.Entity<RelationCategory>().HasOne(rc => rc.Relation).WithMany(r => r.RelationCategories)
                .HasForeignKey(rc => rc.RelationId);
            modelBuilder.Entity<RelationCategory>().HasOne(rc => rc.Category).WithMany(c => c.Relations)
                .HasForeignKey(rc => rc.RelationId);

            modelBuilder.Entity<RelationAddress>().HasOne(r => r.Country)
                .WithOne().HasForeignKey<RelationAddress>(r => r.CountryId);
        }

        // TODO: Use startup configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=test;Trusted_Connection=True;");
        }

    }
}
