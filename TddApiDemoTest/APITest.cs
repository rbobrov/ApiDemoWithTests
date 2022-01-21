using System.Net.Http;
using Xunit;

namespace TddApiDemoTest
{
    public class APITest
    {
        [Fact]
        public async void TestHelloAPIRequest()
        {
            var client = new HttpClient();
            var responseHTML = await client.GetAsync("http://localhost:5000");
            var contents = await responseHTML.Content.ReadAsStringAsync();

            Assert.Equal("<div>Hello world!</div>", contents);
        }
    }
}