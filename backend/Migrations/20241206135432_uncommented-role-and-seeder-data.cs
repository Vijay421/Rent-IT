using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class uncommentedroleandseederdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e842695-5861-4445-a901-6c07add332d0", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "310af468-813a-41f0-905b-ef64b9032f77", null, "admin", "ADMIN" },
                    { "46f8ec3a-feee-470d-8bd7-65cf68222903", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "869d14cf-40d8-4fee-9c33-f3fd7a0fc7dc", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "ae7c5c68-5338-448d-be3a-ec8d0ee1ff2e", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "daf826ff-4ba4-4dcc-b920-6d13e843f505", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "Kenteken", "Kleur", "Merk", "Opmerking", "Prijs", "Soort", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 2018, "AB-123-CD", "Red", "Toyota", "", 50.0, "Auto", "Verhuurbaar", "Corolla" },
                    { 2, 2019, "EF-456-GH", "Blue", "Ford", "", 51.390000000000001, "Auto", "Verhuurbaar", "Focus" },
                    { 3, 2020, "IJ-789-KL", "Black", "Volkswagen", "", 40.0, "Auto", "Verhuurbaar", "Golf" },
                    { 4, 2017, "MN-012-OP", "White", "Honda", "", 27.0, "Auto", "Verhuurbaar", "Civic" },
                    { 5, 2021, "QR-345-ST", "Gray", "BMW", "", 64.390000000000001, "Auto", "Verhuurbaar", "3 Series" },
                    { 6, 2016, "UV-678-WX", "Silver", "Audi", "", 21.469999999999999, "Auto", "Verhuurbaar", "A4" },
                    { 7, 2022, "YZ-901-AB", "Blue", "Mercedes", "", 43.5, "Auto", "Verhuurbaar", "C-Class" },
                    { 8, 2015, "CD-234-EF", "Green", "Nissan", "", 98.209999999999994, "Auto", "Verhuurbaar", "Qashqai" },
                    { 9, 2021, "GH-567-IJ", "Red", "Peugeot", "", 51.270000000000003, "Auto", "Verhuurbaar", "208" },
                    { 10, 2018, "KL-890-MN", "Black", "Renault", "", 43.75, "Auto", "Verhuurbaar", "Clio" },
                    { 11, 2017, "OP-123-QR", "White", "Hobby", "", 54.670000000000002, "Auto", "Verhuurbaar", "The Luxury" },
                    { 12, 2018, "ST-456-UV", "Gray", "Fendt", "", 85.310000000000002, "Auto", "Verhuurbaar", "White" },
                    { 13, 2019, "WX-789-YZ", "Blue", "Knaus", "", 65.319999999999993, "Auto", "Verhuurbaar", "Sports" },
                    { 14, 2016, "AB-012-CD", "Green", "Dethle-s", "", 65.0, "Auto", "Verhuurbaar", "Camper" },
                    { 15, 2020, "EF-345-GH", "Silver", "Adria", "", 41.0, "Auto", "Verhuurbaar", "Altea" },
                    { 16, 2015, "IJ-678-KL", "Red", "Eriba", "", 67.120000000000005, "Auto", "Verhuurbaar", "Touring" },
                    { 17, 2021, "MN-901-OP", "Black", "Tabbert", "", 60.0, "Auto", "Verhuurbaar", "Puccini" },
                    { 18, 2019, "QR-234-ST", "White", "Burstner", "", 58.0, "Auto", "Verhuurbaar", "Premio" },
                    { 19, 2018, "UV-567-WX", "Blue", "LMC", "", 55.0, "Auto", "Verhuurbaar", "Music" },
                    { 20, 2022, "YZ-890-AB", "Gray", "Sprite", "", 48.0, "Auto", "Verhuurbaar", "Cruzer" },
                    { 21, 2018, "CD-123-EF", "Red", "Volkswagen", "", 70.0, "Auto", "Verhuurbaar", "California" },
                    { 22, 2019, "GH-456-IJ", "Blue", "Mercedes", "", 85.0, "Auto", "Verhuurbaar", "Marco Polo" },
                    { 23, 2020, "KL-789-MN", "Black", "Ford", "", 72.0, "Auto", "Verhuurbaar", "Nugget" },
                    { 24, 2017, "OP-012-QR", "White", "Fiat", "", 45.0, "Auto", "Verhuurbaar", "Ducato" },
                    { 25, 2021, "ST-345-UV", "Gray", "Lemon", "", 52.0, "Auto", "Verhuurbaar", "Jumper" },
                    { 26, 2016, "WX-678-YZ", "Silver", "Peugeot", "", 47.0, "Auto", "Verhuurbaar", "Boxer" },
                    { 27, 2022, "AB-901-CD", "Blue", "Renault", "", 60.0, "Auto", "Verhuurbaar", "Master" },
                    { 28, 2015, "EF-234-GH", "Green", "Iveco", "", 63.0, "Auto", "Verhuurbaar", "Daily" },
                    { 29, 2021, "IJ-567-KL", "Red", "Opel", "", 58.0, "Auto", "Verhuurbaar", "Movano" },
                    { 30, 2018, "MN-890-OP", "Black", "Nissan", "", 56.0, "Auto", "Verhuurbaar", "NV400" },
                    { 31, 2019, "QR-123-ST", "Silver", "Kia", "", 39.0, "Auto", "Verhuurbaar", "Sportage" },
                    { 32, 2020, "UV-456-WX", "Blue", "Hyundai", "", 42.5, "Auto", "Verhuurbaar", "Tucson" },
                    { 33, 2017, "YZ-789-AB", "Green", "Skoda", "", 37.0, "Auto", "Verhuurbaar", "Octavia" },
                    { 34, 2018, "CD-012-EF", "White", "Mazda", "", 35.75, "Auto", "Verhuurbaar", "3" },
                    { 35, 2021, "GH-345-IJ", "Gray", "Subaru", "", 49.0, "Auto", "Verhuurbaar", "Impreza" },
                    { 36, 2019, "KL-678-MN", "Black", "Suzuki", "", 41.25, "Auto", "Verhuurbaar", "Vitara" },
                    { 37, 2020, "OP-901-QR", "Silver", "Volvo", "", 47.5, "Auto", "Verhuurbaar", "XC60" },
                    { 38, 2017, "ST-234-UV", "Red", "Mitsubishi", "", 40.0, "Auto", "Verhuurbaar", "Outlander" },
                    { 39, 2022, "WX-567-YZ", "Green", "Jeep", "", 75.0, "Auto", "Verhuurbaar", "Wrangler" },
                    { 40, 2021, "YZ-890-AB", "Blue", "Land Rover", "", 68.5, "Auto", "Verhuurbaar", "Defender" },
                    { 41, 2018, "CD-123-EF", "Gray", "Bailey", "", 66.75, "Auto", "Verhuurbaar", "Unicorn" },
                    { 42, 2019, "GH-456-IJ", "Black", "Lunar", "", 62.0, "Auto", "Verhuurbaar", "Clubman" },
                    { 43, 2020, "KL-789-MN", "White", "Swi-", "", 70.5, "Auto", "Verhuurbaar", "Conqueror" },
                    { 44, 2017, "OP-012-QR", "Silver", "Elddis", "", 55.0, "Auto", "Verhuurbaar", "Avante" },
                    { 45, 2021, "ST-345-UV", "Blue", "Compass", "", 74.0, "Auto", "Verhuurbaar", "Casita" },
                    { 46, 2016, "WX-678-YZ", "Green", "Coachman", "", 59.0, "Auto", "Verhuurbaar", "VIP" },
                    { 47, 2022, "AB-901-CD", "Red", "Buccaneer", "", 77.0, "Auto", "Verhuurbaar", "Commodore" },
                    { 48, 2015, "EF-234-GH", "Black", "Caravelair", "", 49.5, "Auto", "Verhuurbaar", "Allegra" },
                    { 49, 2021, "IJ-567-KL", "White", "Sterckeman", "", 63.0, "Auto", "Verhuurbaar", "Starle-" },
                    { 50, 2018, "MN-890-OP", "Gray", "Tab", "", 51.0, "Auto", "Verhuurbaar", "320" },
                    { 51, 2019, "QR-123-ST", "Blue", "Volkswagen", "", 72.5, "Auto", "Verhuurbaar", "Grand California" },
                    { 52, 2020, "UV-456-WX", "Green", "Mercedes", "", 58.5, "Auto", "Verhuurbaar", "Sprinter" },
                    { 53, 2017, "YZ-789-AB", "Red", "Ford", "", 43.5, "Auto", "Verhuurbaar", "Transit Custom" },
                    { 54, 2018, "CD-012-EF", "Black", "Fiat", "", 45.0, "Auto", "Verhuurbaar", "Talento" },
                    { 55, 2021, "GH-345-IJ", "White", "Lemon", "", 50.0, "Auto", "Verhuurbaar", "SpaceTourer" },
                    { 56, 2019, "KL-678-MN", "Gray", "Peugeot", "", 47.0, "Auto", "Verhuurbaar", "Traveller" },
                    { 57, 2020, "OP-901-QR", "Blue", "Renault", "", 49.5, "Auto", "Verhuurbaar", "Tra-c" },
                    { 58, 2017, "ST-234-UV", "Green", "Iveco", "", 52.0, "Auto", "Verhuurbaar", "Daily" },
                    { 59, 2022, "WX-567-YZ", "Red", "Opel", "", 66.0, "Auto", "Verhuurbaar", "Vivaro" },
                    { 60, 2021, "YZ-890-AB", "Black", "Nissan", "", 54.0, "Auto", "Verhuurbaar", "Primastar" },
                    { 61, 2019, "CD-123-EF", "White", "Toyota", "", 37.5, "Auto", "Verhuurbaar", "Yaris" },
                    { 62, 2020, "GH-456-IJ", "Gray", "Ford", "", 41.0, "Auto", "Verhuurbaar", "Kuga" },
                    { 63, 2017, "KL-789-MN", "Blue", "Volkswagen", "", 39.5, "Auto", "Verhuurbaar", "Passat" },
                    { 64, 2018, "OP-012-QR", "Green", "Honda", "", 42.0, "Auto", "Verhuurbaar", "Agreed" },
                    { 65, 2021, "ST-345-UV", "Silver", "BMW", "", 72.5, "Auto", "Verhuurbaar", "X5" },
                    { 66, 2019, "WX-678-YZ", "Black", "Audi", "", 68.0, "Auto", "Verhuurbaar", "Q7" },
                    { 67, 2020, "AB-901-CD", "White", "Mercedes", "", 65.0, "Auto", "Verhuurbaar", "GLC" },
                    { 68, 2017, "EF-234-GH", "Gray", "Nissan", "", 38.0, "Auto", "Verhuurbaar", "Juke" },
                    { 69, 2022, "IJ-567-KL", "Blue", "Peugeot", "", 45.0, "Auto", "Verhuurbaar", "308" },
                    { 70, 2021, "MN-890-OP", "Green", "Renault", "", 43.5, "Auto", "Verhuurbaar", "Megane" },
                    { 71, 2018, "QR-123-ST", "Red", "Tabbert", "", 62.0, "Auto", "Verhuurbaar", "Rossini" },
                    { 72, 2019, "UV-456-WX", "Black", "Dethle-s", "", 64.0, "Auto", "Verhuurbaar", "Beduin" },
                    { 73, 2020, "YZ-789-AB", "White", "Fendt", "", 66.5, "Auto", "Verhuurbaar", "Tendency" },
                    { 74, 2017, "CD-012-EF", "Silver", "Knaus", "", 58.0, "Auto", "Verhuurbaar", "Sudwind" },
                    { 75, 2021, "GH-345-IJ", "Blue", "Hobby", "", 68.0, "Auto", "Verhuurbaar", "Excellent" },
                    { 76, 2016, "KL-678-MN", "Green", "Adria", "", 60.5, "Auto", "Verhuurbaar", "Ac-on" },
                    { 77, 2022, "OP-901-QR", "Red", "Eriba", "", 72.0, "Auto", "Verhuurbaar", "Feeling" },
                    { 78, 2015, "ST-234-UV", "Black", "Burstner", "", 55.0, "Auto", "Verhuurbaar", "Aversely" },
                    { 79, 2021, "WX-567-YZ", "White", "LMC", "", 69.0, "Auto", "Verhuurbaar", "Vivo" },
                    { 80, 2018, "YZ-890-AB", "Gray", "Sprite", "", 52.0, "Auto", "Verhuurbaar", "Major" },
                    { 81, 2019, "CD-123-EF", "Black", "Volkswagen", "", 57.0, "Auto", "Verhuurbaar", "Mul-van" },
                    { 82, 2020, "GH-456-IJ", "White", "Mercedes", "", 63.0, "Auto", "Verhuurbaar", "Vito" },
                    { 83, 2017, "KL-789-MN", "Gray", "Ford", "", 49.5, "Auto", "Verhuurbaar", "Custom" },
                    { 84, 2018, "OP-012-QR", "Blue", "Fiat", "", 51.0, "Auto", "Verhuurbaar", "Scudo" },
                    { 85, 2021, "ST-345-UV", "Green", "Lemon", "", 55.5, "Auto", "Verhuurbaar", "Berlingo" },
                    { 86, 2019, "WX-678-YZ", "Red", "Peugeot", "", 52.5, "Auto", "Verhuurbaar", "Partner" },
                    { 87, 2020, "AB-901-CD", "Black", "Renault", "", 53.0, "Auto", "Verhuurbaar", "Kangoo" },
                    { 88, 2017, "EF-234-GH", "White", "Iveco", "", 59.0, "Auto", "Verhuurbaar", "Eurocargo" },
                    { 89, 2022, "IJ-567-KL", "Gray", "Opel", "", 61.0, "Auto", "Verhuurbaar", "Combo" },
                    { 90, 2021, "MN-890-OP", "Blue", "Nissan", "", 62.5, "Auto", "Verhuurbaar", "NV200" },
                    { 91, 2018, "QR-123-ST", "Green", "Kia", "", 40.0, "Auto", "Verhuurbaar", "Picanto" },
                    { 92, 2019, "UV-456-WX", "Red", "Hyundai", "", 43.5, "Auto", "Verhuurbaar", "i30" },
                    { 93, 2020, "YZ-789-AB", "Black", "Skoda", "", 59.0, "Auto", "Verhuurbaar", "Superb" },
                    { 94, 2017, "CD-012-EF", "White", "Mazda", "", 45.0, "Auto", "Verhuurbaar", "6" },
                    { 95, 2021, "GH-345-IJ", "Gray", "Subaru", "", 58.5, "Auto", "Verhuurbaar", "Forester" },
                    { 96, 2019, "KL-678-MN", "Silver", "Suzuki", "", 42.0, "Auto", "Verhuurbaar", "Swift" },
                    { 97, 2020, "OP-901-QR", "Blue", "Volvo", "", 65.0, "Auto", "Verhuurbaar", "XC90" },
                    { 98, 2017, "ST-234-UV", "Green", "Mitsubishi", "", 47.0, "Auto", "Verhuurbaar", "ASX" },
                    { 99, 2022, "WX-567-YZ", "Red", "Jeep", "", 70.0, "Auto", "Verhuurbaar", "Cherokee" },
                    { 100, 2021, "YZ-890-AB", "Blue", "Land Rover", "", 73.0, "Auto", "Verhuurbaar", "Discovery" },
                    { 101, 2018, "AB-123-CD", "Red", "Volkswagen", "", 69.0, "Camper", "Verhuurbaar", "California" },
                    { 102, 2019, "EF-456-GH", "Silver", "Mercedes", "", 72.0, "Camper", "Verhuurbaar", "Marco Polo" },
                    { 103, 2020, "IJ-789-KL", "Blue", "Ford", "", 66.0, "Camper", "Verhuurbaar", "Transit Custom" },
                    { 104, 2017, "MN-012-OP", "White", "Fiat", "", 61.0, "Camper", "Verhuurbaar", "Ducato" },
                    { 105, 2021, "QR-345-ST", "Gray", "Citroën", "", 65.0, "Camper", "Verhuurbaar", "Jumper" },
                    { 106, 2016, "UV-678-WX", "Black", "Peugeot", "", 68.0, "Camper", "Verhuurbaar", "Boxer" },
                    { 107, 2022, "YZ-901-AB", "Green", "Renault", "", 74.0, "Camper", "Verhuurbaar", "Master" },
                    { 108, 2015, "CD-234-EF", "Blue", "Nissan", "", 62.5, "Camper", "Verhuurbaar", "NV400" },
                    { 109, 2021, "GH-567-IJ", "Silver", "Opel", "", 67.0, "Camper", "Verhuurbaar", "Movano" },
                    { 110, 2018, "KL-890-MN", "Red", "Iveco", "", 63.5, "Camper", "Verhuurbaar", "Daily" },
                    { 111, 2017, "OP-123-QR", "White", "Volkswagen", "", 70.0, "Camper", "Verhuurbaar", "Grand California" },
                    { 112, 2019, "ST-456-UV", "Blue", "Mercedes", "", 72.5, "Camper", "Verhuurbaar", "Sprinter" },
                    { 113, 2020, "WX-789-YZ", "Black", "Ford", "", 75.0, "Camper", "Verhuurbaar", "Nugget" },
                    { 114, 2016, "AB-012-CD", "Green", "Fiat", "", 61.0, "Camper", "Verhuurbaar", "Talento" },
                    { 115, 2018, "EF-345-GH", "Red", "Citroën", "", 66.0, "Camper", "Verhuurbaar", "SpaceTourer" },
                    { 116, 2021, "IJ-678-KL", "Black", "Peugeot", "", 69.0, "Camper", "Verhuurbaar", "Traveller" },
                    { 117, 2020, "MN-901-OP", "White", "Renault", "", 68.5, "Camper", "Verhuurbaar", "Tra-c" },
                    { 118, 2019, "QR-234-ST", "Silver", "Nissan", "", 62.5, "Camper", "Verhuurbaar", "Primastar" },
                    { 119, 2022, "UV-567-WX", "Gray", "Opel", "", 70.0, "Camper", "Verhuurbaar", "Vivaro" },
                    { 120, 2017, "YZ-890-AB", "Black", "Iveco", "", 65.0, "Camper", "Verhuurbaar", "Eurocargo" },
                    { 121, 2018, "CD-123-EF", "Blue", "Volkswagen", "", 60.0, "Camper", "Verhuurbaar", "Mul-van" },
                    { 122, 2020, "GH-456-IJ", "Green", "Mercedes", "", 64.0, "Camper", "Verhuurbaar", "Vito" },
                    { 123, 2017, "KL-789-MN", "Silver", "Ford", "", 58.5, "Camper", "Verhuurbaar", "Kuga Camper" },
                    { 124, 2018, "OP-012-QR", "Red", "Fiat", "", 62.0, "Camper", "Verhuurbaar", "Scudo" },
                    { 125, 2019, "ST-345-UV", "White", "Citroën", "", 57.5, "Camper", "Verhuurbaar", "Berlingo" },
                    { 126, 2016, "WX-678-YZ", "Gray", "Peugeot", "", 66.0, "Camper", "Verhuurbaar", "Expert Camper" },
                    { 127, 2022, "AB-901-CD", "Blue", "Renault", "", 70.5, "Camper", "Verhuurbaar", "Kangoo Camper" },
                    { 128, 2015, "EF-234-GH", "Black", "Nissan", "", 61.0, "Camper", "Verhuurbaar", "Juke Camper" },
                    { 129, 2021, "GH-567-IJ", "Green", "Opel", "", 65.0, "Camper", "Verhuurbaar", "Za-ra Camper" },
                    { 130, 2018, "KL-890-MN", "Red", "Iveco", "", 63.5, "Camper", "Verhuurbaar", "Camper 2000" },
                    { 131, 2017, "OP-123-QR", "Black", "Volkswagen", "", 60.0, "Camper", "Verhuurbaar", "Combi" },
                    { 132, 2021, "ST-456-UV", "Silver", "Mercedes", "", 75.0, "Camper", "Verhuurbaar", "Sprinter XXL" },
                    { 133, 2020, "WX-789-YZ", "Blue", "Ford", "", 72.5, "Camper", "Verhuurbaar", "Custom Camper" },
                    { 134, 2016, "AB-012-CD", "White", "Fiat", "", 61.5, "Camper", "Verhuurbaar", "Ducato Maxi" },
                    { 135, 2018, "EF-345-GH", "Green", "Citroën", "", 62.5, "Camper", "Verhuurbaar", "Jumper Camper" },
                    { 136, 2021, "IJ-678-KL", "Black", "Peugeot", "", 69.5, "Camper", "Verhuurbaar", "Boxer XL" },
                    { 137, 2019, "MN-901-OP", "Gray", "Renault", "", 67.0, "Camper", "Verhuurbaar", "Master Pro" },
                    { 138, 2022, "QR-234-ST", "Blue", "Nissan", "", 74.0, "Camper", "Verhuurbaar", "NV300 Camper" },
                    { 139, 2017, "UV-567-WX", "Silver", "Opel", "", 65.0, "Camper", "Verhuurbaar", "Vivaro XL" },
                    { 140, 2018, "YZ-890-AB", "Red", "Iveco", "", 66.5, "Camper", "Verhuurbaar", "Daily Pro" },
                    { 141, 2020, "CD-123-EF", "Green", "Volkswagen", "", 72.5, "Camper", "Verhuurbaar", "T6 California" },
                    { 142, 2019, "GH-456-IJ", "Black", "Mercedes", "", 75.0, "Camper", "Verhuurbaar", "V-Class Camper" },
                    { 143, 2022, "KL-789-MN", "White", "Ford", "", 76.0, "Camper", "Verhuurbaar", "Transit Nugget Plus" },
                    { 144, 2018, "AB-123-CD", "White", "Hobby", "", 48.0, "Caravan", "Verhuurbaar", "The Luxury" },
                    { 145, 2019, "EF-456-GH", "Gray", "Fendt", "", 50.0, "Caravan", "Verhuurbaar", "White" },
                    { 146, 2020, "IJ-789-KL", "Black", "Knaus", "", 51.0, "Caravan", "Verhuurbaar", "Camper" },
                    { 147, 2021, "MN-012-OP", "Blue", "Adria", "", 52.5, "Caravan", "Verhuurbaar", "Adria Home" },
                    { 148, 2022, "QR-345-ST", "Green", "Tabbert", "", 54.0, "Caravan", "Verhuurbaar", "Stylish" },
                    { 149, 2023, "UV-678-WX", "Red", "Hobby", "", 55.0, "Caravan", "Verhuurbaar", "Comfort" },
                    { 150, 2023, "YZ-901-AB", "Silver", "Fendt", "", 58.0, "Caravan", "Verhuurbaar", "Luxury" },
                    { 151, 2015, "CD-234-EF", "Blue", "LMC", "", 45.0, "Caravan", "Verhuurbaar", "Music" },
                    { 152, 2021, "GH-567-IJ", "Red", "Sprite", "", 48.0, "Caravan", "Verhuurbaar", "Cruzer" },
                    { 153, 2018, "KL-890-MN", "Gray", "Bailey", "", 47.5, "Caravan", "Verhuurbaar", "Unicorn" },
                    { 154, 2017, "OP-123-QR", "Silver", "Lunar", "", 46.0, "Caravan", "Verhuurbaar", "Clubman" },
                    { 155, 2019, "ST-456-UV", "Blue", "Swi-", "", 49.0, "Caravan", "Verhuurbaar", "Conqueror" },
                    { 156, 2020, "WX-789-YZ", "Green", "Compass", "", 50.0, "Caravan", "Verhuurbaar", "Casita" },
                    { 157, 2016, "AB-012-CD", "Red", "Coachman", "", 46.5, "Caravan", "Verhuurbaar", "VIP" },
                    { 158, 2018, "EF-345-GH", "Black", "Buccaneer", "", 51.0, "Caravan", "Verhuurbaar", "Commodore" },
                    { 159, 2021, "IJ-678-KL", "White", "Caravelair", "", 52.0, "Caravan", "Verhuurbaar", "Allegra" },
                    { 160, 2020, "MN-901-OP", "Silver", "Sterckeman", "", 53.0, "Caravan", "Verhuurbaar", "Starle-" },
                    { 161, 2019, "QR-234-ST", "Blue", "Tab", "", 48.5, "Caravan", "Verhuurbaar", "320" },
                    { 162, 2022, "UV-567-WX", "Gray", "Eriba", "", 55.0, "Caravan", "Verhuurbaar", "Touring" },
                    { 163, 2017, "YZ-890-AB", "Red", "Adria", "", 47.0, "Caravan", "Verhuurbaar", "Ac-on" },
                    { 164, 2018, "CD-123-EF", "White", "Fendt", "", 49.5, "Caravan", "Verhuurbaar", "Tendency" },
                    { 165, 2020, "GH-456-IJ", "Green", "Knaus", "", 52.5, "Caravan", "Verhuurbaar", "Sudwind" },
                    { 166, 2017, "KL-789-MN", "Black", "Hobby", "", 51.0, "Caravan", "Verhuurbaar", "Excellent" },
                    { 167, 2019, "OP-012-QR", "Blue", "Dethle-s", "", 50.0, "Caravan", "Verhuurbaar", "Beduin" },
                    { 168, 2021, "ST-345-UV", "Silver", "Burstner", "", 54.0, "Caravan", "Verhuurbaar", "Aversely" },
                    { 169, 2020, "WX-678-YZ", "Red", "LMC", "", 49.0, "Caravan", "Verhuurbaar", "Vivo" },
                    { 170, 2019, "AB-901-CD", "Green", "Sprite", "", 48.0, "Caravan", "Verhuurbaar", "Major" },
                    { 171, 2022, "EF-234-GH", "White", "Bailey", "", 55.0, "Caravan", "Verhuurbaar", "Phoenix" },
                    { 172, 2017, "GH-567-IJ", "Gray", "Lunar", "", 46.0, "Caravan", "Verhuurbaar", "Delta" },
                    { 173, 2018, "KL-890-MN", "Black", "Swi-", "", 49.5, "Caravan", "Verhuurbaar", "Elegance" },
                    { 174, 2021, "OP-123-QR", "Blue", "Compass", "", 51.0, "Caravan", "Verhuurbaar", "Corona" },
                    { 175, 2019, "ST-456-UV", "Silver", "Coachman", "", 53.0, "Caravan", "Verhuurbaar", "Acadia" },
                    { 176, 2020, "WX-789-YZ", "Red", "Buccaneer", "", 54.5, "Caravan", "Verhuurbaar", "Barracuda" },
                    { 177, 2016, "AB-012-CD", "Green", "Caravelair", "", 47.5, "Caravan", "Verhuurbaar", "Antares" },
                    { 178, 2018, "EF-345-GH", "Black", "Sterckeman", "", 49.0, "Caravan", "Verhuurbaar", "Evolu-on" },
                    { 179, 2021, "IJ-678-KL", "Silver", "Tab", "", 52.0, "Caravan", "Verhuurbaar", "400" },
                    { 180, 2020, "MN-901-OP", "Blue", "Eriba", "", 53.5, "Caravan", "Verhuurbaar", "Nova" },
                    { 181, 2019, "QR-234-ST", "White", "Adria", "", 51.5, "Caravan", "Verhuurbaar", "Adora" },
                    { 182, 2022, "UV-567-WX", "Black", "Fendt", "", 56.0, "Caravan", "Verhuurbaar", "Opal" },
                    { 183, 2017, "YZ-890-AB", "Green", "Knaus", "", 50.5, "Caravan", "Verhuurbaar", "Sky Traveller" },
                    { 184, 2018, "CD-123-EF", "Gray", "Hobby", "", 49.0, "Caravan", "Verhuurbaar", "Pres-ge" },
                    { 185, 2020, "GH-456-IJ", "Blue", "Dethle-s", "", 52.5, "Caravan", "Verhuurbaar", "C'go" },
                    { 186, 2017, "KL-789-MN", "Red", "Burstner", "", 48.0, "Caravan", "Verhuurbaar", "Premio Life" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e842695-5861-4445-a901-6c07add332d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310af468-813a-41f0-905b-ef64b9032f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f8ec3a-feee-470d-8bd7-65cf68222903");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "869d14cf-40d8-4fee-9c33-f3fd7a0fc7dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7c5c68-5338-448d-be3a-ec8d0ee1ff2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf826ff-4ba4-4dcc-b920-6d13e843f505");

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
