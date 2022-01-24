using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace TddApiDemoTest
{
    public class APITest
    {
        protected HttpClient _httpClient;
        public APITest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                });

            _httpClient = application.CreateClient();
        }

        [Fact]
        public async void TestHelloAPIRequest()
        {
            var responseHTML = await _httpClient.GetAsync("/");
            var contents = await responseHTML.Content.ReadAsStringAsync();

            Assert.Equal("Hello world!", contents);
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(34,35)]
        [InlineData(50,51)]
        public async void TestGetById(int requestedId, int returnedId)
        {
            var responseHTML = await _httpClient.GetAsync($"/{requestedId}");
            var contents = await responseHTML.Content.ReadAsStringAsync();

            Assert.Equal($"ÈÄ={returnedId}", contents);
        }
    }
}