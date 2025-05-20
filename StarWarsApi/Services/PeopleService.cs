using Microsoft.Extensions.Options;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace StarWarsApi.Services
{
    public class PeopleService(IHttpClientFactory factory, ILogger<PeopleService> logger, IOptions<Api> options) : IPeopleService
    {

        private readonly Api apiSettings = options.Value;

        private readonly HttpClient httpClient = factory.CreateClient();

        public async Task<List<People>> GetPeople()
        {
            var transactionId = Guid.NewGuid().ToString();
            try
            {
                var url = $"{apiSettings.BaseUrl}{Endpoints.People}";
                logger.LogInformation(url);
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // throws if status code is not 2xx

                var content = await response.Content.ReadAsStringAsync();
                if (content == null)
                {
                    return new List<People>();

                }
                // deserialize
                var result = JsonSerializer.Deserialize<List<People>>(content);
                if (result == null)
                {
                    return new List<People>();

                }
                return result.Select((item, index) => new People
                {
                    Id = index + 1,       // Generate ID from index (starting at 1)
                    Name = item.Name,
                    Height = item.Height,
                    Mass = item.Mass,
                    SkinColour = item.SkinColour,
                    BirthYear = item.BirthYear,
                    Gender = item.Gender
                })
                    .ToList();
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, $"TransactionId: {transactionId} Error getting data from endpoint {Endpoints.People}");
                return new List<People>();
            }
        }
    }
}
