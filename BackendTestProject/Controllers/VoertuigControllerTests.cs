using backend.Controllers;
using backend.Data;
using backend.Models;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using static BackendTestProject.MockUtils;

namespace BackendTestProject.Controllers
{
    public class VoertuigControllerTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<RentalContext> _contextOptions;
        private List<Voertuig> _voertuigen;

        public VoertuigControllerTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<RentalContext>()
            .UseSqlite(_connection)
            .Options;


            using var context = new RentalContext(_contextOptions, null, null);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _voertuigen = new List<Voertuig>()
            {
                new Voertuig(1, "Toyota", "Corolla", "AB-123-CD", "Red", 2018, "Auto", "", "Verhuurbaar", 50.00),
                new Voertuig(2, "Ford", "Focus", "EF-456-GH", "Blue", 2019, "Auto", "", "Verhuurbaar", 51.39),
                new Voertuig(3, "Volkswagen", "Golf", "IJ-789-KL", "Black", 2020, "Auto", "", "Verhuurbaar", 40.00),
                new Voertuig(105, "Citroën", "Jumper", "QR-345-ST", "Gray", 2021, "Camper", "", "Verhuurbaar", 65.00),
                new Voertuig(106, "Peugeot", "Boxer", "UV-678-WX", "Black", 2016, "Camper", "", "Verhuurbaar", 68.00),
                new Voertuig(185, "Dethle-s", "C'go", "GH-456-IJ", "Blue", 2020, "Caravan", "", "Verhuurbaar", 52.50),
                new Voertuig(186, "Burstner", "Premio Life", "KL-789-MN", "Red", 2017, "Caravan", "", "Verhuurbaar", 48.00)
            };

            context.Voertuigen.AddRange(_voertuigen);
            context.SaveChanges();
        }

        private RentalContext _createContext() => new RentalContext(_contextOptions, null, null);

        [Fact]
        public async Task GetAllCars_ShouldReturnAllVoertuigen_WhenUserIsParticuliereUser()
        {
            // Arrange
            var user = CreateMockUser("particuliere_huurder");
            var controller = new VoertuigController(_createContext(), null)
            {
                ControllerContext = CreateMockControllerContext(user),
            };

            // Act
            var voertuigen = await controller.GetAllCars();

            // Assert
            Assert.Equal(voertuigen.Count, _voertuigen.Count);
        }

        [Fact]
        public async Task GetAllCars_ShouldReturnCarsOnly_WhenUserIsZakelijkeUser()
        {
            // Arrange
            var user = CreateMockUser("zakelijke_huurder");
            var controller = new VoertuigController(_createContext(), null)
            {
                ControllerContext = CreateMockControllerContext(user),
            };

            // Act
            var voertuigen = await controller.GetAllCars();

            // Assert
            var areAllCars = voertuigen.All(v => v.Soort == "Auto");

            Assert.True(areAllCars, "Some vehicles weren't cars");
        }

        [Fact]
        public async Task GetOneCar_ShouldReturnTheCorrectVoertuig_WhenGivenItsId()
        {
            // Arrange
            var user = CreateMockUser("particuliere_huurder");
            var controller = new VoertuigController(_createContext(), null)
            {
                ControllerContext = CreateMockControllerContext(user),
            };
            var voertuigId = 1;

            // Act
            var voertuig = await controller.GetOneCar(voertuigId);

            // Assert
            Assert.NotNull(voertuig);
            Assert.Equal(voertuig.Value.Id, voertuigId);
        }

        [Fact]
        public async Task GetOneCar_ShouldReturnNotFoundResult_WhenNoIdCorrespondsWithTheGivenId()
        {
            // Arrange
            var user = CreateMockUser("particuliere_huurder");
            var controller = new VoertuigController(_createContext(), null)
            {
                ControllerContext = CreateMockControllerContext(user),
            };
            var voertuigId = -1;

            // Act
            var actionResult = await controller.GetOneCar(voertuigId);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}
