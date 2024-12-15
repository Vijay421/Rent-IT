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
                            Id = "a7642990-1869-403f-9b7c-167005bc8436",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "40dc77cc-c03e-47fe-8e6e-741fcb377cd0",
                            Name = "backoffice_medewerker",
                            NormalizedName = "BACKOFFICE_MEDEWERKER"
                        },
                        new
                        {
                            Id = "9947d29c-4fe1-4514-830e-899e5ab24430",
                            Name = "frontoffice_medewerker",
                            NormalizedName = "FRONTOFFICE_MEDEWERKER"
                        },
                        new
                        {
                            Id = "019afcff-14e8-46e9-8490-58f6321d2d98",
                            Name = "zakelijke_beheerder",
                            NormalizedName = "ZAKELIJKE_BEHEERDER"
                        },
                        new
                        {
                            Id = "02e70917-0ff9-4c74-909a-136fa8f9b283",
                            Name = "zakelijke_huurder",
                            NormalizedName = "ZAKELIJKE_HUURDER"
                        },
                        new
                        {
                            Id = "d9d67bb2-45d6-4a67-a0e6-defad8e88655",
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

                    b.Property<DateOnly>("Einddatum")
                        .HasColumnType("date");

                    b.Property<int?>("HuurbeheerderId")
                        .HasColumnType("int");

                    b.Property<int>("Max_huurders")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Prijs_per_maand")
                        .HasColumnType("float");

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HuurbeheerderId");

                    b.ToTable("Abonnementen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Einddatum = new DateOnly(2026, 1, 1),
                            Max_huurders = 10,
                            Naam = "abbo",
                            Prijs_per_maand = 12.199999999999999,
                            Soort = "prepaid"
                        });
                });

            modelBuilder.Entity("backend.Models.Bedrijf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KvK_nummer")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bedrijven");
                });

            modelBuilder.Entity("backend.Models.Huuraanvraag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresgegevens")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "adresgegevens");

                    b.Property<DateOnly>("Einddatum")
                        .HasColumnType("date")
                        .HasAnnotation("Relational:JsonPropertyName", "einddatum");

                    b.Property<bool?>("Geaccepteerd")
                        .HasColumnType("bit");

                    b.Property<bool>("Gezien")
                        .HasColumnType("bit");

                    b.Property<int?>("ParticuliereHuurderId")
                        .HasColumnType("int");

                    b.Property<string>("Reden")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Reisaard")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "reisaard");

                    b.Property<string>("Rijbewijsnummer")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasAnnotation("Relational:JsonPropertyName", "rijbewijsnummer");

                    b.Property<DateOnly>("Startdatum")
                        .HasColumnType("date")
                        .HasAnnotation("Relational:JsonPropertyName", "startdatum");

                    b.Property<DateTime>("VeranderDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vereiste_bestemming")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "vereiste_bestemming");

                    b.Property<int>("Verwachte_km")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "verwachte_km");

                    b.Property<int>("VoertuigId")
                        .HasColumnType("int");

                    b.Property<string>("Wettelijke_naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "wettelijke_naam");

                    b.Property<int?>("ZakelijkeHuurder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticuliereHuurderId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Huuraanvragen");
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

                    b.Property<int?>("HuurbeheerderId")
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

                    b.HasKey("Id");

                    b.HasIndex("BackOfficeId");

                    b.HasIndex("FrontOfficeId");

                    b.HasIndex("HuurbeheerderId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ParticuliereHuurderId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("backend.Models.Voertuig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aanschafjaar")
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

            modelBuilder.Entity("backend.Rollen.BackOfficeMedewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("BackOfficeMedewerkers");
                });

            modelBuilder.Entity("backend.Rollen.FrontOfficeMedewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("FrontOfficeMedewerkers");
                });

            modelBuilder.Entity("backend.Rollen.Huurbeheerder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BedrijfId")
                        .HasColumnType("int");

                    b.Property<string>("Bedrijfsrol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BedrijfId");

                    b.ToTable("Huurbeheerders");
                });

            modelBuilder.Entity("backend.Rollen.ParticuliereHuurder", b =>
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

                    b.ToTable("ParticuliereHuurders");
                });

            modelBuilder.Entity("backend.Rollen.ZakelijkeHuurder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AbonnementId")
                        .HasColumnType("int");

                    b.Property<string>("Factuuradres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HuurbeheerderId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AbonnementId");

                    b.HasIndex("HuurbeheerderId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ZakelijkeHuurders");
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

            modelBuilder.Entity("backend.Models.Abonnement", b =>
                {
                    b.HasOne("backend.Rollen.Huurbeheerder", null)
                        .WithMany("Abonnement")
                        .HasForeignKey("HuurbeheerderId");
                });

            modelBuilder.Entity("backend.Models.Huuraanvraag", b =>
                {
                    b.HasOne("backend.Rollen.ParticuliereHuurder", null)
                        .WithMany("Huuraanvragen")
                        .HasForeignKey("ParticuliereHuurderId");

                    b.HasOne("backend.Models.Voertuig", "Voertuig")
                        .WithMany()
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.HasOne("backend.Rollen.BackOfficeMedewerker", "BackOffice")
                        .WithMany()
                        .HasForeignKey("BackOfficeId");

                    b.HasOne("backend.Rollen.FrontOfficeMedewerker", "FrontOffice")
                        .WithMany()
                        .HasForeignKey("FrontOfficeId");

                    b.HasOne("backend.Rollen.Huurbeheerder", "Huurbeheerder")
                        .WithMany()
                        .HasForeignKey("HuurbeheerderId");

                    b.HasOne("backend.Rollen.ParticuliereHuurder", "ParticuliereHuurder")
                        .WithMany()
                        .HasForeignKey("ParticuliereHuurderId");

                    b.Navigation("BackOffice");

                    b.Navigation("FrontOffice");

                    b.Navigation("Huurbeheerder");

                    b.Navigation("ParticuliereHuurder");
                });

            modelBuilder.Entity("backend.Rollen.Huurbeheerder", b =>
                {
                    b.HasOne("backend.Models.Bedrijf", null)
                        .WithMany("Huurbeheerders")
                        .HasForeignKey("BedrijfId");
                });

            modelBuilder.Entity("backend.Rollen.ZakelijkeHuurder", b =>
                {
                    b.HasOne("backend.Models.Abonnement", null)
                        .WithMany("ZakelijkeHuurders")
                        .HasForeignKey("AbonnementId");

                    b.HasOne("backend.Rollen.Huurbeheerder", null)
                        .WithMany("ZakelijkeHuurders")
                        .HasForeignKey("HuurbeheerderId");

                    b.HasOne("backend.Models.User", null)
                        .WithOne("ZakelijkeHuurder")
                        .HasForeignKey("backend.Rollen.ZakelijkeHuurder", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Abonnement", b =>
                {
                    b.Navigation("ZakelijkeHuurders");
                });

            modelBuilder.Entity("backend.Models.Bedrijf", b =>
                {
                    b.Navigation("Huurbeheerders");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Navigation("ZakelijkeHuurder");
                });

            modelBuilder.Entity("backend.Rollen.Huurbeheerder", b =>
                {
                    b.Navigation("Abonnement");

                    b.Navigation("ZakelijkeHuurders");
                });

            modelBuilder.Entity("backend.Rollen.ParticuliereHuurder", b =>
                {
                    b.Navigation("Huuraanvragen");
                });
#pragma warning restore 612, 618
        }
    }
}
