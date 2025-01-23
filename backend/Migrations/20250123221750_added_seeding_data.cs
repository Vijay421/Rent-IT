using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abonnementen",
                columns: new[] { "Id", "Einddatum", "Geaccepteerd", "HuurbeheerderId", "Max_huurders", "Naam", "Prijs_per_maand", "Reden", "Soort", "Startdatum" },
                values: new object[] { 1, new DateOnly(2026, 1, 1), null, null, 10, "abbo", 12.199999999999999, null, "prepaid", new DateOnly(2025, 5, 12) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0833c56d-8815-4d8b-a223-3ca85a1818c8", null, "bedrijf", "BEDRIJF" },
                    { "5471bab0-fd17-448b-9ff4-f0ee36cb5077", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "582d9a19-25fa-4c79-a4e1-0c132a3e959b", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "84393d42-32f7-4015-978f-289ae49d95c5", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "84da30ee-d97a-479e-bd79-6d2b6b37d10e", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "d8ff584b-d59a-4d79-ac34-8960ad850d4e", null, "admin", "ADMIN" },
                    { "e508d6ef-5618-4beb-a060-93059af94820", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "EindDatum", "Kenteken", "Kleur", "Merk", "Opmerking", "Prijs", "Soort", "StartDatum", "Status", "Type", "VerwijderdDatum" },
                values: new object[,]
                {
                    { 1, 2018, new DateOnly(2025, 1, 4), "AB-123-CD", "Red", "Toyota", "", 50.0, "Auto", new DateOnly(2025, 1, 1), "Verhuurbaar", "Corolla", null },
                    { 2, 2019, new DateOnly(2025, 1, 4), "EF-456-GH", "Blue", "Ford", "", 51.390000000000001, "Auto", new DateOnly(2025, 1, 1), "Verhuurbaar", "Focus", null },
                    { 3, 2020, new DateOnly(2025, 1, 5), "IJ-789-KL", "Black", "Volkswagen", "", 40.0, "Auto", new DateOnly(2025, 1, 3), "Verhuurbaar", "Golf", null },
                    { 4, 2017, new DateOnly(2025, 12, 10), "MN-012-OP", "White", "Honda", "", 27.0, "Auto", new DateOnly(2025, 1, 15), "Verhuurbaar", "Civic", null },
                    { 5, 2021, new DateOnly(2025, 10, 25), "QR-345-ST", "Gray", "BMW", "", 64.390000000000001, "Auto", new DateOnly(2025, 4, 15), "Verhuurbaar", "3 Series", null },
                    { 6, 2016, new DateOnly(2025, 9, 18), "UV-678-WX", "Silver", "Audi", "", 21.469999999999999, "Auto", new DateOnly(2025, 5, 5), "Verhuurbaar", "A4", null },
                    { 7, 2022, new DateOnly(2025, 6, 15), "YZ-901-AB", "Blue", "Mercedes", "", 43.5, "Auto", new DateOnly(2025, 6, 1), "Verhuurbaar", "C-Class", null },
                    { 8, 2015, new DateOnly(2025, 12, 20), "CD-234-EF", "Green", "Nissan", "", 98.209999999999994, "Auto", new DateOnly(2025, 7, 10), "Verhuurbaar", "Qashqai", null },
                    { 9, 2021, new DateOnly(2025, 12, 10), "GH-567-IJ", "Red", "Peugeot", "", 51.270000000000003, "Auto", new DateOnly(2025, 8, 1), "Verhuurbaar", "208", null },
                    { 10, 2018, new DateOnly(2025, 11, 15), "KL-890-MN", "Black", "Renault", "", 43.75, "Auto", new DateOnly(2025, 9, 5), "Verhuurbaar", "Clio", null },
                    { 11, 2017, new DateOnly(2025, 10, 12), "OP-123-QR", "White", "Hobby", "", 54.670000000000002, "Auto", new DateOnly(2025, 10, 1), "Verhuurbaar", "The Luxury", null },
                    { 12, 2018, new DateOnly(2025, 11, 20), "ST-456-UV", "Gray", "Fendt", "", 85.310000000000002, "Auto", new DateOnly(2025, 11, 10), "Verhuurbaar", "White", null },
                    { 13, 2019, new DateOnly(2025, 12, 12), "WX-789-YZ", "Blue", "Knaus", "", 65.319999999999993, "Auto", new DateOnly(2025, 12, 1), "Verhuurbaar", "Sports", null },
                    { 14, 2016, new DateOnly(2025, 1, 22), "AB-012-CD", "Green", "Dethle-s", "", 65.0, "Auto", new DateOnly(2025, 1, 10), "Verhuurbaar", "Camper", null },
                    { 15, 2020, new DateOnly(2025, 5, 25), "EF-345-GH", "Silver", "Adria", "", 41.0, "Auto", new DateOnly(2025, 2, 15), "Verhuurbaar", "Altea", null },
                    { 16, 2015, new DateOnly(2025, 3, 18), "IJ-678-KL", "Red", "Eriba", "", 67.120000000000005, "Auto", new DateOnly(2025, 3, 10), "Verhuurbaar", "Touring", null },
                    { 17, 2021, new DateOnly(2025, 7, 12), "MN-901-OP", "Black", "Tabbert", "", 60.0, "Auto", new DateOnly(2025, 4, 5), "Verhuurbaar", "Puccini", null },
                    { 18, 2019, new DateOnly(2025, 12, 25), "QR-234-ST", "White", "Burstner", "", 58.0, "Auto", new DateOnly(2025, 5, 15), "Verhuurbaar", "Premio", null },
                    { 19, 2018, new DateOnly(2025, 7, 1), "UV-567-WX", "Blue", "LMC", "", 55.0, "Auto", new DateOnly(2025, 6, 20), "Verhuurbaar", "Music", null },
                    { 20, 2022, new DateOnly(2025, 9, 22), "YZ-890-AB", "Gray", "Sprite", "", 48.0, "Auto", new DateOnly(2025, 8, 10), "Verhuurbaar", "Cruzer", null },
                    { 21, 2018, new DateOnly(2025, 11, 25), "CD-123-EF", "Red", "Volkswagen", "", 70.0, "Auto", new DateOnly(2025, 9, 15), "Verhuurbaar", "California", null },
                    { 22, 2019, new DateOnly(2025, 10, 18), "GH-456-IJ", "Blue", "Mercedes", "", 85.0, "Auto", new DateOnly(2025, 10, 5), "Verhuurbaar", "Marco Polo", null },
                    { 23, 2020, new DateOnly(2025, 11, 12), "KL-789-MN", "Black", "Ford", "", 72.0, "Auto", new DateOnly(2025, 10, 1), "Verhuurbaar", "Nugget", null },
                    { 24, 2017, new DateOnly(2025, 12, 20), "OP-012-QR", "White", "Fiat", "", 45.0, "Auto", new DateOnly(2025, 11, 10), "Verhuurbaar", "Ducato", null },
                    { 25, 2021, new DateOnly(2025, 4, 25), "ST-345-UV", "Gray", "Lemon", "", 52.0, "Auto", new DateOnly(2025, 1, 15), "Verhuurbaar", "Jumper", null },
                    { 26, 2016, new DateOnly(2025, 6, 20), "WX-678-YZ", "Silver", "Peugeot", "", 47.0, "Auto", new DateOnly(2025, 2, 10), "Verhuurbaar", "Boxer", null },
                    { 27, 2022, new DateOnly(2025, 8, 15), "AB-901-CD", "Blue", "Renault", "", 60.0, "Auto", new DateOnly(2025, 3, 5), "Verhuurbaar", "Master", null },
                    { 28, 2015, new DateOnly(2025, 10, 12), "EF-234-GH", "Green", "Iveco", "", 63.0, "Auto", new DateOnly(2025, 4, 1), "Verhuurbaar", "Daily", null },
                    { 29, 2021, new DateOnly(2025, 12, 1), "IJ-567-KL", "Red", "Opel", "", 58.0, "Auto", new DateOnly(2025, 5, 15), "Verhuurbaar", "Movano", null },
                    { 30, 2018, new DateOnly(2025, 12, 20), "MN-890-OP", "Black", "Nissan", "", 56.0, "Auto", new DateOnly(2025, 6, 10), "Verhuurbaar", "NV400", null },
                    { 31, 2019, new DateOnly(2025, 10, 5), "QR-123-ST", "Silver", "Kia", "", 39.0, "Auto", new DateOnly(2025, 7, 15), "Verhuurbaar", "Sportage", null },
                    { 32, 2020, new DateOnly(2026, 1, 25), "UV-456-WX", "Blue", "Hyundai", "", 42.5, "Auto", new DateOnly(2025, 8, 1), "Verhuurbaar", "Tucson", null },
                    { 33, 2017, new DateOnly(2026, 3, 10), "YZ-789-AB", "Green", "Skoda", "", 37.0, "Auto", new DateOnly(2025, 9, 10), "Verhuurbaar", "Octavia", null },
                    { 34, 2018, new DateOnly(2026, 6, 15), "CD-012-EF", "White", "Mazda", "", 35.75, "Auto", new DateOnly(2025, 10, 15), "Verhuurbaar", "3", null },
                    { 35, 2021, new DateOnly(2026, 4, 5), "GH-345-IJ", "Gray", "Subaru", "", 49.0, "Auto", new DateOnly(2025, 11, 1), "Verhuurbaar", "Impreza", null },
                    { 36, 2019, new DateOnly(2026, 7, 20), "KL-678-MN", "Black", "Suzuki", "", 41.25, "Auto", new DateOnly(2025, 12, 10), "Verhuurbaar", "Vitara", null },
                    { 37, 2020, new DateOnly(2025, 8, 10), "OP-901-QR", "Silver", "Volvo", "", 47.5, "Auto", new DateOnly(2025, 1, 1), "Verhuurbaar", "XC60", null },
                    { 38, 2017, new DateOnly(2025, 9, 1), "ST-234-UV", "Red", "Mitsubishi", "", 40.0, "Auto", new DateOnly(2025, 2, 15), "Verhuurbaar", "Outlander", null },
                    { 39, 2022, new DateOnly(2025, 12, 10), "WX-567-YZ", "Green", "Jeep", "", 75.0, "Auto", new DateOnly(2025, 3, 20), "Verhuurbaar", "Wrangler", null },
                    { 40, 2021, new DateOnly(2025, 8, 25), "YZ-890-AB", "Blue", "Land Rover", "", 68.5, "Auto", new DateOnly(2025, 4, 25), "Verhuurbaar", "Defender", null },
                    { 41, 2018, new DateOnly(2025, 10, 1), "CD-123-EF", "Gray", "Bailey", "", 66.75, "Auto", new DateOnly(2025, 5, 5), "Verhuurbaar", "Unicorn", null },
                    { 42, 2019, new DateOnly(2025, 11, 12), "GH-456-IJ", "Black", "Lunar", "", 62.0, "Auto", new DateOnly(2025, 6, 15), "Verhuurbaar", "Clubman", null },
                    { 43, 2020, new DateOnly(2025, 12, 5), "KL-789-MN", "White", "Swi-", "", 70.5, "Auto", new DateOnly(2025, 7, 10), "Verhuurbaar", "Conqueror", null },
                    { 44, 2017, new DateOnly(2025, 11, 15), "OP-012-QR", "Silver", "Elddis", "", 55.0, "Auto", new DateOnly(2025, 8, 20), "Verhuurbaar", "Avante", null },
                    { 45, 2021, new DateOnly(2026, 1, 10), "ST-345-UV", "Blue", "Compass", "", 74.0, "Auto", new DateOnly(2025, 9, 15), "Verhuurbaar", "Casita", null },
                    { 46, 2016, new DateOnly(2026, 4, 20), "WX-678-YZ", "Green", "Coachman", "", 59.0, "Auto", new DateOnly(2025, 10, 1), "Verhuurbaar", "VIP", null },
                    { 47, 2022, new DateOnly(2026, 5, 5), "AB-901-CD", "Red", "Buccaneer", "", 77.0, "Auto", new DateOnly(2025, 11, 5), "Verhuurbaar", "Commodore", null },
                    { 48, 2015, new DateOnly(2026, 6, 10), "EF-234-GH", "Black", "Caravelair", "", 49.5, "Auto", new DateOnly(2025, 12, 15), "Verhuurbaar", "Allegra", null },
                    { 49, 2021, new DateOnly(2025, 6, 15), "IJ-567-KL", "White", "Sterckeman", "", 63.0, "Auto", new DateOnly(2025, 1, 10), "Verhuurbaar", "Starle-", null },
                    { 50, 2018, new DateOnly(2025, 7, 12), "MN-890-OP", "Gray", "Tab", "", 51.0, "Auto", new DateOnly(2025, 2, 5), "Verhuurbaar", "320", null },
                    { 51, 2019, new DateOnly(2025, 8, 25), "QR-123-ST", "Blue", "Volkswagen", "", 72.5, "Auto", new DateOnly(2025, 3, 20), "Verhuurbaar", "Grand California", null },
                    { 52, 2020, new DateOnly(2025, 9, 10), "UV-456-WX", "Green", "Mercedes", "", 58.5, "Auto", new DateOnly(2025, 4, 15), "Verhuurbaar", "Sprinter", null },
                    { 53, 2017, new DateOnly(2025, 10, 20), "YZ-789-AB", "Red", "Ford", "", 43.5, "Auto", new DateOnly(2025, 5, 10), "Verhuurbaar", "Transit Custom", null },
                    { 54, 2018, new DateOnly(2025, 11, 15), "CD-012-EF", "Black", "Fiat", "", 45.0, "Auto", new DateOnly(2025, 6, 5), "Verhuurbaar", "Talento", null },
                    { 55, 2021, new DateOnly(2025, 12, 5), "GH-345-IJ", "White", "Lemon", "", 50.0, "Auto", new DateOnly(2025, 7, 1), "Verhuurbaar", "SpaceTourer", null },
                    { 56, 2019, new DateOnly(2026, 1, 10), "KL-678-MN", "Gray", "Peugeot", "", 47.0, "Auto", new DateOnly(2025, 8, 1), "Verhuurbaar", "Traveller", null },
                    { 57, 2020, new DateOnly(2026, 2, 15), "OP-901-QR", "Blue", "Renault", "", 49.5, "Auto", new DateOnly(2025, 9, 1), "Verhuurbaar", "Tra-c", null },
                    { 58, 2017, new DateOnly(2026, 3, 20), "ST-234-UV", "Green", "Iveco", "", 52.0, "Auto", new DateOnly(2025, 10, 1), "Verhuurbaar", "Daily", null },
                    { 59, 2022, new DateOnly(2026, 4, 25), "WX-567-YZ", "Red", "Opel", "", 66.0, "Auto", new DateOnly(2025, 11, 1), "Verhuurbaar", "Vivaro", null },
                    { 60, 2021, new DateOnly(2026, 5, 10), "YZ-890-AB", "Black", "Nissan", "", 54.0, "Auto", new DateOnly(2025, 12, 1), "Verhuurbaar", "Primastar", null },
                    { 61, 2019, new DateOnly(2025, 7, 15), "CD-123-EF", "White", "Toyota", "", 37.5, "Auto", new DateOnly(2025, 2, 10), "Verhuurbaar", "Yaris", null },
                    { 62, 2020, new DateOnly(2025, 8, 20), "GH-456-IJ", "Gray", "Ford", "", 41.0, "Auto", new DateOnly(2025, 3, 15), "Verhuurbaar", "Kuga", null },
                    { 63, 2017, new DateOnly(2025, 9, 25), "KL-789-MN", "Blue", "Volkswagen", "", 39.5, "Auto", new DateOnly(2025, 4, 15), "Verhuurbaar", "Passat", null },
                    { 64, 2018, new DateOnly(2025, 10, 10), "OP-012-QR", "Green", "Honda", "", 42.0, "Auto", new DateOnly(2025, 5, 10), "Verhuurbaar", "Agreed", null },
                    { 65, 2021, new DateOnly(2025, 11, 20), "ST-345-UV", "Silver", "BMW", "", 72.5, "Auto", new DateOnly(2025, 6, 20), "Verhuurbaar", "X5", null },
                    { 66, 2019, new DateOnly(2025, 12, 25), "WX-678-YZ", "Black", "Audi", "", 68.0, "Auto", new DateOnly(2025, 7, 15), "Verhuurbaar", "Q7", null },
                    { 67, 2020, new DateOnly(2026, 1, 30), "AB-901-CD", "White", "Mercedes", "", 65.0, "Auto", new DateOnly(2025, 8, 10), "Verhuurbaar", "GLC", null },
                    { 68, 2017, new DateOnly(2026, 2, 10), "EF-234-GH", "Gray", "Nissan", "", 38.0, "Auto", new DateOnly(2025, 9, 5), "Verhuurbaar", "Juke", null },
                    { 69, 2022, new DateOnly(2026, 3, 20), "IJ-567-KL", "Blue", "Peugeot", "", 45.0, "Auto", new DateOnly(2025, 10, 15), "Verhuurbaar", "308", null },
                    { 70, 2021, new DateOnly(2026, 4, 15), "MN-890-OP", "Green", "Renault", "", 43.5, "Auto", new DateOnly(2025, 11, 20), "Verhuurbaar", "Megane", null },
                    { 71, 2018, new DateOnly(2026, 5, 20), "QR-123-ST", "Red", "Tabbert", "", 62.0, "Auto", new DateOnly(2025, 12, 10), "Verhuurbaar", "Rossini", null },
                    { 72, 2019, new DateOnly(2025, 6, 25), "UV-456-WX", "Black", "Dethle-s", "", 64.0, "Auto", new DateOnly(2025, 1, 15), "Verhuurbaar", "Beduin", null },
                    { 73, 2020, new DateOnly(2025, 7, 30), "YZ-789-AB", "White", "Fendt", "", 66.5, "Auto", new DateOnly(2025, 2, 20), "Verhuurbaar", "Tendency", null },
                    { 74, 2017, new DateOnly(2025, 8, 15), "CD-012-EF", "Silver", "Knaus", "", 58.0, "Auto", new DateOnly(2025, 3, 25), "Verhuurbaar", "Sudwind", null },
                    { 75, 2021, new DateOnly(2025, 9, 20), "GH-345-IJ", "Blue", "Hobby", "", 68.0, "Auto", new DateOnly(2025, 4, 10), "Verhuurbaar", "Excellent", null },
                    { 76, 2016, new DateOnly(2025, 10, 25), "KL-678-MN", "Green", "Adria", "", 60.5, "Auto", new DateOnly(2025, 5, 15), "Verhuurbaar", "Ac-on", null },
                    { 77, 2022, new DateOnly(2025, 11, 20), "OP-901-QR", "Red", "Eriba", "", 72.0, "Auto", new DateOnly(2025, 6, 20), "Verhuurbaar", "Feeling", null },
                    { 78, 2015, new DateOnly(2025, 12, 10), "ST-234-UV", "Black", "Burstner", "", 55.0, "Auto", new DateOnly(2025, 7, 25), "Verhuurbaar", "Aversely", null },
                    { 79, 2021, new DateOnly(2026, 1, 20), "WX-567-YZ", "White", "LMC", "", 69.0, "Auto", new DateOnly(2025, 8, 30), "Verhuurbaar", "Vivo", null },
                    { 80, 2018, new DateOnly(2026, 2, 25), "YZ-890-AB", "Gray", "Sprite", "", 52.0, "Auto", new DateOnly(2025, 9, 15), "Verhuurbaar", "Major", null },
                    { 81, 2019, new DateOnly(2025, 10, 15), "CD-123-EF", "Black", "Volkswagen", "", 57.0, "Auto", new DateOnly(2025, 1, 15), "Verhuurbaar", "Mul-van", null },
                    { 82, 2020, new DateOnly(2025, 11, 5), "GH-456-IJ", "White", "Mercedes", "", 63.0, "Auto", new DateOnly(2025, 2, 10), "Verhuurbaar", "Vito", null },
                    { 83, 2017, new DateOnly(2025, 12, 20), "KL-789-MN", "Gray", "Ford", "", 49.5, "Auto", new DateOnly(2025, 7, 20), "Verhuurbaar", "Custom", null },
                    { 84, 2018, new DateOnly(2026, 1, 10), "OP-012-QR", "Blue", "Fiat", "", 51.0, "Auto", new DateOnly(2025, 3, 5), "Verhuurbaar", "Scudo", null },
                    { 85, 2021, new DateOnly(2026, 2, 15), "ST-345-UV", "Green", "Lemon", "", 55.5, "Auto", new DateOnly(2025, 9, 15), "Verhuurbaar", "Berlingo", null },
                    { 86, 2019, new DateOnly(2026, 3, 5), "WX-678-YZ", "Red", "Peugeot", "", 52.5, "Auto", new DateOnly(2025, 3, 5), "Verhuurbaar", "Partner", null },
                    { 87, 2020, new DateOnly(2026, 4, 15), "AB-901-CD", "Black", "Renault", "", 53.0, "Auto", new DateOnly(2025, 11, 15), "Verhuurbaar", "Kangoo", null },
                    { 88, 2017, new DateOnly(2025, 9, 10), "EF-234-GH", "White", "Iveco", "", 59.0, "Auto", new DateOnly(2025, 5, 10), "Verhuurbaar", "Eurocargo", null },
                    { 89, 2022, new DateOnly(2025, 10, 15), "IJ-567-KL", "Gray", "Opel", "", 61.0, "Auto", new DateOnly(2025, 6, 15), "Verhuurbaar", "Combo", null },
                    { 90, 2021, new DateOnly(2025, 11, 10), "MN-890-OP", "Blue", "Nissan", "", 62.5, "Auto", new DateOnly(2025, 7, 10), "Verhuurbaar", "NV200", null },
                    { 91, 2018, new DateOnly(2025, 12, 1), "QR-123-ST", "Green", "Kia", "", 40.0, "Auto", new DateOnly(2025, 8, 1), "Verhuurbaar", "Picanto", null },
                    { 92, 2019, new DateOnly(2026, 1, 20), "UV-456-WX", "Red", "Hyundai", "", 43.5, "Auto", new DateOnly(2025, 2, 20), "Verhuurbaar", "i30", null },
                    { 93, 2020, new DateOnly(2026, 3, 15), "YZ-789-AB", "Black", "Skoda", "", 59.0, "Auto", new DateOnly(2025, 10, 15), "Verhuurbaar", "Superb", null },
                    { 94, 2017, new DateOnly(2026, 4, 5), "CD-012-EF", "White", "Mazda", "", 45.0, "Auto", new DateOnly(2025, 11, 5), "Verhuurbaar", "6", null },
                    { 95, 2021, new DateOnly(2026, 5, 15), "GH-345-IJ", "Gray", "Subaru", "", 58.5, "Auto", new DateOnly(2025, 1, 15), "Verhuurbaar", "Forester", null },
                    { 96, 2019, new DateOnly(2025, 10, 20), "KL-678-MN", "Silver", "Suzuki", "", 42.0, "Auto", new DateOnly(2025, 5, 20), "Verhuurbaar", "Swift", null },
                    { 97, 2020, new DateOnly(2025, 11, 25), "OP-901-QR", "Blue", "Volvo", "", 65.0, "Auto", new DateOnly(2025, 6, 25), "Verhuurbaar", "XC90", null },
                    { 98, 2017, new DateOnly(2025, 12, 15), "ST-234-UV", "Green", "Mitsubishi", "", 47.0, "Auto", new DateOnly(2025, 7, 15), "Verhuurbaar", "ASX", null },
                    { 99, 2022, new DateOnly(2026, 1, 5), "WX-567-YZ", "Red", "Jeep", "", 70.0, "Auto", new DateOnly(2025, 8, 5), "Verhuurbaar", "Cherokee", null },
                    { 100, 2021, new DateOnly(2026, 2, 10), "YZ-890-AB", "Blue", "Land Rover", "", 73.0, "Auto", new DateOnly(2025, 9, 10), "Verhuurbaar", "Discovery", null },
                    { 101, 2018, new DateOnly(2026, 3, 15), "AB-123-CD", "Red", "Volkswagen", "", 69.0, "Camper", new DateOnly(2025, 10, 15), "Verhuurbaar", "California", null },
                    { 102, 2019, new DateOnly(2026, 4, 5), "EF-456-GH", "Silver", "Mercedes", "", 72.0, "Camper", new DateOnly(2025, 11, 5), "Verhuurbaar", "Marco Polo", null },
                    { 103, 2020, new DateOnly(2026, 5, 15), "IJ-789-KL", "Blue", "Ford", "", 66.0, "Camper", new DateOnly(2025, 12, 15), "Verhuurbaar", "Transit Custom", null },
                    { 104, 2017, new DateOnly(2025, 10, 10), "MN-012-OP", "White", "Fiat", "", 61.0, "Camper", new DateOnly(2025, 1, 10), "Verhuurbaar", "Ducato", null },
                    { 105, 2021, new DateOnly(2025, 1, 24), "QR-345-ST", "Gray", "Citroën", "", 65.0, "Camper", new DateOnly(2025, 1, 10), "Verhuurbaar", "Jumper", null },
                    { 106, 2016, new DateOnly(2025, 2, 4), "UV-678-WX", "Black", "Peugeot", "", 68.0, "Camper", new DateOnly(2025, 2, 1), "Verhuurbaar", "Boxer", null },
                    { 107, 2022, new DateOnly(2026, 1, 5), "YZ-901-AB", "Green", "Renault", "", 74.0, "Camper", new DateOnly(2025, 3, 5), "Verhuurbaar", "Master", null },
                    { 108, 2015, new DateOnly(2026, 2, 15), "CD-234-EF", "Blue", "Nissan", "", 62.5, "Camper", new DateOnly(2025, 9, 15), "Verhuurbaar", "NV400", null },
                    { 109, 2021, new DateOnly(2026, 3, 1), "GH-567-IJ", "Silver", "Opel", "", 67.0, "Camper", new DateOnly(2025, 10, 1), "Verhuurbaar", "Movano", null },
                    { 110, 2018, new DateOnly(2026, 4, 20), "KL-890-MN", "Red", "Iveco", "", 63.5, "Camper", new DateOnly(2025, 11, 20), "Verhuurbaar", "Daily", null },
                    { 111, 2017, new DateOnly(2026, 5, 15), "OP-123-QR", "White", "Volkswagen", "", 70.0, "Camper", new DateOnly(2025, 12, 15), "Verhuurbaar", "Grand California", null },
                    { 112, 2019, new DateOnly(2025, 10, 10), "ST-456-UV", "Blue", "Mercedes", "", 72.5, "Camper", new DateOnly(2025, 5, 10), "Verhuurbaar", "Sprinter", null },
                    { 113, 2020, new DateOnly(2025, 11, 15), "WX-789-YZ", "Black", "Ford", "", 75.0, "Camper", new DateOnly(2025, 6, 15), "Verhuurbaar", "Nugget", null },
                    { 114, 2016, new DateOnly(2025, 12, 20), "AB-012-CD", "Green", "Fiat", "", 61.0, "Camper", new DateOnly(2025, 7, 20), "Verhuurbaar", "Talento", null },
                    { 115, 2018, new DateOnly(2026, 1, 5), "EF-345-GH", "Red", "Citroën", "", 66.0, "Camper", new DateOnly(2025, 2, 5), "Verhuurbaar", "SpaceTourer", null },
                    { 116, 2021, new DateOnly(2026, 2, 10), "IJ-678-KL", "Black", "Peugeot", "", 69.0, "Camper", new DateOnly(2025, 3, 10), "Verhuurbaar", "Traveller", null },
                    { 117, 2020, new DateOnly(2026, 3, 15), "MN-901-OP", "White", "Renault", "", 68.5, "Camper", new DateOnly(2025, 4, 15), "Verhuurbaar", "Tra-c", null },
                    { 118, 2019, new DateOnly(2025, 10, 20), "QR-234-ST", "Silver", "Nissan", "", 62.5, "Camper", new DateOnly(2025, 5, 20), "Verhuurbaar", "Primastar", null },
                    { 119, 2022, new DateOnly(2025, 11, 25), "UV-567-WX", "Gray", "Opel", "", 70.0, "Camper", new DateOnly(2025, 6, 25), "Verhuurbaar", "Vivaro", null },
                    { 120, 2017, new DateOnly(2025, 12, 15), "YZ-890-AB", "Black", "Iveco", "", 65.0, "Camper", new DateOnly(2025, 7, 15), "Verhuurbaar", "Eurocargo", null },
                    { 121, 2018, new DateOnly(2025, 12, 1), "CD-123-EF", "Blue", "Volkswagen", "", 60.0, "Camper", new DateOnly(2025, 8, 1), "Verhuurbaar", "Mul-van", null },
                    { 122, 2020, new DateOnly(2026, 1, 5), "GH-456-IJ", "Green", "Mercedes", "", 64.0, "Camper", new DateOnly(2025, 3, 5), "Verhuurbaar", "Vito", null },
                    { 123, 2017, new DateOnly(2026, 2, 15), "KL-789-MN", "Silver", "Ford", "", 58.5, "Camper", new DateOnly(2025, 5, 15), "Verhuurbaar", "Kuga Camper", null },
                    { 124, 2018, new DateOnly(2026, 3, 20), "OP-012-QR", "Red", "Fiat", "", 62.0, "Camper", new DateOnly(2025, 6, 20), "Verhuurbaar", "Scudo", null },
                    { 125, 2019, new DateOnly(2025, 12, 10), "ST-345-UV", "White", "Citroën", "", 57.5, "Camper", new DateOnly(2025, 10, 10), "Verhuurbaar", "Berlingo", null },
                    { 126, 2016, new DateOnly(2026, 4, 15), "WX-678-YZ", "Gray", "Peugeot", "", 66.0, "Camper", new DateOnly(2025, 2, 15), "Verhuurbaar", "Expert Camper", null },
                    { 127, 2022, new DateOnly(2026, 5, 5), "AB-901-CD", "Blue", "Renault", "", 70.5, "Camper", new DateOnly(2025, 4, 5), "Verhuurbaar", "Kangoo Camper", null },
                    { 128, 2015, new DateOnly(2026, 7, 15), "EF-234-GH", "Black", "Nissan", "", 61.0, "Camper", new DateOnly(2025, 6, 15), "Verhuurbaar", "Juke Camper", null },
                    { 129, 2021, new DateOnly(2025, 9, 5), "GH-567-IJ", "Green", "Opel", "", 65.0, "Camper", new DateOnly(2025, 8, 5), "Verhuurbaar", "Za-ra Camper", null },
                    { 130, 2018, new DateOnly(2025, 10, 15), "KL-890-MN", "Red", "Iveco", "", 63.5, "Camper", new DateOnly(2025, 3, 15), "Verhuurbaar", "Camper 2000", null },
                    { 131, 2017, new DateOnly(2025, 12, 1), "OP-123-QR", "Black", "Volkswagen", "", 60.0, "Camper", new DateOnly(2025, 5, 1), "Verhuurbaar", "Combi", null },
                    { 132, 2021, new DateOnly(2026, 1, 5), "ST-456-UV", "Silver", "Mercedes", "", 75.0, "Camper", new DateOnly(2025, 6, 5), "Verhuurbaar", "Sprinter XXL", null },
                    { 133, 2020, new DateOnly(2026, 2, 10), "WX-789-YZ", "Blue", "Ford", "", 72.5, "Camper", new DateOnly(2025, 7, 10), "Verhuurbaar", "Custom Camper", null },
                    { 134, 2016, new DateOnly(2026, 3, 15), "AB-012-CD", "White", "Fiat", "", 61.5, "Camper", new DateOnly(2025, 12, 15), "Verhuurbaar", "Ducato Maxi", null },
                    { 135, 2018, new DateOnly(2026, 4, 10), "EF-345-GH", "Green", "Citroën", "", 62.5, "Camper", new DateOnly(2025, 1, 10), "Verhuurbaar", "Jumper Camper", null },
                    { 136, 2021, new DateOnly(2026, 5, 5), "IJ-678-KL", "Black", "Peugeot", "", 69.5, "Camper", new DateOnly(2025, 2, 5), "Verhuurbaar", "Boxer XL", null },
                    { 137, 2019, new DateOnly(2026, 6, 20), "MN-901-OP", "Gray", "Renault", "", 67.0, "Camper", new DateOnly(2025, 3, 20), "Verhuurbaar", "Master Pro", null },
                    { 138, 2022, new DateOnly(2026, 7, 15), "QR-234-ST", "Blue", "Nissan", "", 74.0, "Camper", new DateOnly(2025, 4, 15), "Verhuurbaar", "NV300 Camper", null },
                    { 139, 2017, new DateOnly(2026, 8, 10), "UV-567-WX", "Silver", "Opel", "", 65.0, "Camper", new DateOnly(2025, 9, 10), "Verhuurbaar", "Vivaro XL", null },
                    { 140, 2018, new DateOnly(2026, 2, 15), "YZ-890-AB", "Red", "Iveco", "", 66.5, "Camper", new DateOnly(2025, 2, 15), "Verhuurbaar", "Daily Pro", null },
                    { 141, 2020, new DateOnly(2026, 3, 20), "CD-123-EF", "Green", "Volkswagen", "", 72.5, "Camper", new DateOnly(2025, 3, 20), "Verhuurbaar", "T6 California", null },
                    { 142, 2019, new DateOnly(2026, 4, 15), "GH-456-IJ", "Black", "Mercedes", "", 75.0, "Camper", new DateOnly(2025, 4, 15), "Verhuurbaar", "V-Class Camper", null },
                    { 143, 2022, new DateOnly(2025, 5, 10), "KL-789-MN", "White", "Ford", "", 76.0, "Camper", new DateOnly(2025, 1, 10), "Verhuurbaar", "Transit Nugget Plus", null },
                    { 144, 2018, new DateOnly(2025, 7, 15), "AB-123-CD", "White", "Hobby", "", 48.0, "Caravan", new DateOnly(2025, 2, 15), "Verhuurbaar", "The Luxury", null },
                    { 145, 2019, new DateOnly(2025, 8, 20), "EF-456-GH", "Gray", "Fendt", "", 50.0, "Caravan", new DateOnly(2025, 3, 20), "Verhuurbaar", "White", null },
                    { 146, 2020, new DateOnly(2025, 9, 15), "IJ-789-KL", "Black", "Knaus", "", 51.0, "Caravan", new DateOnly(2025, 4, 15), "Verhuurbaar", "Camper", null },
                    { 147, 2021, new DateOnly(2025, 10, 10), "MN-012-OP", "Blue", "Adria", "", 52.5, "Caravan", new DateOnly(2025, 5, 10), "Verhuurbaar", "Adria Home", null },
                    { 148, 2022, new DateOnly(2025, 8, 15), "QR-345-ST", "Green", "Tabbert", "", 54.0, "Caravan", new DateOnly(2025, 3, 15), "Verhuurbaar", "Stylish", null },
                    { 149, 2023, new DateOnly(2025, 9, 20), "UV-678-WX", "Red", "Hobby", "", 55.0, "Caravan", new DateOnly(2025, 4, 20), "Verhuurbaar", "Comfort", null },
                    { 150, 2023, new DateOnly(2025, 7, 15), "YZ-901-AB", "Silver", "Fendt", "", 58.0, "Caravan", new DateOnly(2025, 5, 15), "Verhuurbaar", "Luxury", null },
                    { 151, 2015, new DateOnly(2025, 11, 20), "CD-234-EF", "Blue", "LMC", "", 45.0, "Caravan", new DateOnly(2025, 1, 20), "Verhuurbaar", "Music", null },
                    { 152, 2021, new DateOnly(2025, 12, 25), "GH-567-IJ", "Red", "Sprite", "", 48.0, "Caravan", new DateOnly(2025, 1, 25), "Verhuurbaar", "Cruzer", null },
                    { 153, 2018, new DateOnly(2025, 11, 10), "KL-890-MN", "Gray", "Bailey", "", 47.5, "Caravan", new DateOnly(2025, 2, 10), "Verhuurbaar", "Unicorn", null },
                    { 154, 2017, new DateOnly(2025, 10, 15), "OP-123-QR", "Silver", "Lunar", "", 46.0, "Caravan", new DateOnly(2025, 2, 15), "Verhuurbaar", "Clubman", null },
                    { 155, 2019, new DateOnly(2025, 9, 20), "ST-456-UV", "Blue", "Swi-", "", 49.0, "Caravan", new DateOnly(2025, 2, 20), "Verhuurbaar", "Conqueror", null },
                    { 156, 2020, new DateOnly(2025, 10, 5), "WX-789-YZ", "Green", "Compass", "", 50.0, "Caravan", new DateOnly(2025, 3, 5), "Verhuurbaar", "Casita", null },
                    { 157, 2016, new DateOnly(2025, 10, 10), "AB-012-CD", "Red", "Coachman", "", 46.5, "Caravan", new DateOnly(2025, 3, 10), "Verhuurbaar", "VIP", null },
                    { 158, 2018, new DateOnly(2025, 11, 15), "EF-345-GH", "Black", "Buccaneer", "", 51.0, "Caravan", new DateOnly(2025, 4, 15), "Verhuurbaar", "Commodore", null },
                    { 159, 2021, new DateOnly(2025, 12, 20), "IJ-678-KL", "White", "Caravelair", "", 52.0, "Caravan", new DateOnly(2025, 4, 20), "Verhuurbaar", "Allegra", null },
                    { 160, 2020, new DateOnly(2026, 1, 10), "MN-901-OP", "Silver", "Sterckeman", "", 53.0, "Caravan", new DateOnly(2025, 5, 10), "Verhuurbaar", "Starle-", null },
                    { 161, 2019, new DateOnly(2026, 2, 15), "QR-234-ST", "Blue", "Tab", "", 48.5, "Caravan", new DateOnly(2025, 5, 15), "Verhuurbaar", "320", null },
                    { 162, 2022, new DateOnly(2026, 3, 20), "UV-567-WX", "Gray", "Eriba", "", 55.0, "Caravan", new DateOnly(2025, 6, 20), "Verhuurbaar", "Touring", null },
                    { 163, 2017, new DateOnly(2026, 4, 5), "YZ-890-AB", "Red", "Adria", "", 47.0, "Caravan", new DateOnly(2025, 6, 5), "Verhuurbaar", "Ac-on", null },
                    { 164, 2018, new DateOnly(2026, 5, 10), "CD-123-EF", "White", "Fendt", "", 49.5, "Caravan", new DateOnly(2025, 6, 10), "Verhuurbaar", "Tendency", null },
                    { 165, 2020, new DateOnly(2026, 6, 15), "GH-456-IJ", "Green", "Knaus", "", 52.5, "Caravan", new DateOnly(2025, 7, 15), "Verhuurbaar", "Sudwind", null },
                    { 166, 2017, new DateOnly(2026, 7, 1), "KL-789-MN", "Black", "Hobby", "", 51.0, "Caravan", new DateOnly(2025, 8, 1), "Verhuurbaar", "Excellent", null },
                    { 167, 2019, new DateOnly(2025, 8, 22), "OP-012-QR", "Blue", "Dethle-s", "", 50.0, "Caravan", new DateOnly(2025, 8, 5), "Verhuurbaar", "Beduin", null },
                    { 168, 2021, new DateOnly(2025, 11, 30), "ST-345-UV", "Silver", "Burstner", "", 54.0, "Caravan", new DateOnly(2025, 9, 10), "Verhuurbaar", "Aversely", null },
                    { 169, 2020, new DateOnly(2025, 12, 30), "WX-678-YZ", "Red", "LMC", "", 49.0, "Caravan", new DateOnly(2025, 10, 15), "Verhuurbaar", "Vivo", null },
                    { 170, 2019, new DateOnly(2026, 1, 30), "AB-901-CD", "Green", "Sprite", "", 48.0, "Caravan", new DateOnly(2025, 11, 20), "Verhuurbaar", "Major", null },
                    { 171, 2022, new DateOnly(2026, 2, 5), "EF-234-GH", "White", "Bailey", "", 55.0, "Caravan", new DateOnly(2025, 12, 5), "Verhuurbaar", "Phoenix", null },
                    { 172, 2017, new DateOnly(2025, 3, 10), "GH-567-IJ", "Gray", "Lunar", "", 46.0, "Caravan", new DateOnly(2025, 1, 10), "Verhuurbaar", "Delta", null },
                    { 173, 2018, new DateOnly(2025, 4, 15), "KL-890-MN", "Black", "Swi-", "", 49.5, "Caravan", new DateOnly(2025, 2, 15), "Verhuurbaar", "Elegance", null },
                    { 174, 2021, new DateOnly(2025, 5, 20), "OP-123-QR", "Blue", "Compass", "", 51.0, "Caravan", new DateOnly(2025, 3, 20), "Verhuurbaar", "Corona", null },
                    { 175, 2019, new DateOnly(2025, 6, 5), "ST-456-UV", "Silver", "Coachman", "", 53.0, "Caravan", new DateOnly(2025, 4, 5), "Verhuurbaar", "Acadia", null },
                    { 176, 2020, new DateOnly(2025, 7, 10), "WX-789-YZ", "Red", "Buccaneer", "", 54.5, "Caravan", new DateOnly(2025, 5, 10), "Verhuurbaar", "Barracuda", null },
                    { 177, 2016, new DateOnly(2025, 8, 15), "AB-012-CD", "Green", "Caravelair", "", 47.5, "Caravan", new DateOnly(2025, 6, 15), "Verhuurbaar", "Antares", null },
                    { 178, 2018, new DateOnly(2025, 9, 20), "EF-345-GH", "Black", "Sterckeman", "", 49.0, "Caravan", new DateOnly(2025, 7, 20), "Verhuurbaar", "Evolu-on", null },
                    { 179, 2021, new DateOnly(2025, 10, 5), "IJ-678-KL", "Silver", "Tab", "", 52.0, "Caravan", new DateOnly(2025, 8, 5), "Verhuurbaar", "400", null },
                    { 180, 2020, new DateOnly(2025, 11, 10), "MN-901-OP", "Blue", "Eriba", "", 53.5, "Caravan", new DateOnly(2025, 9, 10), "Verhuurbaar", "Nova", null },
                    { 181, 2019, new DateOnly(2025, 12, 15), "QR-234-ST", "White", "Adria", "", 51.5, "Caravan", new DateOnly(2025, 10, 15), "Verhuurbaar", "Adora", null },
                    { 182, 2022, new DateOnly(2026, 1, 20), "UV-567-WX", "Black", "Fendt", "", 56.0, "Caravan", new DateOnly(2025, 11, 20), "Verhuurbaar", "Opal", null },
                    { 183, 2017, new DateOnly(2026, 2, 5), "YZ-890-AB", "Green", "Knaus", "", 50.5, "Caravan", new DateOnly(2025, 12, 5), "Verhuurbaar", "Sky Traveller", null },
                    { 184, 2018, new DateOnly(2025, 3, 10), "CD-123-EF", "Gray", "Hobby", "", 49.0, "Caravan", new DateOnly(2025, 1, 10), "Verhuurbaar", "Pres-ge", null },
                    { 185, 2020, new DateOnly(2025, 6, 7), "GH-456-IJ", "Blue", "Dethle-s", "", 52.5, "Caravan", new DateOnly(2025, 5, 1), "Verhuurbaar", "C'go", null },
                    { 186, 2017, new DateOnly(2025, 8, 24), "KL-789-MN", "Red", "Burstner", "", 48.0, "Caravan", new DateOnly(2025, 8, 21), "Verhuurbaar", "Premio Life", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0833c56d-8815-4d8b-a223-3ca85a1818c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5471bab0-fd17-448b-9ff4-f0ee36cb5077");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "582d9a19-25fa-4c79-a4e1-0c132a3e959b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84393d42-32f7-4015-978f-289ae49d95c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84da30ee-d97a-479e-bd79-6d2b6b37d10e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ff584b-d59a-4d79-ac34-8960ad850d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e508d6ef-5618-4beb-a060-93059af94820");

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 186);
        }
    }
}
