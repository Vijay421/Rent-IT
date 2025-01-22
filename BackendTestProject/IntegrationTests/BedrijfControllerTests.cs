using backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using backend.Controllers;
using System.Net.Http.Json;
using backend.Data;
using backend.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static BackendTestProject.MockUtils;
using Microsoft.AspNetCore.Identity;
using Moq;
using backend.Models.Rollen;
using backend.Rollen;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        public async Task Example_Integration_Test()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Voertuig");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
