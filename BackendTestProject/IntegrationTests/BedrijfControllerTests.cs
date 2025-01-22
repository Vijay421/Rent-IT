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
            var bedrijf = new CreateBedrijfDTO
            {
                BedrijfsNaam = "mock-bedrijf",
                Address = "Mock address",
                KvK_nummer = 111111111111,
                PhoneNumber = "42432432432",
                Domein = "mock.com",
                UserName = "mock-bedrijf",
                Email = "mock@mock.com",
                Password = "Qwerty123!",
            };
            var beheerder = new CreateHuurbeheerderDTO
            {
                Name = "mock-beheerder",
                Email = "beheer@mock.com",
                Password = "Qwerty123!",
                PhoneNumber = "432423432",
                Bedrijfsrol = "voertuigbeheerder",
            };

            // Act
            var bedrijfCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf", bedrijf);
            var loginResponse = await client.PostAsJsonAsync("/auth/login?useCookies=true&useSessionCookies=true", new
            {
                Email = "mock-bedrijf",
                Password = "Qwerty123!",
            });
            var zakelijkeHuurderCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf/zakelijke_beheerder", beheerder);

            var zakelijkeHuurdersGetResponse = await client.GetAsync("/api/Bedrijf/zakelijke_beheerders");
            var zakelijkeHuurders = await zakelijkeHuurdersGetResponse.Content.ReadFromJsonAsync<List<GetBeheerderDTO>>();

            // Assert
            Assert.Equal(HttpStatusCode.Created, bedrijfCreateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
            Assert.Equal(HttpStatusCode.Created, zakelijkeHuurderCreateResponse.StatusCode);

            Assert.Equal(HttpStatusCode.OK, zakelijkeHuurdersGetResponse.StatusCode);

            var containsCreatedHuurbeheerder = zakelijkeHuurders.Any(h => h.UserName == beheerder.Name);
            Assert.True(containsCreatedHuurbeheerder);
        }
    }
}
