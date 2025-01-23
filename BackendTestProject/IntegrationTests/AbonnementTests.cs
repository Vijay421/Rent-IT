using Microsoft.AspNetCore.Mvc.Testing;
using backend;
using backend.DTOs;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net;
using backend.Models;

namespace BackendTestProject.IntegrationTests
{
    public class AbonnementTests : IClassFixture<AppFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AbonnementTests(AppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task AbonnementController_AddRentersToSubscription()
        {
            // Arrange
            var client = _factory.CreateClient();

            var huurbeheerderId = 1;

            var bedrijf = new CreateBedrijfDTO { BedrijfsNaam = "test-bedrijf", Address = "Test address", KvK_nummer = 111111111111, PhoneNumber = "42432432432", Domein = "test.com", UserName = "test-bedrijf", Email = "test@test.com", Password = "Qwerty123!", };
            var beheerder = new CreateHuurbeheerderDTO { Name = "test-beheerder", Email = "beheer@mock.com", Password = "Qwerty123!", PhoneNumber = "432423432", Bedrijfsrol = "voertuigbeheerder", };
            var abonnement = new CreateAbonnementDTO { Naam = "test-abonnement", Max_huurders = 10, Startdatum = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), Einddatum = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), Soort = "prepaid" };
            var huurder = new CreateZakelijkeHuurderDTO { Name = "test-huurder", Email = "huurder@test.com", Password = "Qwerty123!", PhoneNumber = "4324232", Address = "Een test adres", Factuuradres = "Test factuur adres", HuurbeheerderId = huurbeheerderId };

            // Act
            var bedrijfCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf", bedrijf);
            var loginBedrijfResponse = await client.PostAsJsonAsync("/auth/login?useCookies=true&useSessionCookies=true", new
            {
                Email = "test-bedrijf",
                Password = "Qwerty123!",
            });
            var BeheerderCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf/zakelijke_beheerder", beheerder);
            var zakelijkeHuurdersCreateResponse = await client.PostAsJsonAsync("/api/Bedrijf/zakelijke_huurder", huurder);

            var loginBeheerderResponse = await client.PostAsJsonAsync("/auth/login?useCookies=true&useSessionCookies=true", new
            {
                Email = "test-beheerder",
                Password = "Qwerty123!",
            });
            var abonnementCreateResponse = await client.PostAsJsonAsync("/api/Abonnement", abonnement);
            var createdAbonnement = await abonnementCreateResponse.Content.ReadFromJsonAsync<Abonnement>();

            var rentersGetResponse = await client.GetAsync("/api/User/huurders");
            var userDTOs = await rentersGetResponse.Content.ReadFromJsonAsync<List<UserDTO>>();
            var renters = userDTOs.Select(u => u.Id);

            var abonnementPutRentersResponse = await client.PutAsJsonAsync($"/api/Abonnement/renters/{createdAbonnement.Id}", renters);

            // Assert
            Assert.Equal(HttpStatusCode.Created, abonnementCreateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NoContent, abonnementPutRentersResponse.StatusCode);
        }
    }
}
