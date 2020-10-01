using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using XmlIntegrationTest;
using Xunit;

namespace IntegrationTests
{
    public class XmlPostTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public XmlPostTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostXml()
        {
            var data = "<Foo xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"  xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Date>2020-01-01</Date><Summary>Some text</Summary></Foo>";

            var request = new HttpRequestMessage(HttpMethod.Post, "/Foo")
            {
                Content = new StringContent(data, Encoding.UTF8, "application/xml")
            };

            var response = await _client.SendAsync(request);
        }
    }
}
