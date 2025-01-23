using backend;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using backend.DTOs;
using System.Net;

namespace BackendTestProject.IntegrationTests
{
    public class BedrijfControllerTests : IClassFixture<AppFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BedrijfControllerTests(AppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task BedrijfController_AddZakelijkeBeheerderAndHuurderToCompany()
        {
            // Arrange
            var client = _factory.CreateClient();
            var bedrijf = new CreateBedrijfDTO { BedrijfsNaam = "test-bedrijf", Address = "Test address", KvK_nummer = 111111111111, PhoneNumber = "42432432432", Domein = "test.com", UserName = "test-bedrijf", Email = "test@test.com", Password = "Qwerty123!", };
            var beheerder = new CreateHuurbeheerderDTO { Name = "test-beheerder", Email = "beheer@test.com", Password = "Qwerty123!", PhoneNumber = "432423432", Bedrijfsrol = "voertuigbeheerder", };
            /*var huurder = new CreateZakelijkeHuurderDTO { Name = "test-huurder", Email = "huurder@test.com", Password = "Qwerty123!", PhoneNumber = "4324232", Address = "Een test adres", Factuuradres = "Test factuur adres", HuurbeheerderId = 1 };*/

            // Act
            var bedrijfCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf", bedrijf);
            var loginResponse = await client.PostAsJsonAsync("/auth/login?useCookies=true&useSessionCookies=true", new
            {
                Email = "test-bedrijf",
                Password = "Qwerty123!",
            });
            var BeheerderCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf/zakelijke_beheerder", beheerder);
            var beheerderDTO = await BeheerderCreateResponse.Content.ReadFromJsonAsync<UserDTO>();
            Assert.NotNull(beheerderDTO);
            Assert.NotNull(beheerderDTO.HuurbeheederId);

            var huurder = new CreateZakelijkeHuurderDTO { Name = "test-huurder", Email = "huurder@test.com", Password = "Qwerty123!", PhoneNumber = "4324232", Address = "Een test adres", Factuuradres = "Test factuur adres", HuurbeheerderId = (int) beheerderDTO.HuurbeheederId };
            var zakelijkeHuurdersCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf/zakelijke_huurder", huurder);

            var zakelijkeHuurdersGetResponse = await client.GetAsync("/api/Bedrijf/zakelijke_beheerders");
            var zakelijkeHuurders = await zakelijkeHuurdersGetResponse.Content.ReadFromJsonAsync<List<GetBeheerderDTO>>();

            // Assert
            Assert.Equal(HttpStatusCode.Created, bedrijfCreateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
            Assert.Equal(HttpStatusCode.Created, BeheerderCreateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.Created, zakelijkeHuurdersCreateResponse.StatusCode);

            Assert.Equal(HttpStatusCode.OK, zakelijkeHuurdersGetResponse.StatusCode);

            var containsCreatedHuurbeheerder = zakelijkeHuurders.Any(h => h.UserName == beheerder.Name);
            Assert.True(containsCreatedHuurbeheerder);
        }
    }
}
