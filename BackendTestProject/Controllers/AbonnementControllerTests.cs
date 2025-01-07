using backend.Controllers;
using backend.Data;
using backend.Models;
using backend.Rollen;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static BackendTestProject.MockUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace BackendTestProject.Controllers
{
    public class AbonnementControllerTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<RentalContext> _contextOptions;
        private User _huurbeheerder;
        private RentalContext _context;
        private Mock<UserManager<User>> _mockUserManager;

        public AbonnementControllerTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<RentalContext>()
            .UseSqlite(_connection)
            .Options;

            using var _context = new RentalContext(_contextOptions, null, null);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var bedrijf = new Bedrijf { Name = "Google LLC", Address = "Claude Debussylaan Etage, Md, Amsterdam 1082 15E 34", KvK_nummer = 34198589, PhoneNumber = "423432423", Domein = "google.com", };
            _context.Bedrijven.Add(bedrijf);
            _context.SaveChanges();

            var huurbeheerder = new Huurbeheerder { Id = 1, Bedrijfsrol = "Voertuigmanager", Bedrijf = bedrijf };
            _context.Huurbeheerders.Add(huurbeheerder);
            _context.SaveChanges();

            _huurbeheerder = new User { Id = "1", Huurbeheerder = huurbeheerder };
            _context.Users.Add(_huurbeheerder);
            _context.SaveChanges();

            var zakelijkeHuurder1 = new ZakelijkeHuurder { Id = 1, HuurbeheerderId = 1, Factuuradres = "address" };
            var zakelijkeHuurder2 = new ZakelijkeHuurder { Id = 2, HuurbeheerderId = 1, Factuuradres = "address" };
            _context.ZakelijkeHuurders.Add(zakelijkeHuurder1);
            _context.ZakelijkeHuurders.Add(zakelijkeHuurder2);
            _context.SaveChanges();

            _context.Users.Add(new User { Id = "2", Email = "zuser2@google.com", ZakelijkeHuurder = zakelijkeHuurder1 });
            _context.Users.Add(new User { Id = "3", Email = "zuser2@otherCompany.com", ZakelijkeHuurder = zakelijkeHuurder2 });
            _context.Abonnementen.Add(new Abonnement { Id = 1, HuurbeheerderId = 1, Naam = "A name", Prijs_per_maand = 50.0, Max_huurders = 20, Einddatum = new DateOnly(9999, 1, 1), Soort = "prepaid" });
            _context.SaveChanges();

            var store = new Mock<IUserStore<User>>();
            _mockUserManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => _huurbeheerder);
        }

        private RentalContext _createContext() => new RentalContext(_contextOptions, null, null);

        [Fact]
        public async Task UpdateRenters_ShouldAddRentersToSubscription_WhenAValidUserIsProvided()
        {
            // Arrange
            var controller = new AbonnementController(_createContext(), _mockUserManager.Object)
            {
                ControllerContext = CreateMockControllerContext("zakelijke_beheerder", "1"),
            };

            // Act
            var actionResult = await controller.UpdateRenters(1, ["2"]);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task UpdateRenters_ShouldNotAddRentersToSubscription_WhenTheRenterDoesNotBelongToTheCompanyOfTheZakelijkeBeheerder()
        {
            // Arrange
            var controller = new AbonnementController(_createContext(), _mockUserManager.Object)
            {
                ControllerContext = CreateMockControllerContext("zakelijke_beheerder", "1"),
            };

            // Act
            var actionResult = await controller.UpdateRenters(1, ["3"]);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
    }
}
