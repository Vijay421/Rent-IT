using System.Runtime.InteropServices.JavaScript;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public class VoertuigSeeder
    {
        public void Seed(ModelBuilder builder)
        {
            // DO NOT change the Voertuig ids, they are used in the user seeder!
            builder.Entity<Voertuig>().HasData(
                
            new Voertuig(1, "Toyota", "Corolla", "AB-123-CD", "Red", 2018, "Auto", "", "Verhuurbaar", 50.00, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 4), null),
            new Voertuig(2, "Ford", "Focus", "EF-456-GH", "Blue", 2019, "Auto", "", "Verhuurbaar", 51.39, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 4), null),
            new Voertuig(3, "Volkswagen", "Golf", "IJ-789-KL", "Black", 2020, "Auto", "", "Verhuurbaar", 40.00, new DateOnly(2025, 1, 3), new DateOnly(2025, 1, 5), null),
            new Voertuig(105, "Citroën", "Jumper", "QR-345-ST", "Gray", 2021, "Camper", "", "Verhuurbaar", 65.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 1, 24), null),
            new Voertuig(106, "Peugeot", "Boxer", "UV-678-WX", "Black", 2016, "Camper", "", "Verhuurbaar", 68.00, new DateOnly(2025, 2, 1), new DateOnly(2025, 2, 4), null),
            new Voertuig(185, "Dethle-s", "C'go", "GH-456-IJ", "Blue", 2020, "Caravan", "", "Verhuurbaar", 52.50, new DateOnly(2025, 5, 1), new DateOnly(2025, 6, 7), null),
            new Voertuig(186, "Burstner", "Premio Life", "KL-789-MN", "Red", 2017, "Caravan", "", "Verhuurbaar", 48.00, new DateOnly(2025, 8, 21), new DateOnly(2025, 8, 24), null),

            new Voertuig(4, "Honda", "Civic", "MN-012-OP", "White", 2017, "Auto", "", "Verhuurbaar", 27.00, new DateOnly(2025, 1, 15), new DateOnly(2025, 12, 10), null),
            new Voertuig(5, "BMW", "3 Series", "QR-345-ST", "Gray", 2021, "Auto", "", "Verhuurbaar", 64.39, new DateOnly(2025, 4, 15), new DateOnly(2025, 10, 25), null),
            new Voertuig(6, "Audi", "A4", "UV-678-WX", "Silver", 2016, "Auto", "", "Verhuurbaar", 21.47, new DateOnly(2025, 5, 5), new DateOnly(2025, 9, 18), null),
            new Voertuig(7, "Mercedes", "C-Class", "YZ-901-AB", "Blue", 2022, "Auto", "", "Verhuurbaar", 43.50, new DateOnly(2025, 6, 1), new DateOnly(2025, 6, 15), null),
            new Voertuig(8, "Nissan", "Qashqai", "CD-234-EF", "Green", 2015, "Auto", "", "Verhuurbaar", 98.21, new DateOnly(2025, 7, 10), new DateOnly(2025, 12, 20), null),
            new Voertuig(9, "Peugeot", "208", "GH-567-IJ", "Red", 2021, "Auto", "", "Verhuurbaar", 51.27, new DateOnly(2025, 8, 1), new DateOnly(2025, 12, 10), null),
            new Voertuig(10, "Renault", "Clio", "KL-890-MN", "Black", 2018, "Auto", "", "Verhuurbaar", 43.75, new DateOnly(2025, 9, 5), new DateOnly(2025, 11, 15), null),
            new Voertuig(11, "Hobby", "The Luxury", "OP-123-QR", "White", 2017, "Auto", "", "Verhuurbaar", 54.67, new DateOnly(2025, 10, 1), new DateOnly(2025, 10, 12), null),
            new Voertuig(12, "Fendt", "White", "ST-456-UV", "Gray", 2018, "Auto", "", "Verhuurbaar", 85.31, new DateOnly(2025, 11, 10), new DateOnly(2025, 11, 20), null),
            new Voertuig(13, "Knaus", "Sports", "WX-789-YZ", "Blue", 2019, "Auto", "", "Verhuurbaar", 65.32, new DateOnly(2025, 12, 1), new DateOnly(2025, 12, 12), null),
            new Voertuig(14, "Dethle-s", "Camper", "AB-012-CD", "Green", 2016, "Auto", "", "Verhuurbaar", 65.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 1, 22), null),
            new Voertuig(15, "Adria", "Altea", "EF-345-GH", "Silver", 2020, "Auto", "", "Verhuurbaar", 41.00, new DateOnly(2025, 2, 15), new DateOnly(2025, 5, 25), null),
            new Voertuig(16, "Eriba", "Touring", "IJ-678-KL", "Red", 2015, "Auto", "", "Verhuurbaar", 67.12, new DateOnly(2025, 3, 10), new DateOnly(2025, 3, 18), null),
            new Voertuig(17, "Tabbert", "Puccini", "MN-901-OP", "Black", 2021, "Auto", "", "Verhuurbaar", 60.00, new DateOnly(2025, 4, 5), new DateOnly(2025, 7, 12), null),
            new Voertuig(18, "Burstner", "Premio", "QR-234-ST", "White", 2019, "Auto", "", "Verhuurbaar", 58.00, new DateOnly(2025, 5, 15), new DateOnly(2025, 12, 25), null),
            new Voertuig(19, "LMC", "Music", "UV-567-WX", "Blue", 2018, "Auto", "", "Verhuurbaar", 55.00, new DateOnly(2025, 6, 20), new DateOnly(2025, 7, 1), null),
            new Voertuig(20, "Sprite", "Cruzer", "YZ-890-AB", "Gray", 2022, "Auto", "", "Verhuurbaar", 48.00, new DateOnly(2025, 8, 10), new DateOnly(2025, 9, 22), null),
            new Voertuig(21, "Volkswagen", "California", "CD-123-EF", "Red", 2018, "Auto", "", "Verhuurbaar", 70.00, new DateOnly(2025, 9, 15), new DateOnly(2025, 11, 25), null),
            new Voertuig(22, "Mercedes", "Marco Polo", "GH-456-IJ", "Blue", 2019, "Auto", "", "Verhuurbaar", 85.00, new DateOnly(2025, 10, 5), new DateOnly(2025, 10, 18), null),
            new Voertuig(23, "Ford", "Nugget", "KL-789-MN", "Black", 2020, "Auto", "", "Verhuurbaar", 72.00, new DateOnly(2025, 10, 1), new DateOnly(2025, 11, 12), null),
            new Voertuig(24, "Fiat", "Ducato", "OP-012-QR", "White", 2017, "Auto", "", "Verhuurbaar", 45.00, new DateOnly(2025, 11, 10), new DateOnly(2025, 12, 20), null),
            new Voertuig(25, "Lemon", "Jumper", "ST-345-UV", "Gray", 2021, "Auto", "", "Verhuurbaar", 52.00, new DateOnly(2025, 1, 15), new DateOnly(2025, 4, 25), null),
            new Voertuig(26, "Peugeot", "Boxer", "WX-678-YZ", "Silver", 2016, "Auto", "", "Verhuurbaar", 47.00, new DateOnly(2025, 2, 10), new DateOnly(2025, 6, 20), null),
            new Voertuig(27, "Renault", "Master", "AB-901-CD", "Blue", 2022, "Auto", "", "Verhuurbaar", 60.00, new DateOnly(2025, 3, 5), new DateOnly(2025, 8, 15), null),
            new Voertuig(28, "Iveco", "Daily", "EF-234-GH", "Green", 2015, "Auto", "", "Verhuurbaar", 63.00, new DateOnly(2025, 4, 1), new DateOnly(2025, 10, 12), null),
            new Voertuig(29, "Opel", "Movano", "IJ-567-KL", "Red", 2021, "Auto", "", "Verhuurbaar", 58.00, new DateOnly(2025, 5, 15), new DateOnly(2025, 12, 1), null),
            new Voertuig(30, "Nissan", "NV400", "MN-890-OP", "Black", 2018, "Auto", "", "Verhuurbaar", 56.00, new DateOnly(2025, 6, 10), new DateOnly(2025, 12, 20), null),
            new Voertuig(31, "Kia", "Sportage", "QR-123-ST", "Silver", 2019, "Auto", "", "Verhuurbaar", 39.00, new DateOnly(2025, 7, 15), new DateOnly(2025, 10, 5), null),
            new Voertuig(32, "Hyundai", "Tucson", "UV-456-WX", "Blue", 2020, "Auto", "", "Verhuurbaar", 42.50, new DateOnly(2025, 8, 1), new DateOnly(2026, 1, 25), null),
            new Voertuig(33, "Skoda", "Octavia", "YZ-789-AB", "Green", 2017, "Auto", "", "Verhuurbaar", 37.00, new DateOnly(2025, 9, 10), new DateOnly(2026, 3, 10), null),
            new Voertuig(34, "Mazda", "3", "CD-012-EF", "White", 2018, "Auto", "", "Verhuurbaar", 35.75, new DateOnly(2025, 10, 15), new DateOnly(2026, 6, 15), null),
            new Voertuig(35, "Subaru", "Impreza", "GH-345-IJ", "Gray", 2021, "Auto", "", "Verhuurbaar", 49.00, new DateOnly(2025, 11, 1), new DateOnly(2026, 4, 5), null),
            new Voertuig(36, "Suzuki", "Vitara", "KL-678-MN", "Black", 2019, "Auto", "", "Verhuurbaar", 41.25, new DateOnly(2025, 12, 10), new DateOnly(2026, 7, 20), null),
            new Voertuig(37, "Volvo", "XC60", "OP-901-QR", "Silver", 2020, "Auto", "", "Verhuurbaar", 47.50, new DateOnly(2025, 1, 1), new DateOnly(2025, 8, 10), null),
            new Voertuig(38, "Mitsubishi", "Outlander", "ST-234-UV", "Red", 2017, "Auto", "", "Verhuurbaar", 40.00, new DateOnly(2025, 2, 15), new DateOnly(2025, 9, 1), null),
            new Voertuig(39, "Jeep", "Wrangler", "WX-567-YZ", "Green", 2022, "Auto", "", "Verhuurbaar", 75.00, new DateOnly(2025, 3, 20), new DateOnly(2025, 12, 10), null),
            new Voertuig(40, "Land Rover", "Defender", "YZ-890-AB", "Blue", 2021, "Auto", "", "Verhuurbaar", 68.50, new DateOnly(2025, 4, 25), new DateOnly(2025, 8, 25), null),
            new Voertuig(41, "Bailey", "Unicorn", "CD-123-EF", "Gray", 2018, "Auto", "", "Verhuurbaar", 66.75, new DateOnly(2025, 5, 5), new DateOnly(2025, 10, 1), null),
            new Voertuig(42, "Lunar", "Clubman", "GH-456-IJ", "Black", 2019, "Auto", "", "Verhuurbaar", 62.00, new DateOnly(2025, 6, 15), new DateOnly(2025, 11, 12), null),
            new Voertuig(43, "Swi-", "Conqueror", "KL-789-MN", "White", 2020, "Auto", "", "Verhuurbaar", 70.50, new DateOnly(2025, 7, 10), new DateOnly(2025, 12, 5), null),
            new Voertuig(44, "Elddis", "Avante", "OP-012-QR", "Silver", 2017, "Auto", "", "Verhuurbaar", 55.00, new DateOnly(2025, 8, 20), new DateOnly(2025, 11, 15), null),
            new Voertuig(45, "Compass", "Casita", "ST-345-UV", "Blue", 2021, "Auto", "", "Verhuurbaar", 74.00, new DateOnly(2025, 9, 15), new DateOnly(2026, 1, 10), null),
            new Voertuig(46, "Coachman", "VIP", "WX-678-YZ", "Green", 2016, "Auto", "", "Verhuurbaar", 59.00, new DateOnly(2025, 10, 1), new DateOnly(2026, 4, 20), null),
            new Voertuig(47, "Buccaneer", "Commodore", "AB-901-CD", "Red", 2022, "Auto", "", "Verhuurbaar", 77.00, new DateOnly(2025, 11, 5), new DateOnly(2026, 5, 5), null),
            new Voertuig(48, "Caravelair", "Allegra", "EF-234-GH", "Black", 2015, "Auto", "", "Verhuurbaar", 49.50, new DateOnly(2025, 12, 15), new DateOnly(2026, 6, 10), null),
            new Voertuig(49, "Sterckeman", "Starle-", "IJ-567-KL", "White", 2021, "Auto", "", "Verhuurbaar", 63.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 6, 15), null),
            new Voertuig(50, "Tab", "320", "MN-890-OP", "Gray", 2018, "Auto", "", "Verhuurbaar", 51.00, new DateOnly(2025, 2, 5), new DateOnly(2025, 7, 12), null),
            new Voertuig(51, "Volkswagen", "Grand California", "QR-123-ST", "Blue", 2019, "Auto", "", "Verhuurbaar", 72.50, new DateOnly(2025, 3, 20), new DateOnly(2025, 8, 25), null),
            new Voertuig(52, "Mercedes", "Sprinter", "UV-456-WX", "Green", 2020, "Auto", "", "Verhuurbaar", 58.50, new DateOnly(2025, 4, 15), new DateOnly(2025, 9, 10), null),
            new Voertuig(53, "Ford", "Transit Custom", "YZ-789-AB", "Red", 2017, "Auto", "", "Verhuurbaar", 43.50, new DateOnly(2025, 5, 10), new DateOnly(2025, 10, 20), null),
            new Voertuig(54, "Fiat", "Talento", "CD-012-EF", "Black", 2018, "Auto", "", "Verhuurbaar", 45.00, new DateOnly(2025, 6, 5), new DateOnly(2025, 11, 15), null),
            new Voertuig(55, "Lemon", "SpaceTourer", "GH-345-IJ", "White", 2021, "Auto", "", "Verhuurbaar", 50.00, new DateOnly(2025, 7, 1), new DateOnly(2025, 12, 5), null),
            new Voertuig(56, "Peugeot", "Traveller", "KL-678-MN", "Gray", 2019, "Auto", "", "Verhuurbaar", 47.00, new DateOnly(2025, 8, 1), new DateOnly(2026, 1, 10), null),
            new Voertuig(57, "Renault", "Tra-c", "OP-901-QR", "Blue", 2020, "Auto", "", "Verhuurbaar", 49.50, new DateOnly(2025, 9, 1), new DateOnly(2026, 2, 15), null),
            new Voertuig(58, "Iveco", "Daily", "ST-234-UV", "Green", 2017, "Auto", "", "Verhuurbaar", 52.00, new DateOnly(2025, 10, 1), new DateOnly(2026, 3, 20), null),
            new Voertuig(59, "Opel", "Vivaro", "WX-567-YZ", "Red", 2022, "Auto", "", "Verhuurbaar", 66.00, new DateOnly(2025, 11, 1), new DateOnly(2026, 4, 25), null),
            new Voertuig(60, "Nissan", "Primastar", "YZ-890-AB", "Black", 2021, "Auto", "", "Verhuurbaar", 54.00, new DateOnly(2025, 12, 1), new DateOnly(2026, 5, 10), null),
            new Voertuig(61, "Toyota", "Yaris", "CD-123-EF", "White", 2019, "Auto", "", "Verhuurbaar", 37.50, new DateOnly(2025, 2, 10), new DateOnly(2025, 7, 15), null),
            new Voertuig(62, "Ford", "Kuga", "GH-456-IJ", "Gray", 2020, "Auto", "", "Verhuurbaar", 41.00, new DateOnly(2025, 3, 15), new DateOnly(2025, 8, 20), null),
            new Voertuig(63, "Volkswagen", "Passat", "KL-789-MN", "Blue", 2017, "Auto", "", "Verhuurbaar", 39.50, new DateOnly(2025, 4, 15), new DateOnly(2025, 9, 25), null),
            new Voertuig(64, "Honda", "Agreed", "OP-012-QR", "Green", 2018, "Auto", "", "Verhuurbaar", 42.00, new DateOnly(2025, 5, 10), new DateOnly(2025, 10, 10), null),
            new Voertuig(65, "BMW", "X5", "ST-345-UV", "Silver", 2021, "Auto", "", "Verhuurbaar", 72.50, new DateOnly(2025, 6, 20), new DateOnly(2025, 11, 20), null),
            new Voertuig(66, "Audi", "Q7", "WX-678-YZ", "Black", 2019, "Auto", "", "Verhuurbaar", 68.00, new DateOnly(2025, 7, 15), new DateOnly(2025, 12, 25), null),
            new Voertuig(67, "Mercedes", "GLC", "AB-901-CD", "White", 2020, "Auto", "", "Verhuurbaar", 65.00, new DateOnly(2025, 8, 10), new DateOnly(2026, 1, 30), null),
            new Voertuig(68, "Nissan", "Juke", "EF-234-GH", "Gray", 2017, "Auto", "", "Verhuurbaar", 38.00, new DateOnly(2025, 9, 5), new DateOnly(2026, 2, 10), null),
            new Voertuig(69, "Peugeot", "308", "IJ-567-KL", "Blue", 2022, "Auto", "", "Verhuurbaar", 45.00, new DateOnly(2025, 10, 15), new DateOnly(2026, 3, 20), null),
            new Voertuig(70, "Renault", "Megane", "MN-890-OP", "Green", 2021, "Auto", "", "Verhuurbaar", 43.50, new DateOnly(2025, 11, 20), new DateOnly(2026, 4, 15), null),
            new Voertuig(71, "Tabbert", "Rossini", "QR-123-ST", "Red", 2018, "Auto", "", "Verhuurbaar", 62.00, new DateOnly(2025, 12, 10), new DateOnly(2026, 5, 20), null),
            new Voertuig(72, "Dethle-s", "Beduin", "UV-456-WX", "Black", 2019, "Auto", "", "Verhuurbaar", 64.00, new DateOnly(2025, 1, 15), new DateOnly(2025, 6, 25), null),
            new Voertuig(73, "Fendt", "Tendency", "YZ-789-AB", "White", 2020, "Auto", "", "Verhuurbaar", 66.50, new DateOnly(2025, 2, 20), new DateOnly(2025, 7, 30), null),
            new Voertuig(74, "Knaus", "Sudwind", "CD-012-EF", "Silver", 2017, "Auto", "", "Verhuurbaar", 58.00, new DateOnly(2025, 3, 25), new DateOnly(2025, 8, 15), null),
            new Voertuig(75, "Hobby", "Excellent", "GH-345-IJ", "Blue", 2021, "Auto", "", "Verhuurbaar", 68.00, new DateOnly(2025, 4, 10), new DateOnly(2025, 9, 20), null),
            new Voertuig(76, "Adria", "Ac-on", "KL-678-MN", "Green", 2016, "Auto", "", "Verhuurbaar", 60.50, new DateOnly(2025, 5, 15), new DateOnly(2025, 10, 25), null),
            new Voertuig(77, "Eriba", "Feeling", "OP-901-QR", "Red", 2022, "Auto", "", "Verhuurbaar", 72.00, new DateOnly(2025, 6, 20), new DateOnly(2025, 11, 20), null),
            new Voertuig(78, "Burstner", "Aversely", "ST-234-UV", "Black", 2015, "Auto", "", "Verhuurbaar", 55.00, new DateOnly(2025, 7, 25), new DateOnly(2025, 12, 10), null),
            new Voertuig(79, "LMC", "Vivo", "WX-567-YZ", "White", 2021, "Auto", "", "Verhuurbaar", 69.00, new DateOnly(2025, 8, 30), new DateOnly(2026, 1, 20), null),
            new Voertuig(80, "Sprite", "Major", "YZ-890-AB", "Gray", 2018, "Auto", "", "Verhuurbaar", 52.00, new DateOnly(2025, 9, 15), new DateOnly(2026, 2, 25), null),
            new Voertuig(81, "Volkswagen", "Mul-van", "CD-123-EF", "Black", 2019, "Auto", "", "Verhuurbaar", 57.00, new DateOnly(2025, 1, 15), new DateOnly(2025, 10, 15), null),
            new Voertuig(82, "Mercedes", "Vito", "GH-456-IJ", "White", 2020, "Auto", "", "Verhuurbaar", 63.00, new DateOnly(2025, 2, 10), new DateOnly(2025, 11, 5), null),
            new Voertuig(83, "Ford", "Custom", "KL-789-MN", "Gray", 2017, "Auto", "", "Verhuurbaar", 49.50, new DateOnly(2025, 7, 20), new DateOnly(2025, 12, 20), null),
            new Voertuig(84, "Fiat", "Scudo", "OP-012-QR", "Blue", 2018, "Auto", "", "Verhuurbaar", 51.00, new DateOnly(2025, 3, 5), new DateOnly(2026, 1, 10), null),
            new Voertuig(85, "Lemon", "Berlingo", "ST-345-UV", "Green", 2021, "Auto", "", "Verhuurbaar", 55.50, new DateOnly(2025, 9, 15), new DateOnly(2026, 2, 15), null),
            new Voertuig(86, "Peugeot", "Partner", "WX-678-YZ", "Red", 2019, "Auto", "", "Verhuurbaar", 52.50, new DateOnly(2025, 3, 5), new DateOnly(2026, 3, 5), null),
            new Voertuig(87, "Renault", "Kangoo", "AB-901-CD", "Black", 2020, "Auto", "", "Verhuurbaar", 53.00, new DateOnly(2025, 11, 15), new DateOnly(2026, 4, 15), null),
            new Voertuig(88, "Iveco", "Eurocargo", "EF-234-GH", "White", 2017, "Auto", "", "Verhuurbaar", 59.00, new DateOnly(2025, 5, 10), new DateOnly(2025, 9, 10), null),
            new Voertuig(89, "Opel", "Combo", "IJ-567-KL", "Gray", 2022, "Auto", "", "Verhuurbaar", 61.00, new DateOnly(2025, 6, 15), new DateOnly(2025, 10, 15), null),
            new Voertuig(90, "Nissan", "NV200", "MN-890-OP", "Blue", 2021, "Auto", "", "Verhuurbaar", 62.50, new DateOnly(2025, 7, 10), new DateOnly(2025, 11, 10), null),
            new Voertuig(91, "Kia", "Picanto", "QR-123-ST", "Green", 2018, "Auto", "", "Verhuurbaar", 40.00, new DateOnly(2025, 8, 1), new DateOnly(2025, 12, 1), null),
            new Voertuig(92, "Hyundai", "i30", "UV-456-WX", "Red", 2019, "Auto", "", "Verhuurbaar", 43.50, new DateOnly(2025, 2, 20), new DateOnly(2026, 1, 20), null),
            new Voertuig(93, "Skoda", "Superb", "YZ-789-AB", "Black", 2020, "Auto", "", "Verhuurbaar", 59.00, new DateOnly(2025, 10, 15), new DateOnly(2026, 3, 15), null),
            new Voertuig(94, "Mazda", "6", "CD-012-EF", "White", 2017, "Auto", "", "Verhuurbaar", 45.00, new DateOnly(2025, 11, 5), new DateOnly(2026, 4, 5), null),
            new Voertuig(95, "Subaru", "Forester", "GH-345-IJ", "Gray", 2021, "Auto", "", "Verhuurbaar", 58.50, new DateOnly(2025, 1, 15), new DateOnly(2026, 5, 15), null),
            new Voertuig(96, "Suzuki", "Swift", "KL-678-MN", "Silver", 2019, "Auto", "", "Verhuurbaar", 42.00, new DateOnly(2025, 5, 20), new DateOnly(2025, 10, 20), null),
            new Voertuig(97, "Volvo", "XC90", "OP-901-QR", "Blue", 2020, "Auto", "", "Verhuurbaar", 65.00, new DateOnly(2025, 6, 25), new DateOnly(2025, 11, 25), null),
            new Voertuig(98, "Mitsubishi", "ASX", "ST-234-UV", "Green", 2017, "Auto", "", "Verhuurbaar", 47.00, new DateOnly(2025, 7, 15), new DateOnly(2025, 12, 15), null),
            new Voertuig(99, "Jeep", "Cherokee", "WX-567-YZ", "Red", 2022, "Auto", "", "Verhuurbaar", 70.00, new DateOnly(2025, 8, 5), new DateOnly(2026, 1, 5), null),
            new Voertuig(100, "Land Rover", "Discovery", "YZ-890-AB", "Blue", 2021, "Auto", "", "Verhuurbaar", 73.00, new DateOnly(2025, 9, 10), new DateOnly(2026, 2, 10), null),
            new Voertuig(101, "Volkswagen", "California", "AB-123-CD", "Red", 2018, "Camper", "", "Verhuurbaar", 69.00, new DateOnly(2025, 10, 15), new DateOnly(2026, 3, 15), null),
            new Voertuig(102, "Mercedes", "Marco Polo", "EF-456-GH", "Silver", 2019, "Camper", "", "Verhuurbaar", 72.00, new DateOnly(2025, 11, 5), new DateOnly(2026, 4, 5), null),
            new Voertuig(103, "Ford", "Transit Custom", "IJ-789-KL", "Blue", 2020, "Camper", "", "Verhuurbaar", 66.00, new DateOnly(2025, 12, 15), new DateOnly(2026, 5, 15), null),
            new Voertuig(104, "Fiat", "Ducato", "MN-012-OP", "White", 2017, "Camper", "", "Verhuurbaar", 61.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 10, 10), null),
            
            
            new Voertuig(107, "Renault", "Master", "YZ-901-AB", "Green", 2022, "Camper", "", "Verhuurbaar", 74.00, new DateOnly(2025, 3, 5), new DateOnly(2026, 1, 5), null),
            new Voertuig(108, "Nissan", "NV400", "CD-234-EF", "Blue", 2015, "Camper", "", "Verhuurbaar", 62.50, new DateOnly(2025, 9, 15), new DateOnly(2026, 2, 15), null),
            new Voertuig(109, "Opel", "Movano", "GH-567-IJ", "Silver", 2021, "Camper", "", "Verhuurbaar", 67.00, new DateOnly(2025, 10, 1), new DateOnly(2026, 3, 1), null),
            new Voertuig(110, "Iveco", "Daily", "KL-890-MN", "Red", 2018, "Camper", "", "Verhuurbaar", 63.50, new DateOnly(2025, 11, 20), new DateOnly(2026, 4, 20), null),
            new Voertuig(111, "Volkswagen", "Grand California", "OP-123-QR", "White", 2017, "Camper", "", "Verhuurbaar", 70.00, new DateOnly(2025, 12, 15), new DateOnly(2026, 5, 15), null),
            new Voertuig(112, "Mercedes", "Sprinter", "ST-456-UV", "Blue", 2019, "Camper", "", "Verhuurbaar", 72.50, new DateOnly(2025, 5, 10), new DateOnly(2025, 10, 10), null),
            new Voertuig(113, "Ford", "Nugget", "WX-789-YZ", "Black", 2020, "Camper", "", "Verhuurbaar", 75.00, new DateOnly(2025, 6, 15), new DateOnly(2025, 11, 15), null),
            new Voertuig(114, "Fiat", "Talento", "AB-012-CD", "Green", 2016, "Camper", "", "Verhuurbaar", 61.00, new DateOnly(2025, 7, 20), new DateOnly(2025, 12, 20), null),
            new Voertuig(115, "Citroën", "SpaceTourer", "EF-345-GH", "Red", 2018, "Camper", "", "Verhuurbaar", 66.00, new DateOnly(2025, 2, 5), new DateOnly(2026, 1, 5), null),
            new Voertuig(116, "Peugeot", "Traveller", "IJ-678-KL", "Black", 2021, "Camper", "", "Verhuurbaar", 69.00, new DateOnly(2025, 3, 10), new DateOnly(2026, 2, 10), null),
            new Voertuig(117, "Renault", "Tra-c", "MN-901-OP", "White", 2020, "Camper", "", "Verhuurbaar", 68.50, new DateOnly(2025, 4, 15), new DateOnly(2026, 3, 15), null),
            new Voertuig(118, "Nissan", "Primastar", "QR-234-ST", "Silver", 2019, "Camper", "", "Verhuurbaar", 62.50, new DateOnly(2025, 5, 20), new DateOnly(2025, 10, 20), null),
            new Voertuig(119, "Opel", "Vivaro", "UV-567-WX", "Gray", 2022, "Camper", "", "Verhuurbaar", 70.00, new DateOnly(2025, 6, 25), new DateOnly(2025, 11, 25), null),
            new Voertuig(120, "Iveco", "Eurocargo", "YZ-890-AB", "Black", 2017, "Camper", "", "Verhuurbaar", 65.00, new DateOnly(2025, 7, 15), new DateOnly(2025, 12, 15), null),
            new Voertuig(121, "Volkswagen", "Mul-van", "CD-123-EF", "Blue", 2018, "Camper", "", "Verhuurbaar", 60.00, new DateOnly(2025, 8, 1), new DateOnly(2025, 12, 1), null),
            new Voertuig(122, "Mercedes", "Vito", "GH-456-IJ", "Green", 2020, "Camper", "", "Verhuurbaar", 64.00, new DateOnly(2025, 3, 5), new DateOnly(2026, 1, 5), null),
            new Voertuig(123, "Ford", "Kuga Camper", "KL-789-MN", "Silver", 2017, "Camper", "", "Verhuurbaar", 58.50, new DateOnly(2025, 5, 15), new DateOnly(2026, 2, 15), null),
            new Voertuig(124, "Fiat", "Scudo", "OP-012-QR", "Red", 2018, "Camper", "", "Verhuurbaar", 62.00, new DateOnly(2025, 6, 20), new DateOnly(2026, 3, 20), null),
            new Voertuig(125, "Citroën", "Berlingo", "ST-345-UV", "White", 2019, "Camper", "", "Verhuurbaar", 57.50, new DateOnly(2025, 10, 10), new DateOnly(2025, 12, 10), null),
            new Voertuig(126, "Peugeot", "Expert Camper", "WX-678-YZ", "Gray", 2016, "Camper", "", "Verhuurbaar", 66.00, new DateOnly(2025, 2, 15), new DateOnly(2026, 4, 15), null),
            new Voertuig(127, "Renault", "Kangoo Camper", "AB-901-CD", "Blue", 2022, "Camper", "", "Verhuurbaar", 70.50, new DateOnly(2025, 4, 5), new DateOnly(2026, 5, 5), null),
            new Voertuig(128, "Nissan", "Juke Camper", "EF-234-GH", "Black", 2015, "Camper", "", "Verhuurbaar", 61.00, new DateOnly(2025, 6, 15), new DateOnly(2026, 7, 15), null),
            new Voertuig(129, "Opel", "Za-ra Camper", "GH-567-IJ", "Green", 2021, "Camper", "", "Verhuurbaar", 65.00, new DateOnly(2025, 8, 5), new DateOnly(2025, 9, 5), null),
            new Voertuig(130, "Iveco", "Camper 2000", "KL-890-MN", "Red", 2018, "Camper", "", "Verhuurbaar", 63.50, new DateOnly(2025, 3, 15), new DateOnly(2025, 10, 15), null),
            new Voertuig(131, "Volkswagen", "Combi", "OP-123-QR", "Black", 2017, "Camper", "", "Verhuurbaar", 60.00, new DateOnly(2025, 5, 1), new DateOnly(2025, 12, 1), null),
            new Voertuig(132, "Mercedes", "Sprinter XXL", "ST-456-UV", "Silver", 2021, "Camper", "", "Verhuurbaar", 75.00, new DateOnly(2025, 6, 5), new DateOnly(2026, 1, 5), null),
            new Voertuig(133, "Ford", "Custom Camper", "WX-789-YZ", "Blue", 2020, "Camper", "", "Verhuurbaar", 72.50, new DateOnly(2025, 7, 10), new DateOnly(2026, 2, 10), null),
            new Voertuig(134, "Fiat", "Ducato Maxi", "AB-012-CD", "White", 2016, "Camper", "", "Verhuurbaar", 61.50, new DateOnly(2025, 12, 15), new DateOnly(2026, 3, 15), null),
            new Voertuig(135, "Citroën", "Jumper Camper", "EF-345-GH", "Green", 2018, "Camper", "", "Verhuurbaar", 62.50, new DateOnly(2025, 1, 10), new DateOnly(2026, 4, 10), null),
            new Voertuig(136, "Peugeot", "Boxer XL", "IJ-678-KL", "Black", 2021, "Camper", "", "Verhuurbaar", 69.50, new DateOnly(2025, 2, 5), new DateOnly(2026, 5, 5), null),
            new Voertuig(137, "Renault", "Master Pro", "MN-901-OP", "Gray", 2019, "Camper", "", "Verhuurbaar", 67.00, new DateOnly(2025, 3, 20), new DateOnly(2026, 6, 20), null),
            new Voertuig(138, "Nissan", "NV300 Camper", "QR-234-ST", "Blue", 2022, "Camper", "", "Verhuurbaar", 74.00, new DateOnly(2025, 4, 15), new DateOnly(2026, 7, 15), null),
            new Voertuig(139, "Opel", "Vivaro XL", "UV-567-WX", "Silver", 2017, "Camper", "", "Verhuurbaar", 65.00, new DateOnly(2025, 9, 10), new DateOnly(2026, 8, 10), null),
            new Voertuig(140, "Iveco", "Daily Pro", "YZ-890-AB", "Red", 2018, "Camper", "", "Verhuurbaar", 66.50, new DateOnly(2025, 2, 15), new DateOnly(2026, 2, 15), null),
            new Voertuig(141, "Volkswagen", "T6 California", "CD-123-EF", "Green", 2020, "Camper", "", "Verhuurbaar", 72.50, new DateOnly(2025, 3, 20), new DateOnly(2026, 3, 20), null),
            new Voertuig(142, "Mercedes", "V-Class Camper", "GH-456-IJ", "Black", 2019, "Camper", "", "Verhuurbaar", 75.00, new DateOnly(2025, 4, 15), new DateOnly(2026, 4, 15), null),
            new Voertuig(143, "Ford", "Transit Nugget Plus", "KL-789-MN", "White", 2022, "Camper", "", "Verhuurbaar", 76.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 5, 10), null),
            new Voertuig(144, "Hobby", "The Luxury", "AB-123-CD", "White", 2018, "Caravan", "", "Verhuurbaar", 48.00, new DateOnly(2025, 2, 15), new DateOnly(2025, 7, 15), null),
            new Voertuig(145, "Fendt", "White", "EF-456-GH", "Gray", 2019, "Caravan", "", "Verhuurbaar", 50.00, new DateOnly(2025, 3, 20), new DateOnly(2025, 8, 20), null),
            new Voertuig(146, "Knaus", "Camper", "IJ-789-KL", "Black", 2020, "Caravan", "", "Verhuurbaar", 51.00, new DateOnly(2025, 4, 15), new DateOnly(2025, 9, 15), null),
            new Voertuig(147, "Adria", "Adria Home", "MN-012-OP", "Blue", 2021, "Caravan", "", "Verhuurbaar", 52.50, new DateOnly(2025, 5, 10), new DateOnly(2025, 10, 10), null),
            new Voertuig(148, "Tabbert", "Stylish", "QR-345-ST", "Green", 2022, "Caravan", "", "Verhuurbaar", 54.00, new DateOnly(2025, 3, 15), new DateOnly(2025, 8, 15), null),
            new Voertuig(149, "Hobby", "Comfort", "UV-678-WX", "Red", 2023, "Caravan", "", "Verhuurbaar", 55.00, new DateOnly(2025, 4, 20), new DateOnly(2025, 9, 20), null),
            new Voertuig(150, "Fendt", "Luxury", "YZ-901-AB", "Silver", 2023, "Caravan", "", "Verhuurbaar", 58.00, new DateOnly(2025, 5, 15), new DateOnly(2025, 7, 15), null),
            new Voertuig(151, "LMC", "Music", "CD-234-EF", "Blue", 2015, "Caravan", "", "Verhuurbaar", 45.00, new DateOnly(2025, 1, 20), new DateOnly(2025, 11, 20), null),
            new Voertuig(152, "Sprite", "Cruzer", "GH-567-IJ", "Red", 2021, "Caravan", "", "Verhuurbaar", 48.00, new DateOnly(2025, 1, 25), new DateOnly(2025, 12, 25), null),
            new Voertuig(153, "Bailey", "Unicorn", "KL-890-MN", "Gray", 2018, "Caravan", "", "Verhuurbaar", 47.50, new DateOnly(2025, 2, 10), new DateOnly(2025, 11, 10), null),
            new Voertuig(154, "Lunar", "Clubman", "OP-123-QR", "Silver", 2017, "Caravan", "", "Verhuurbaar", 46.00, new DateOnly(2025, 2, 15), new DateOnly(2025, 10, 15), null),
            new Voertuig(155, "Swi-", "Conqueror", "ST-456-UV", "Blue", 2019, "Caravan", "", "Verhuurbaar", 49.00, new DateOnly(2025, 2, 20), new DateOnly(2025, 9, 20), null),
            new Voertuig(156, "Compass", "Casita", "WX-789-YZ", "Green", 2020, "Caravan", "", "Verhuurbaar", 50.00, new DateOnly(2025, 3, 5), new DateOnly(2025, 10, 5), null),
            new Voertuig(157, "Coachman", "VIP", "AB-012-CD", "Red", 2016, "Caravan", "", "Verhuurbaar", 46.50, new DateOnly(2025, 3, 10), new DateOnly(2025, 10, 10), null),
            new Voertuig(158, "Buccaneer", "Commodore", "EF-345-GH", "Black", 2018, "Caravan", "", "Verhuurbaar", 51.00, new DateOnly(2025, 4, 15), new DateOnly(2025, 11, 15), null),
            new Voertuig(159, "Caravelair", "Allegra", "IJ-678-KL", "White", 2021, "Caravan", "", "Verhuurbaar", 52.00, new DateOnly(2025, 4, 20), new DateOnly(2025, 12, 20), null), 
            new Voertuig(160, "Sterckeman", "Starle-", "MN-901-OP", "Silver", 2020, "Caravan", "", "Verhuurbaar", 53.00, new DateOnly(2025, 5, 10), new DateOnly(2026, 1, 10), null),
            new Voertuig(161, "Tab", "320", "QR-234-ST", "Blue", 2019, "Caravan", "", "Verhuurbaar", 48.50, new DateOnly(2025, 5, 15), new DateOnly(2026, 2, 15), null),
            new Voertuig(162, "Eriba", "Touring", "UV-567-WX", "Gray", 2022, "Caravan", "", "Verhuurbaar", 55.00, new DateOnly(2025, 6, 20), new DateOnly(2026, 3, 20), null),
            new Voertuig(163, "Adria", "Ac-on", "YZ-890-AB", "Red", 2017, "Caravan", "", "Verhuurbaar", 47.00, new DateOnly(2025, 6, 5), new DateOnly(2026, 4, 5), null),
            new Voertuig(164, "Fendt", "Tendency", "CD-123-EF", "White", 2018, "Caravan", "", "Verhuurbaar", 49.50, new DateOnly(2025, 6, 10), new DateOnly(2026, 5, 10), null),
            new Voertuig(165, "Knaus", "Sudwind", "GH-456-IJ", "Green", 2020, "Caravan", "", "Verhuurbaar", 52.50, new DateOnly(2025, 7, 15), new DateOnly(2026, 6, 15), null),
            new Voertuig(166, "Hobby", "Excellent", "KL-789-MN", "Black", 2017, "Caravan", "", "Verhuurbaar", 51.00, new DateOnly(2025, 8, 1), new DateOnly(2026, 7, 1), null),
            new Voertuig(167, "Dethle-s", "Beduin", "OP-012-QR", "Blue", 2019, "Caravan", "", "Verhuurbaar", 50.00, new DateOnly(2025, 8, 5), new DateOnly(2025, 8, 22), null),
            new Voertuig(168, "Burstner", "Aversely", "ST-345-UV", "Silver", 2021, "Caravan", "", "Verhuurbaar", 54.00, new DateOnly(2025, 9, 10), new DateOnly(2025, 11, 30), null),
            new Voertuig(169, "LMC", "Vivo", "WX-678-YZ", "Red", 2020, "Caravan", "", "Verhuurbaar", 49.00, new DateOnly(2025, 10, 15), new DateOnly(2025, 12, 30), null),
            new Voertuig(170, "Sprite", "Major", "AB-901-CD", "Green", 2019, "Caravan", "", "Verhuurbaar", 48.00, new DateOnly(2025, 11, 20), new DateOnly(2026, 1, 30), null),
            new Voertuig(171, "Bailey", "Phoenix", "EF-234-GH", "White", 2022, "Caravan", "", "Verhuurbaar", 55.00, new DateOnly(2025, 12, 5), new DateOnly(2026, 2, 5), null),
            new Voertuig(172, "Lunar", "Delta", "GH-567-IJ", "Gray", 2017, "Caravan", "", "Verhuurbaar", 46.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 3, 10), null),
            new Voertuig(173, "Swi-", "Elegance", "KL-890-MN", "Black", 2018, "Caravan", "", "Verhuurbaar", 49.50, new DateOnly(2025, 2, 15), new DateOnly(2025, 4, 15), null),
            new Voertuig(174, "Compass", "Corona", "OP-123-QR", "Blue", 2021, "Caravan", "", "Verhuurbaar", 51.00, new DateOnly(2025, 3, 20), new DateOnly(2025, 5, 20), null),
            new Voertuig(175, "Coachman", "Acadia", "ST-456-UV", "Silver", 2019, "Caravan", "", "Verhuurbaar", 53.00, new DateOnly(2025, 4, 5), new DateOnly(2025, 6, 5), null),
            new Voertuig(176, "Buccaneer", "Barracuda", "WX-789-YZ", "Red", 2020, "Caravan", "", "Verhuurbaar", 54.50, new DateOnly(2025, 5, 10), new DateOnly(2025, 7, 10), null),
            new Voertuig(177, "Caravelair", "Antares", "AB-012-CD", "Green", 2016, "Caravan", "", "Verhuurbaar", 47.50, new DateOnly(2025, 6, 15), new DateOnly(2025, 8, 15), null),
            new Voertuig(178, "Sterckeman", "Evolu-on", "EF-345-GH", "Black", 2018, "Caravan", "", "Verhuurbaar", 49.00, new DateOnly(2025, 7, 20), new DateOnly(2025, 9, 20), null),
            new Voertuig(179, "Tab", "400", "IJ-678-KL", "Silver", 2021, "Caravan", "", "Verhuurbaar", 52.00, new DateOnly(2025, 8, 5), new DateOnly(2025, 10, 5), null),
            new Voertuig(180, "Eriba", "Nova", "MN-901-OP", "Blue", 2020, "Caravan", "", "Verhuurbaar", 53.50, new DateOnly(2025, 9, 10), new DateOnly(2025, 11, 10), null),
            new Voertuig(181, "Adria", "Adora", "QR-234-ST", "White", 2019, "Caravan", "", "Verhuurbaar", 51.50, new DateOnly(2025, 10, 15), new DateOnly(2025, 12, 15), null),
            new Voertuig(182, "Fendt", "Opal", "UV-567-WX", "Black", 2022, "Caravan", "", "Verhuurbaar", 56.00, new DateOnly(2025, 11, 20), new DateOnly(2026, 1, 20), null),
            new Voertuig(183, "Knaus", "Sky Traveller", "YZ-890-AB", "Green", 2017, "Caravan", "", "Verhuurbaar", 50.50, new DateOnly(2025, 12, 5), new DateOnly(2026, 2, 5), null),
            new Voertuig(184, "Hobby", "Pres-ge", "CD-123-EF", "Gray", 2018, "Caravan", "", "Verhuurbaar", 49.00, new DateOnly(2025, 1, 10), new DateOnly(2025, 3, 10), null)
            
            
            );
        }
    }
}