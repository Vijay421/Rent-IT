using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class createdvoertuigdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2de163ac-d38e-4bdd-9a65-8f34810dd084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e651aa-fbe0-4e34-9677-511d8d0788d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72127a9e-7d62-4bb8-8f53-c61226e6ee3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c993550f-9a1f-4c18-8c80-98ace06abf18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e54b5a49-73f1-466a-b6f1-bbaca6a62b3b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

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
                    Aanschafjaar = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Soort = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd528a1-17a1-47cc-afe8-463def6bf1f7", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "6e8e4617-13f3-4d5a-9dba-b627bf7f6bde", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "9862ee43-a40b-48b6-acf2-aef39e4775de", null, "admin", "ADMIN" },
                    { "ae9e3d91-59a2-4e6c-8a41-9acace7ad820", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "ca45e2b3-891b-4a99-a5c4-a7e862b4d2a0", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Merk", "Type", "Kenteken", "Kleur", "Aanschafjaar", "Opmerking", "Soort", "Status" },
                values: new object[,]
                {
                    {1, "Toyota", "Corolla", "AB-123-CD", "Red", 2018, "Auto", "", "Verhuurbaar"},
                    {2, "Ford", "Focus", "EF-456-GH", "Blue", 2019, "Auto", "", "Verhuurbaar"},
                    {3, "Volkswagen", "Golf", "IJ-789-KL", "Black", 2020, "Auto", "", "Verhuurbaar"},
                    {4, "Honda", "Civic", "MN-012-OP", "White", 2017, "Auto", "", "Verhuurbaar"},
                    {5, "BMW", "3 Series", "QR-345-ST", "Gray", 2021, "Auto", "", "Verhuurbaar"},
                    {6, "Audi", "A4", "UV-678-WX", "Silver", 2016, "Auto", "", "Verhuurbaar"},
                    {7, "Mercedes", "C-Class", "YZ-901-AB", "Blue", 2022, "Auto", "", "Verhuurbaar"},
                    {8, "Nissan", "Qashqai", "CD-234-EF", "Green", 2015, "Auto", "", "Verhuurbaar"},
                    {9, "Peugeot", "208", "GH-567-IJ", "Red", 2021, "Auto", "", "Verhuurbaar"},
                    {10, "Renault", "Clio", "KL-890-MN", "Black", 2018, "Auto", "", "Verhuurbaar"},
                    {11, "Hobby", "The Luxury", "OP-123-QR", "White", 2017, "Auto", "", "Verhuurbaar"},
                    {12, "Fendt", "White", "ST-456-UV", "Gray", 2018, "Auto", "", "Verhuurbaar"},
                    {13, "Knaus", "Sports", "WX-789-YZ", "Blue", 2019, "Auto", "", "Verhuurbaar"},
                    {14, "Dethle-s", "Camper", "AB-012-CD", "Green", 2016, "Auto", "", "Verhuurbaar"},
                    {15, "Adria", "Altea", "EF-345-GH", "Silver", 2020, "Auto", "", "Verhuurbaar"},
                    {16, "Eriba", "Touring", "IJ-678-KL", "Red", 2015, "Auto", "", "Verhuurbaar"},
                    {17, "Tabbert", "Puccini", "MN-901-OP", "Black", 2021, "Auto", "", "Verhuurbaar"},
                    {18, "Burstner", "Premio", "QR-234-ST", "White", 2019, "Auto", "", "Verhuurbaar"},
                    {19, "LMC", "Music", "UV-567-WX", "Blue", 2018, "Auto", "", "Verhuurbaar"},
                    {20, "Sprite", "Cruzer", "YZ-890-AB", "Gray", 2022, "Auto", "", "Verhuurbaar"},
                    {21, "Volkswagen", "California", "CD-123-EF", "Red", 2018, "Auto", "", "Verhuurbaar"},
                    {22, "Mercedes", "Marco Polo", "GH-456-IJ", "Blue", 2019, "Auto", "", "Verhuurbaar"},
                    {23, "Ford", "Nugget", "KL-789-MN", "Black", 2020, "Auto", "", "Verhuurbaar"},
                    {24, "Fiat", "Ducato", "OP-012-QR", "White", 2017, "Auto", "", "Verhuurbaar"},
                    {25, "Lemon", "Jumper", "ST-345-UV", "Gray", 2021, "Auto", "", "Verhuurbaar"},
                    {26, "Peugeot", "Boxer", "WX-678-YZ", "Silver", 2016, "Auto", "", "Verhuurbaar"},
                    {27, "Renault", "Master", "AB-901-CD", "Blue", 2022, "Auto", "", "Verhuurbaar"},
                    {28, "Iveco", "Daily", "EF-234-GH", "Green", 2015, "Auto", "", "Verhuurbaar"},
                    {29, "Opel", "Movano", "IJ-567-KL", "Red", 2021, "Auto", "", "Verhuurbaar"},
                    {30, "Nissan", "NV400", "MN-890-OP", "Black", 2018, "Auto", "", "Verhuurbaar"},
                    {31, "Kia", "Sportage", "QR-123-ST", "Silver", 2019, "Auto", "", "Verhuurbaar"},
                    {32, "Hyundai", "Tucson", "UV-456-WX", "Blue", 2020, "Auto", "", "Verhuurbaar"},
                    {33, "Skoda", "Octavia", "YZ-789-AB", "Green", 2017, "Auto", "", "Verhuurbaar"},
                    {34, "Mazda", "3", "CD-012-EF", "White", 2018, "Auto", "", "Verhuurbaar"},
                    {35, "Subaru", "Impreza", "GH-345-IJ", "Gray", 2021, "Auto", "", "Verhuurbaar"},
                    {36, "Suzuki", "Vitara", "KL-678-MN", "Black", 2019, "Auto", "", "Verhuurbaar"},
                    {37, "Volvo", "XC60", "OP-901-QR", "Silver", 2020, "Auto", "", "Verhuurbaar"},
                    {38, "Mitsubishi", "Outlander", "ST-234-UV", "Red", 2017, "Auto", "", "Verhuurbaar"},
                    {39, "Jeep", "Wrangler", "WX-567-YZ", "Green", 2022, "Auto", "", "Verhuurbaar"},
                    {40, "Land Rover", "Defender", "YZ-890-AB", "Blue", 2021, "Auto", "", "Verhuurbaar"},
                    {41, "Bailey", "Unicorn", "CD-123-EF", "Gray", 2018, "Auto", "", "Verhuurbaar"},
                    {42, "Lunar", "Clubman", "GH-456-IJ", "Black", 2019, "Auto", "", "Verhuurbaar"},
                    {43, "Swi-", "Conqueror", "KL-789-MN", "White", 2020, "Auto", "", "Verhuurbaar"},
                    {44, "Elddis", "Avante", "OP-012-QR", "Silver", 2017, "Auto", "", "Verhuurbaar"},
                    {45, "Compass", "Casita", "ST-345-UV", "Blue", 2021, "Auto", "", "Verhuurbaar"},
                    {46, "Coachman", "VIP", "WX-678-YZ", "Green", 2016, "Auto", "", "Verhuurbaar"},
                    {47, "Buccaneer", "Commodore", "AB-901-CD", "Red", 2022, "Auto", "", "Verhuurbaar"},
                    {48, "Caravelair", "Allegra", "EF-234-GH", "Black", 2015, "Auto", "", "Verhuurbaar"},
                    {49, "Sterckeman", "Starle-", "IJ-567-KL", "White", 2021, "Auto", "", "Verhuurbaar"},
                    {50, "Tab", "320", "MN-890-OP", "Gray", 2018, "Auto", "", "Verhuurbaar"},
                    {51, "Volkswagen", "Grand California", "QR-123-ST", "Blue", 2019, "Auto", "", "Verhuurbaar"},
                    {52, "Mercedes", "Sprinter", "UV-456-WX", "Green", 2020, "Auto", "", "Verhuurbaar"},
                    {53, "Ford", "Transit Custom", "YZ-789-AB", "Red", 2017, "Auto", "", "Verhuurbaar"},
                    {54, "Fiat", "Talento", "CD-012-EF", "Black", 2018, "Auto", "", "Verhuurbaar"},
                    {55, "Lemon", "SpaceTourer", "GH-345-IJ", "White", 2021, "Auto", "", "Verhuurbaar"},
                    {56, "Peugeot", "Traveller", "KL-678-MN", "Gray", 2019, "Auto", "", "Verhuurbaar"},
                    {57, "Renault", "Tra-c", "OP-901-QR", "Blue", 2020, "Auto", "", "Verhuurbaar"},
                    {58, "Iveco", "Daily", "ST-234-UV", "Green", 2017, "Auto", "", "Verhuurbaar"},
                    {59, "Opel", "Vivaro", "WX-567-YZ", "Red", 2022, "Auto", "", "Verhuurbaar"},
                    {60, "Nissan", "Primastar", "YZ-890-AB", "Black", 2021, "Auto", "", "Verhuurbaar"},
                    {61, "Toyota", "Yaris", "CD-123-EF", "White", 2019, "Auto", "", "Verhuurbaar"},
                    {62, "Ford", "Kuga", "GH-456-IJ", "Gray", 2020, "Auto", "", "Verhuurbaar"},
                    {63, "Volkswagen", "Passat", "KL-789-MN", "Blue", 2017, "Auto", "", "Verhuurbaar"},
                    {64, "Honda", "Agreed", "OP-012-QR", "Green", 2018, "Auto", "", "Verhuurbaar"},
                    {65, "BMW", "X5", "ST-345-UV", "Silver", 2021, "Auto", "", "Verhuurbaar"},
                    {66, "Audi", "Q7", "WX-678-YZ", "Black", 2019, "Auto", "", "Verhuurbaar"},
                    {67, "Mercedes", "GLC", "AB-901-CD", "White", 2020, "Auto", "", "Verhuurbaar"},
                    {68, "Nissan", "Juke", "EF-234-GH", "Gray", 2017, "Auto", "", "Verhuurbaar"},
                    {69, "Peugeot", "308", "IJ-567-KL", "Blue", 2022, "Auto", "", "Verhuurbaar"},
                    {70, "Renault", "Megane", "MN-890-OP", "Green", 2021, "Auto", "", "Verhuurbaar"},
                    {71, "Tabbert", "Rossini", "QR-123-ST", "Red", 2018, "Auto", "", "Verhuurbaar"},
                    {72, "Dethle-s", "Beduin", "UV-456-WX", "Black", 2019, "Auto", "", "Verhuurbaar"},
                    {73, "Fendt", "Tendency", "YZ-789-AB", "White", 2020, "Auto", "", "Verhuurbaar"},
                    {74, "Knaus", "Sudwind", "CD-012-EF", "Silver", 2017, "Auto", "", "Verhuurbaar"},
                    {75, "Hobby", "Excellent", "GH-345-IJ", "Blue", 2021, "Auto", "", "Verhuurbaar"},
                    {76, "Adria", "Ac-on", "KL-678-MN", "Green", 2016, "Auto", "", "Verhuurbaar"},
                    {77, "Eriba", "Feeling", "OP-901-QR", "Red", 2022, "Auto", "", "Verhuurbaar"},
                    {78, "Burstner", "Aversely", "ST-234-UV", "Black", 2015, "Auto", "", "Verhuurbaar"},
                    {79, "LMC", "Vivo", "WX-567-YZ", "White", 2021, "Auto", "", "Verhuurbaar"},
                    {80, "Sprite", "Major", "YZ-890-AB", "Gray", 2018, "Auto", "", "Verhuurbaar"},
                    {81, "Volkswagen", "Mul-van", "CD-123-EF", "Black", 2019, "Auto", "", "Verhuurbaar"},
                    {82, "Mercedes", "Vito", "GH-456-IJ", "White", 2020, "Auto", "", "Verhuurbaar"},
                    {83, "Ford", "Custom", "KL-789-MN", "Gray", 2017, "Auto", "", "Verhuurbaar"},
                    {84, "Fiat", "Scudo", "OP-012-QR", "Blue", 2018, "Auto", "", "Verhuurbaar"},
                    {85, "Lemon", "Berlingo", "ST-345-UV", "Green", 2021, "Auto", "", "Verhuurbaar"},
                    {86, "Peugeot", "Partner", "WX-678-YZ", "Red", 2019, "Auto", "", "Verhuurbaar"},
                    {87, "Renault", "Kangoo", "AB-901-CD", "Black", 2020, "Auto", "", "Verhuurbaar"},
                    {88, "Iveco", "Eurocargo", "EF-234-GH", "White", 2017, "Auto", "", "Verhuurbaar"},
                    {89, "Opel", "Combo", "IJ-567-KL", "Gray", 2022, "Auto", "", "Verhuurbaar"},
                    {90, "Nissan", "NV200", "MN-890-OP", "Blue", 2021, "Auto", "", "Verhuurbaar"},
                    {91, "Kia", "Picanto", "QR-123-ST", "Green", 2018, "Auto", "", "Verhuurbaar"},
                    {92, "Hyundai", "i30", "UV-456-WX", "Red", 2019, "Auto", "", "Verhuurbaar"},
                    {93, "Skoda", "Superb", "YZ-789-AB", "Black", 2020, "Auto", "", "Verhuurbaar"},
                    {94, "Mazda", "6", "CD-012-EF", "White", 2017, "Auto", "", "Verhuurbaar"},
                    {95, "Subaru", "Forester", "GH-345-IJ", "Gray", 2021, "Auto", "", "Verhuurbaar"},
                    {96, "Suzuki", "Swift", "KL-678-MN", "Silver", 2019, "Auto", "", "Verhuurbaar"},
                    {97, "Volvo", "XC90", "OP-901-QR", "Blue", 2020, "Auto", "", "Verhuurbaar"},
                    {98, "Mitsubishi", "ASX", "ST-234-UV", "Green", 2017, "Auto", "", "Verhuurbaar"},
                    {99, "Jeep", "Cherokee", "WX-567-YZ", "Red", 2022, "Auto", "", "Verhuurbaar"},
                    {100, "Land Rover", "Discovery", "YZ-890-AB", "Blue", 2021, "Auto", "", "Verhuurbaar"},
                    {101, "Volkswagen", "California", "AB-123-CD", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {102, "Mercedes", "Marco Polo", "EF-456-GH", "Silver", 2019, "Camper", "", "Verhuurbaar"},
                    {103, "Ford", "Transit Custom", "IJ-789-KL", "Blue", 2020, "Camper", "", "Verhuurbaar"},
                    {104, "Fiat", "Ducato", "MN-012-OP", "White", 2017, "Camper", "", "Verhuurbaar"},
                    {105, "Citroën", "Jumper", "QR-345-ST", "Gray", 2021, "Camper", "", "Verhuurbaar"},
                    {106, "Peugeot", "Boxer", "UV-678-WX", "Black", 2016, "Camper", "", "Verhuurbaar"},
                    {107, "Renault", "Master", "YZ-901-AB", "Green", 2022, "Camper", "", "Verhuurbaar"},
                    {108, "Nissan", "NV400", "CD-234-EF", "Blue", 2015, "Camper", "", "Verhuurbaar"},
                    {109, "Opel", "Movano", "GH-567-IJ", "Silver", 2021, "Camper", "", "Verhuurbaar"},
                    {110, "Iveco", "Daily", "KL-890-MN", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {111, "Volkswagen", "Grand California", "OP-123-QR", "White", 2017, "Camper", "", "Verhuurbaar"},
                    {112, "Mercedes", "Sprinter", "ST-456-UV", "Blue", 2019, "Camper", "", "Verhuurbaar"},
                    {113, "Ford", "Nugget", "WX-789-YZ", "Black", 2020, "Camper", "", "Verhuurbaar"},
                    {114, "Fiat", "Talento", "AB-012-CD", "Green", 2016, "Camper", "", "Verhuurbaar"},
                    {115, "Citroën", "SpaceTourer", "EF-345-GH", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {116, "Peugeot", "Traveller", "IJ-678-KL", "Black", 2021, "Camper", "", "Verhuurbaar"},
                    {117, "Renault", "Tra-c", "MN-901-OP", "White", 2020, "Camper", "", "Verhuurbaar"},
                    {118, "Nissan", "Primastar", "QR-234-ST", "Silver", 2019, "Camper", "", "Verhuurbaar"},
                    {119, "Opel", "Vivaro", "UV-567-WX", "Gray", 2022, "Camper", "", "Verhuurbaar"},
                    {120, "Iveco", "Eurocargo", "YZ-890-AB", "Black", 2017, "Camper", "", "Verhuurbaar"},
                    {121, "Volkswagen", "Mul-van", "CD-123-EF", "Blue", 2018, "Camper", "", "Verhuurbaar"},
                    {122, "Mercedes", "Vito", "GH-456-IJ", "Green", 2020, "Camper", "", "Verhuurbaar"},
                    {123, "Ford", "Kuga Camper", "KL-789-MN", "Silver", 2017, "Camper", "", "Verhuurbaar"},
                    {124, "Fiat", "Scudo", "OP-012-QR", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {125, "Citroën", "Berlingo", "ST-345-UV", "White", 2019, "Camper", "", "Verhuurbaar"},
                    {126, "Peugeot", "Expert Camper", "WX-678-YZ", "Gray", 2016, "Camper", "", "Verhuurbaar"},
                    {127, "Renault", "Kangoo Camper", "AB-901-CD", "Blue", 2022, "Camper", "", "Verhuurbaar"},
                    {128, "Nissan", "Juke Camper", "EF-234-GH", "Black", 2015, "Camper", "", "Verhuurbaar"},
                    {129, "Opel", "Za-ra Camper", "GH-567-IJ", "Green", 2021, "Camper", "", "Verhuurbaar"},
                    {130, "Iveco", "Camper 2000", "KL-890-MN", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {131, "Volkswagen", "Combi", "OP-123-QR", "Black", 2017, "Camper", "", "Verhuurbaar"},
                    {132, "Mercedes", "Sprinter XXL", "ST-456-UV", "Silver", 2021, "Camper", "", "Verhuurbaar"},
                    {133, "Ford", "Custom Camper", "WX-789-YZ", "Blue", 2020, "Camper", "", "Verhuurbaar"},
                    {134, "Fiat", "Ducato Maxi", "AB-012-CD", "White", 2016, "Camper", "", "Verhuurbaar"},
                    {135, "Citroën", "Jumper Camper", "EF-345-GH", "Green", 2018, "Camper", "", "Verhuurbaar"},
                    {136, "Peugeot", "Boxer XL", "IJ-678-KL", "Black", 2021, "Camper", "", "Verhuurbaar"},
                    {137, "Renault", "Master Pro", "MN-901-OP", "Gray", 2019, "Camper", "", "Verhuurbaar"},
                    {138, "Nissan", "NV300 Camper", "QR-234-ST", "Blue", 2022, "Camper", "", "Verhuurbaar"},
                    {139, "Opel", "Vivaro XL", "UV-567-WX", "Silver", 2017, "Camper", "", "Verhuurbaar"},
                    {140, "Iveco", "Daily Pro", "YZ-890-AB", "Red", 2018, "Camper", "", "Verhuurbaar"},
                    {141, "Volkswagen", "T6 California", "CD-123-EF", "Green", 2020, "Camper", "", "Verhuurbaar"},
                    {142, "Mercedes", "V-Class Camper", "GH-456-IJ", "Black", 2019, "Camper", "", "Verhuurbaar"},
                    {143, "Ford", "Transit Nugget Plus", "KL-789-MN", "White", 2022, "Camper", "", "Verhuurbaar"},
                    {144, "Hobby", "The Luxury", "AB-123-CD", "White", 2018, "Caravan", "", "Verhuurbaar"},
                    {145, "Fendt", "White", "EF-456-GH", "Gray", 2019, "Caravan", "", "Verhuurbaar"},
                    {146, "Knaus", "Sports", "IJ-789-KL", "Blue", 2020, "Caravan", "", "Verhuurbaar"},
                    {147, "Adria", "Altea", "MN-012-OP", "Silver", 2017, "Caravan", "", "Verhuurbaar"},
                    {148, "Dethle-s", "Camper", "QR-345-ST", "Green", 2021, "Caravan", "", "Verhuurbaar"},
                    {149, "Tabbert", "Puccini", "UV-678-WX", "Black", 2016, "Caravan", "", "Verhuurbaar"},
                    {150, "Burstner", "Premio", "YZ-901-AB", "White", 2022, "Caravan", "", "Verhuurbaar"},
                    {151, "LMC", "Music", "CD-234-EF", "Blue", 2015, "Caravan", "", "Verhuurbaar"},
                    {152, "Sprite", "Cruzer", "GH-567-IJ", "Red", 2021, "Caravan", "", "Verhuurbaar"},
                    {153, "Bailey", "Unicorn", "KL-890-MN", "Gray", 2018, "Caravan", "", "Verhuurbaar"},
                    {154, "Lunar", "Clubman", "OP-123-QR", "Silver", 2017, "Caravan", "", "Verhuurbaar"},
                    {155, "Swi-", "Conqueror", "ST-456-UV", "Blue", 2019, "Caravan", "", "Verhuurbaar"},
                    {156, "Compass", "Casita", "WX-789-YZ", "Green", 2020, "Caravan", "", "Verhuurbaar"},
                    {157, "Coachman", "VIP", "AB-012-CD", "Red", 2016, "Caravan", "", "Verhuurbaar"},
                    {158, "Buccaneer", "Commodore", "EF-345-GH", "Black", 2018, "Caravan", "", "Verhuurbaar"},
                    {159, "Caravelair", "Allegra", "IJ-678-KL", "White", 2021, "Caravan", "", "Verhuurbaar"},
                    {160, "Sterckeman", "Starle-", "MN-901-OP", "Silver", 2020, "Caravan", "", "Verhuurbaar"},
                    {161, "Tab", "320", "QR-234-ST", "Blue", 2019, "Caravan", "", "Verhuurbaar"},
                    {162, "Eriba", "Touring", "UV-567-WX", "Gray", 2022, "Caravan", "", "Verhuurbaar"},
                    {163, "Adria", "Ac-on", "YZ-890-AB", "Red", 2017, "Caravan", "", "Verhuurbaar"},
                    {164, "Fendt", "Tendency", "CD-123-EF", "White", 2018, "Caravan", "", "Verhuurbaar"},
                    {165, "Knaus", "Sudwind", "GH-456-IJ", "Green", 2020, "Caravan", "", "Verhuurbaar"},
                    {166, "Hobby", "Excellent", "KL-789-MN", "Black", 2017, "Caravan", "", "Verhuurbaar"},
                    {167, "Dethle-s", "Beduin", "OP-012-QR", "Blue", 2019, "Caravan", "", "Verhuurbaar"},
                    {168, "Burstner", "Aversely", "ST-345-UV", "Silver", 2021, "Caravan", "", "Verhuurbaar"},
                    {169, "LMC", "Vivo", "WX-678-YZ", "Red", 2020, "Caravan", "", "Verhuurbaar"},
                    {170, "Sprite", "Major", "AB-901-CD", "Green", 2019, "Caravan", "", "Verhuurbaar"},
                    {171, "Bailey", "Phoenix", "EF-234-GH", "White", 2022, "Caravan", "", "Verhuurbaar"},
                    {172, "Lunar", "Delta", "GH-567-IJ", "Gray", 2017, "Caravan", "", "Verhuurbaar"},
                    {173, "Swi-", "Elegance", "KL-890-MN", "Black", 2018, "Caravan", "", "Verhuurbaar"},
                    {174, "Compass", "Corona", "OP-123-QR", "Blue", 2021, "Caravan", "", "Verhuurbaar"},
                    {175, "Coachman", "Acadia", "ST-456-UV", "Silver", 2019, "Caravan", "", "Verhuurbaar"},
                    {176, "Buccaneer", "Barracuda", "WX-789-YZ", "Red", 2020, "Caravan", "", "Verhuurbaar"},
                    {177, "Caravelair", "Antares", "AB-012-CD", "Green", 2016, "Caravan", "", "Verhuurbaar"},
                    {178, "Sterckeman", "Evolu-on", "EF-345-GH", "Black", 2018, "Caravan", "", "Verhuurbaar"},
                    {179, "Tab", "400", "IJ-678-KL", "Silver", 2021, "Caravan", "", "Verhuurbaar"},
                    {180, "Eriba", "Nova", "MN-901-OP", "Blue", 2020, "Caravan", "", "Verhuurbaar"},
                    {181, "Adria", "Adora", "QR-234-ST", "White", 2019, "Caravan", "", "Verhuurbaar"},
                    {182, "Fendt", "Opal", "UV-567-WX", "Black", 2022, "Caravan", "", "Verhuurbaar"},
                    {183, "Knaus", "Sky Traveller", "YZ-890-AB", "Green", 2017, "Caravan", "", "Verhuurbaar"},
                    {184, "Hobby", "Pres-ge", "CD-123-EF", "Gray", 2018, "Caravan", "", "Verhuurbaar"},
                    {185, "Dethle-s", "C'go", "GH-456-IJ", "Blue", 2020, "Caravan", "", "Verhuurbaar"},
                    {186, "Burstner", "Premio Life", "KL-789-MN", "Red", 2017, "Caravan", "", "Verhuurbaar"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd528a1-17a1-47cc-afe8-463def6bf1f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8e4617-13f3-4d5a-9dba-b627bf7f6bde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9862ee43-a40b-48b6-acf2-aef39e4775de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9e3d91-59a2-4e6c-8a41-9acace7ad820");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca45e2b3-891b-4a99-a5c4-a7e862b4d2a0");

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2de163ac-d38e-4bdd-9a65-8f34810dd084", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "50e651aa-fbe0-4e34-9677-511d8d0788d3", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "72127a9e-7d62-4bb8-8f53-c61226e6ee3b", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "c993550f-9a1f-4c18-8c80-98ace06abf18", null, "admin", "ADMIN" },
                    { "e54b5a49-73f1-466a-b6f1-bbaca6a62b3b", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "1", 0, null, "QJ9Z", "test@email.com", true, null, true, null, "TEST@EMAIL.COM", "USER1", null, "AQAAAAEAACcQAAAAEJ9Z", "1234567890", true, "QJ9Z", false, "user1", null });

            migrationBuilder.InsertData(
                table: "Bedrijven",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Bedrijf1", "1234567890" },
                    { 2, "Bedrijf2", "1234567891" },
                    { 3, "Bedrijf3", "1234567892" }
                });
        }
    }
}
