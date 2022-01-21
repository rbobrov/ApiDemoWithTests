using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace TddApiDemoTest
{
    public class APITest
    {
        [Fact]
        public async void TestHelloAPIRequest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                });

            var client = application.CreateClient();
            var responseHTML = await client.GetAsync("/");
            var contents = await responseHTML.Content.ReadAsStringAsync();

            Assert.Equal("<div>Hello world!</div>", contents);
        }

        [Theory]
        [InlineData(1,2)]
        public async void TestGetById(int requestedId, int returnedId)
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                });

            var client = application.CreateClient();
            var responseHTML = await client.GetAsync($"/{requestedId}");
            var contents = await responseHTML.Content.ReadAsStringAsync();

            Assert.Equal($"ÈÄ={returnedId}", contents);
        }
    }
}