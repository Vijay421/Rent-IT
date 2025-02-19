﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BackOfficeMedewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackOfficeMedewerkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KvK_nummer = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domein = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrontOfficeMedewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontOfficeMedewerkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticuliereHuurders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticuliereHuurders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merk = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kenteken = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Kleur = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Aanschafjaar = table.Column<int>(type: "int", nullable: false),
                    Soort = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<double>(type: "float", nullable: false),
                    StartDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    EindDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    VerwijderdDatum = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huurbeheerders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bedrijfsrol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BedrijfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurbeheerders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huurbeheerders_Bedrijven_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijven",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huuraanvragen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticuliereHuurderId = table.Column<int>(type: "int", nullable: true),
                    ZakelijkeHuurder = table.Column<int>(type: "int", nullable: true),
                    VoertuigId = table.Column<int>(type: "int", nullable: true),
                    Startdatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Einddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Wettelijke_naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresgegevens = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rijbewijsnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Reisaard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vereiste_bestemming = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Verwachte_km = table.Column<int>(type: "int", nullable: false),
                    Geaccepteerd = table.Column<bool>(type: "bit", nullable: true),
                    Reden = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VeranderDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gezien = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huuraanvragen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huuraanvragen_ParticuliereHuurders_ParticuliereHuurderId",
                        column: x => x.ParticuliereHuurderId,
                        principalTable: "ParticuliereHuurders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Huuraanvragen_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Schadeclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoertuigId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schadeclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schadeclaims_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonnementen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HuurbeheerderId = table.Column<int>(type: "int", nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prijs_per_maand = table.Column<double>(type: "float", nullable: false),
                    Max_huurders = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Einddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Soort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geaccepteerd = table.Column<bool>(type: "bit", nullable: true),
                    Reden = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnementen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnementen_Huurbeheerders_HuurbeheerderId",
                        column: x => x.HuurbeheerderId,
                        principalTable: "Huurbeheerders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigregistraties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoertuigId = table.Column<int>(type: "int", nullable: false),
                    Inname = table.Column<DateOnly>(type: "date", nullable: true),
                    HuuraanvraagId = table.Column<int>(type: "int", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigregistraties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voertuigregistraties_Huuraanvragen_HuuraanvraagId",
                        column: x => x.HuuraanvraagId,
                        principalTable: "Huuraanvragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voertuigregistraties_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZakelijkeHuurders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HuurbeheerderId = table.Column<int>(type: "int", nullable: true),
                    AbonnementId = table.Column<int>(type: "int", nullable: true),
                    Factuuradres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakelijkeHuurders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZakelijkeHuurders_Abonnementen_AbonnementId",
                        column: x => x.AbonnementId,
                        principalTable: "Abonnementen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ZakelijkeHuurders_Huurbeheerders_HuurbeheerderId",
                        column: x => x.HuurbeheerderId,
                        principalTable: "Huurbeheerders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BackOfficeId = table.Column<int>(type: "int", nullable: true),
                    FrontOfficeId = table.Column<int>(type: "int", nullable: true),
                    BedrijfId = table.Column<int>(type: "int", nullable: true),
                    ZakelijkeHuurderId = table.Column<int>(type: "int", nullable: true),
                    ParticuliereHuurderId = table.Column<int>(type: "int", nullable: true),
                    HuurbeheerderId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_BackOfficeMedewerkers_BackOfficeId",
                        column: x => x.BackOfficeId,
                        principalTable: "BackOfficeMedewerkers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Bedrijven_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijven",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_FrontOfficeMedewerkers_FrontOfficeId",
                        column: x => x.FrontOfficeId,
                        principalTable: "FrontOfficeMedewerkers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Huurbeheerders_HuurbeheerderId",
                        column: x => x.HuurbeheerderId,
                        principalTable: "Huurbeheerders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ParticuliereHuurders_ParticuliereHuurderId",
                        column: x => x.ParticuliereHuurderId,
                        principalTable: "ParticuliereHuurders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ZakelijkeHuurders_ZakelijkeHuurderId",
                        column: x => x.ZakelijkeHuurderId,
                        principalTable: "ZakelijkeHuurders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnementen_HuurbeheerderId",
                table: "Abonnementen",
                column: "HuurbeheerderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BackOfficeId",
                table: "AspNetUsers",
                column: "BackOfficeId",
                unique: true,
                filter: "[BackOfficeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BedrijfId",
                table: "AspNetUsers",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FrontOfficeId",
                table: "AspNetUsers",
                column: "FrontOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HuurbeheerderId",
                table: "AspNetUsers",
                column: "HuurbeheerderId",
                unique: true,
                filter: "[HuurbeheerderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParticuliereHuurderId",
                table: "AspNetUsers",
                column: "ParticuliereHuurderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId",
                unique: true,
                filter: "[ZakelijkeHuurderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Huuraanvragen_ParticuliereHuurderId",
                table: "Huuraanvragen",
                column: "ParticuliereHuurderId");

            migrationBuilder.CreateIndex(
                name: "IX_Huuraanvragen_VoertuigId",
                table: "Huuraanvragen",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Huurbeheerders_BedrijfId",
                table: "Huurbeheerders",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Schadeclaims_VoertuigId",
                table: "Schadeclaims",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigregistraties_HuuraanvraagId",
                table: "Voertuigregistraties",
                column: "HuuraanvraagId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigregistraties_VoertuigId",
                table: "Voertuigregistraties",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakelijkeHuurders_AbonnementId",
                table: "ZakelijkeHuurders",
                column: "AbonnementId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakelijkeHuurders_HuurbeheerderId",
                table: "ZakelijkeHuurders",
                column: "HuurbeheerderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Schadeclaims");

            migrationBuilder.DropTable(
                name: "Voertuigregistraties");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Huuraanvragen");

            migrationBuilder.DropTable(
                name: "BackOfficeMedewerkers");

            migrationBuilder.DropTable(
                name: "FrontOfficeMedewerkers");

            migrationBuilder.DropTable(
                name: "ZakelijkeHuurders");

            migrationBuilder.DropTable(
                name: "ParticuliereHuurders");

            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DropTable(
                name: "Abonnementen");

            migrationBuilder.DropTable(
                name: "Huurbeheerders");

            migrationBuilder.DropTable(
                name: "Bedrijven");
        }
    }
}
