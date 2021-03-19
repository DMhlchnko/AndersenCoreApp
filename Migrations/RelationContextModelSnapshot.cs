﻿// <auto-generated />
using System;
using AndersenCoreApp.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AndersenCoreApp.Migrations
{
    [DbContext(typeof(RelationContext))]
    partial class RelationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.AddressType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Flag1")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag2")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag3")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag4")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Timestamp1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp4")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Value1")
                        .HasColumnType("float");

                    b.Property<double?>("Value2")
                        .HasColumnType("float");

                    b.Property<double?>("Value3")
                        .HasColumnType("float");

                    b.Property<double?>("Value4")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("tblAddressType");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Flag1")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag2")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag3")
                        .HasColumnType("bit");

                    b.Property<bool?>("Flag4")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Timestamp1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Timestamp4")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Value1")
                        .HasColumnType("float");

                    b.Property<double?>("Value2")
                        .HasColumnType("float");

                    b.Property<double?>("Value3")
                        .HasColumnType("float");

                    b.Property<double?>("Value4")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("tblCategory");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.CategoryRelation", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RelationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "RelationId");

                    b.ToTable("tblRelationCategory");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DefaultVatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("Iso31662")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iso31663")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCodeFormat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblCountry");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ArrivalBetween")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ArrivalBetweenAnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArrivalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnFridays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnMondays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnSaturdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnSundays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnThursdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnTuesdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalTimeSlotIdOnWednesdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("ArrivalTimeSlotsAreAllEqual")
                        .HasColumnType("bit");

                    b.Property<string>("BankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankBic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CalculateMinimalPrice")
                        .HasColumnType("float");

                    b.Property<double?>("CalculateMinimalPriceForCollecting")
                        .HasColumnType("float");

                    b.Property<bool?>("CalculatePriceBasedOnAmount")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnAmountForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnDistance")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnDistanceForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnEpq")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnEpqForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnLoadingMeters")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnLoadingMetersForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnPositions")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnPositionsForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnTonne")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnTonneForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnVolume")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnVolumeForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnWeight")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceBasedOnWeightForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceByDistance")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceByDistanceForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceByFixed")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceByFixedForCollecting")
                        .HasColumnType("bit");

                    b.Property<double?>("CalculatePriceByFixedPrice")
                        .HasColumnType("float");

                    b.Property<double?>("CalculatePriceByFixedPriceForCollecting")
                        .HasColumnType("float");

                    b.Property<bool?>("CalculatePriceByPriceList")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceByPriceListForCollecting")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceManually")
                        .HasColumnType("bit");

                    b.Property<bool?>("CalculatePriceManuallyForCollecting")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChamberOfCommerce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DebtorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DepartureBetween")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureBetweenAnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DepartureTimeSlotIdOnFridays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnMondays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnSaturdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnSundays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnThursdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnTuesdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureTimeSlotIdOnWednesdays")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("DepartureTimeSlotsAreAllEqual")
                        .HasColumnType("bit");

                    b.Property<Guid?>("DigitalFreightDocumentEmailTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Flags")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralLedgerAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeographicalRegions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imaddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceDateGenerationOptions")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceGroupByOptions")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceGroupByTransportOrderColumnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMe")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentRelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("PaymentTerm")
                        .HasColumnType("float");

                    b.Property<bool>("PaymentViaAutomaticDebit")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PriceListIdForCollecting")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PriceListName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceListNameForCollecting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RelationAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SendDigitalFreightDocumentsByEmail")
                        .HasColumnType("bit");

                    b.Property<bool?>("SendFreightDocumentsAlongWithInvoice")
                        .HasColumnType("bit");

                    b.Property<bool?>("SendFreightStatusUpdateByEmail")
                        .HasColumnType("bit");

                    b.Property<bool?>("SendInvoiceDigital")
                        .HasColumnType("bit");

                    b.Property<string>("SkypeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ThirdPartyToUseForInvoicing")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TransportUnitTransactionOverviewTextTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RelationAddressId")
                        .IsUnique()
                        .HasFilter("[RelationAddressId] IS NOT NULL");

                    b.ToTable("tblRelation");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.RelationAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("NumberSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.ToTable("tblRelationAddress");
                });

            modelBuilder.Entity("CategoryRelation", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RelationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "RelationsId");

                    b.HasIndex("RelationsId");

                    b.ToTable("CategoryRelation");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.Relation", b =>
                {
                    b.HasOne("AndersenCoreApp.Models.DomainModels.RelationAddress", "RelationAddress")
                        .WithOne()
                        .HasForeignKey("AndersenCoreApp.Models.DomainModels.Relation", "RelationAddressId");

                    b.Navigation("RelationAddress");
                });

            modelBuilder.Entity("AndersenCoreApp.Models.DomainModels.RelationAddress", b =>
                {
                    b.HasOne("AndersenCoreApp.Models.DomainModels.Country", "Country")
                        .WithOne()
                        .HasForeignKey("AndersenCoreApp.Models.DomainModels.RelationAddress", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CategoryRelation", b =>
                {
                    b.HasOne("AndersenCoreApp.Models.DomainModels.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndersenCoreApp.Models.DomainModels.Relation", null)
                        .WithMany()
                        .HasForeignKey("RelationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
