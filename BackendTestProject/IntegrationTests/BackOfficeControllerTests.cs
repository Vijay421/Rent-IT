using Microsoft.AspNetCore.Mvc.Testing;
using backend;
using System.Net.Http.Json;
using backend.Models.Rollen;
using backend.DTOs;
using backend.Models;
using System.Net;

namespace BackendTestProject.IntegrationTests
{
    public class BackOfficeControllerTests : IClassFixture<AppFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BackOfficeControllerTests(AppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task BackOfficeController_ShouldReviewARequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var loginResponse = await client.PostAsJsonAsync("/auth/login?useCookies=true&useSessionCookies=true", new
            {
                Email = "b-user",
                Password = "Qwerty123!",
            });
            var aanvraagGetResponse = await client.GetAsync("/api/BackOffice/huuraanvragen");
            var aanvragen = await aanvraagGetResponse.Content.ReadFromJsonAsync<List<Huuraanvraag>>();
            var aanvraag = aanvragen.First();
            var beoordeling = new HuuraanvraagBeoordelingDTO { Beoordeling = true, Reden = null };

            // Act
            var beoordeelResponse = await client.PutAsJsonAsync($"/api/BackOffice/huuraanvragen-beoordelen/{aanvraag.Id}", beoordeling);
            var newAanvraagGetResponse = await client.GetAsync("/api/BackOffice/huuraanvragen");

            // Assert
            Assert.Equal(HttpStatusCode.Created, beoordeelResponse.StatusCode);

            var newAanvragen = await newAanvraagGetResponse.Content.ReadFromJsonAsync<List<Huuraanvraag>>();
            var didReview = newAanvragen.Any(a => a.Geaccepteerd == true);
            Assert.True(didReview);
        }
    }
}
