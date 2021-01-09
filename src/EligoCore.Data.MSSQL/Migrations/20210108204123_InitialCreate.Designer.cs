﻿// <auto-generated />
using System;
using EligoCore.Data.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EligoCore.Data.MSSQL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210108204123_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EligoCore.Data.MSSQL.Entities.References.RefCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RefCountryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefCountryID");

                    b.ToTable("RefCities");
                });

            modelBuilder.Entity("EligoCore.Data.MSSQL.Entities.References.RefCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("RefCountries");
                });

            modelBuilder.Entity("EligoCore.Data.MSSQL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RefCityIdPlaceOfBirth")
                        .HasColumnType("int");

                    b.Property<int>("RefCountryIdPlaceOfBirth")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIdCreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserIdDeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserIdModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefCityIdPlaceOfBirth");

                    b.HasIndex("RefCountryIdPlaceOfBirth");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EligoCore.Data.MSSQL.Entities.References.RefCity", b =>
                {
                    b.HasOne("EligoCore.Data.MSSQL.Entities.References.RefCountry", "RefCountry")
                        .WithMany()
                        .HasForeignKey("RefCountryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RefCountry");
                });

            modelBuilder.Entity("EligoCore.Data.MSSQL.Entities.User", b =>
                {
                    b.HasOne("EligoCore.Data.MSSQL.Entities.References.RefCity", "RefCityPlaceOfBirth")
                        .WithMany()
                        .HasForeignKey("RefCityIdPlaceOfBirth")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EligoCore.Data.MSSQL.Entities.References.RefCity", "RefCountryPlaceOfBirth")
                        .WithMany()
                        .HasForeignKey("RefCountryIdPlaceOfBirth")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RefCityPlaceOfBirth");

                    b.Navigation("RefCountryPlaceOfBirth");
                });
#pragma warning restore 612, 618
        }
    }
}