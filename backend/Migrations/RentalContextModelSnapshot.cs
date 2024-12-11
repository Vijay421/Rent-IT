﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(RentalContext))]
    partial class RentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "be3ffd30-7d69-40a9-910f-64916a510b27",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "524013e6-0032-48e6-bda6-af79806dbf40",
                            Name = "backoffice_medewerker",
                            NormalizedName = "BACKOFFICE_MEDEWERKER"
                        },
                        new
                        {
                            Id = "ca479615-3fa6-4e06-9bf7-14b0c9d9777d",
                            Name = "frontoffice_medewerker",
                            NormalizedName = "FRONTOFFICE_MEDEWERKER"
                        },
                        new
                        {
                            Id = "c0d5d0fe-0c2c-4b5e-b39b-ea0786bbc02f",
                            Name = "zakelijke_beheerder",
                            NormalizedName = "ZAKELIJKE_BEHEERDER"
                        },
                        new
                        {
                            Id = "248e58c6-4755-4683-9ed3-0728c428eb57",
                            Name = "zakelijke_huurder",
                            NormalizedName = "ZAKELIJKE_HUURDER"
                        },
                        new
                        {
                            Id = "d791cb56-a507-47e1-842b-ddde5a5d3073",
                            Name = "particuliere_huurder",
                            NormalizedName = "PARTICULIERE_HUURDER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("backend.Models.Abonnement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("Duur")
                        .HasColumnType("time");

                    b.Property<int>("Max_huurders")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prijs_per_maand")
                        .HasColumnType("real");

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abonnementen", (string)null);
                });

            modelBuilder.Entity("backend.Models.BackOfficeMedewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("BackOfficeMedewerker", (string)null);
                });

            modelBuilder.Entity("backend.Models.FrontOfficeMedewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("FrontOfficeMedewerker", (string)null);
                });

            modelBuilder.Entity("backend.Models.Huuraanvraag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresgegevens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Einddatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geaccepteerd")
                        .HasColumnType("bit");

                    b.Property<string>("Reisaard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rijbewijsnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vereiste_bestemming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Verwachte_km")
                        .HasColumnType("int");

                    b.Property<int>("VoertuigId")
                        .HasColumnType("int");

                    b.Property<string>("Wettelijke_naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Huuraanvragen", (string)null);
                });

            modelBuilder.Entity("backend.Models.ParticuliereHuurder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ParticuliereHuurders", (string)null);
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("BackOfficeId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("FrontOfficeId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("ParticuliereHuurderId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("ZakelijkeHuurderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackOfficeId");

                    b.HasIndex("FrontOfficeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ParticuliereHuurderId");

                    b.HasIndex("ZakelijkeHuurderId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("backend.Models.Voertuig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aanschafjaar")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<DateOnly>("EindDatum")
                        .HasColumnType("date");

                    b.Property<string>("Kenteken")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Kleur")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Merk")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Opmerking")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("Prijs")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateOnly>("StartDatum")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Voertuigen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aanschafjaar = 2018,
                            EindDatum = new DateOnly(2016, 4, 12),
                            Kenteken = "AB-123-CD",
                            Kleur = "Red",
                            Merk = "Toyota",
                            Opmerking = "",
                            Prijs = 50.0,
                            Soort = "Auto",
                            StartDatum = new DateOnly(2012, 2, 24),
                            Status = "Verhuurbaar",
                            Type = "Corolla"
                        },
                        new
                        {
                            Id = 2,
                            Aanschafjaar = 2019,
                            EindDatum = new DateOnly(2020, 8, 12),
                            Kenteken = "EF-456-GH",
                            Kleur = "Blue",
                            Merk = "Ford",
                            Opmerking = "",
                            Prijs = 51.390000000000001,
                            Soort = "Auto",
                            StartDatum = new DateOnly(2017, 4, 3),
                            Status = "Verhuurbaar",
                            Type = "Focus"
                        },
                        new
                        {
                            Id = 3,
                            Aanschafjaar = 2020,
                            EindDatum = new DateOnly(2024, 11, 9),
                            Kenteken = "IJ-789-KL",
                            Kleur = "Black",
                            Merk = "Volkswagen",
                            Opmerking = "",
                            Prijs = 40.0,
                            Soort = "Auto",
                            StartDatum = new DateOnly(2019, 10, 12),
                            Status = "Verhuurbaar",
                            Type = "Golf"
                        },
                        new
                        {
                            Id = 105,
                            Aanschafjaar = 2021,
                            EindDatum = new DateOnly(2016, 4, 12),
                            Kenteken = "QR-345-ST",
                            Kleur = "Gray",
                            Merk = "Citroën",
                            Opmerking = "",
                            Prijs = 65.0,
                            Soort = "Camper",
                            StartDatum = new DateOnly(2012, 2, 24),
                            Status = "Verhuurbaar",
                            Type = "Jumper"
                        },
                        new
                        {
                            Id = 106,
                            Aanschafjaar = 2016,
                            EindDatum = new DateOnly(2016, 4, 12),
                            Kenteken = "UV-678-WX",
                            Kleur = "Black",
                            Merk = "Peugeot",
                            Opmerking = "",
                            Prijs = 68.0,
                            Soort = "Camper",
                            StartDatum = new DateOnly(2012, 2, 24),
                            Status = "Verhuurbaar",
                            Type = "Boxer"
                        },
                        new
                        {
                            Id = 185,
                            Aanschafjaar = 2020,
                            EindDatum = new DateOnly(2016, 4, 12),
                            Kenteken = "GH-456-IJ",
                            Kleur = "Blue",
                            Merk = "Dethle-s",
                            Opmerking = "",
                            Prijs = 52.5,
                            Soort = "Caravan",
                            StartDatum = new DateOnly(2012, 2, 24),
                            Status = "Verhuurbaar",
                            Type = "C'go"
                        },
                        new
                        {
                            Id = 186,
                            Aanschafjaar = 2017,
                            EindDatum = new DateOnly(2016, 4, 12),
                            Kenteken = "KL-789-MN",
                            Kleur = "Red",
                            Merk = "Burstner",
                            Opmerking = "",
                            Prijs = 48.0,
                            Soort = "Caravan",
                            StartDatum = new DateOnly(2012, 2, 24),
                            Status = "Verhuurbaar",
                            Type = "Premio Life"
                        });
                });

            modelBuilder.Entity("backend.Models.ZakelijkeHuurder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Factuuradres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ZakelijkeHuurder", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Huuraanvraag", b =>
                {
                    b.HasOne("backend.Models.Voertuig", "Voertuig")
                        .WithMany()
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.HasOne("backend.Models.BackOfficeMedewerker", "BackOffice")
                        .WithMany()
                        .HasForeignKey("BackOfficeId");

                    b.HasOne("backend.Models.FrontOfficeMedewerker", "FrontOffice")
                        .WithMany()
                        .HasForeignKey("FrontOfficeId");

                    b.HasOne("backend.Models.ParticuliereHuurder", "ParticuliereHuurder")
                        .WithMany()
                        .HasForeignKey("ParticuliereHuurderId");

                    b.HasOne("backend.Models.ZakelijkeHuurder", "ZakelijkeHuurder")
                        .WithMany()
                        .HasForeignKey("ZakelijkeHuurderId");

                    b.Navigation("BackOffice");

                    b.Navigation("FrontOffice");

                    b.Navigation("ParticuliereHuurder");

                    b.Navigation("ZakelijkeHuurder");
                });
#pragma warning restore 612, 618
        }
    }
}
