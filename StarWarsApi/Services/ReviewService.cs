using Microsoft.Extensions.Options;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using System.Text.Json;

namespace StarWarsApi.Services
{
    public class ReviewService(IHttpClientFactory factory, ILogger<PeopleService> logger, IOptions<Api> options) : IReviewService
    {

        private readonly Api apiSettings = options.Value;

        private readonly HttpClient httpClient = factory.CreateClient();

        public async Task<bool?> ReviewCharacter()
        {
            var transactionId = Guid.NewGuid().ToString();
            try
            {
                // code will go here for submitting a review...

                // for now, throw an error#
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"TransactionId: {transactionId} Error getting data from endpoint /review");                
                return await Task.FromResult<bool?>(null);
            }
        }
    }
}
