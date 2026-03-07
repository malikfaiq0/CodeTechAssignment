using CodeTechAssignment.Application.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace CodeTechAssignment.API.Tests
{
    public class ValidationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ValidationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task RegisterUser_WithEmptyMobile_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new RegisterUserDto
            {
                MobileNumber = "", // Empty - Invalid
                FullName = "Test User",
                Cnic = "1234567890123",
                OtpCode = "1234"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/User/register", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task RegisterUser_WithInvalidOtpLength_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new RegisterUserDto
            {
                MobileNumber = "1234567890",
                FullName = "Test User",
                Cnic = "1234567890123",
                OtpCode = "12" // Invalid Length
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/User/register", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
