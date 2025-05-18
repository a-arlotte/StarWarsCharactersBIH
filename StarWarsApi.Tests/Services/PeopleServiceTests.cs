using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using StarWarsApi.Services;
using System.Net;
using System.Text.Json;

namespace StarWarsApi.Tests.Services
{
    [TestClass]
    public sealed class PeopleServiceTests
    {

        public PeopleService service { get; set; }

        // Mocks
        public Mock<IHttpClientFactory> factory;
        public Mock<ILogger<PeopleService>> logger;
        public Mock<IOptions<Api>> options;

        [TestInitialize]
        public void Setup()
        {
            factory = new Mock<IHttpClientFactory>();
            logger = new Mock<ILogger<PeopleService>>();
            options = new Mock<IOptions<Api>>();
        }

        [TestMethod]
        public async Task GetPeople_Success_ReturnsData()
        {
            // Arrange

            var data = new List<People>()
            {
                new People()
                {
                    Name = "Luke Skywalker"
                }
            };

            var api = new Api()
            {
                BaseUrl = "https://swapi.info/api/"
            };
            options.Setup(x => x.Value).Returns(api);


            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            handlerMock
               .Protected()
               // Setup the PROTECTED method SendAsync (which HttpClient calls internally)
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonSerializer.Serialize(data)),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(api.BaseUrl),
            };

            factory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            service = new PeopleService(factory.Object, logger.Object, options.Object);


            var result = await service.GetPeople();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);


        }
    }
}
