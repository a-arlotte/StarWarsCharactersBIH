using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using StarWarsApi.Services;
using System;

namespace StarWarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;
    private readonly Api _apiSettings;
    private IPeopleService _peopleService;

    public ReviewController(ILogger<PeopleController> logger, IOptions<Api> options, IPeopleService peopleService)
    {
        _logger = logger;
        _apiSettings = options.Value;
        _peopleService = peopleService;
    }

    [HttpGet]
    public async Task<ApiResult<bool>> ReviewCharacter()
    {
        var transactionId = Guid.NewGuid().ToString();
        try
        {
            // code would go here...

            // for now, throw error
            throw new NotImplementedException();
        }
        catch (NotImplementedException ex)
        {
            var errors = new List<string>();
            errors.Add(ex.Message);
            var logMessage = $"TransactionId: {transactionId} Error getting data from endpoint {Endpoints.People}";
            errors.Add(logMessage);
            _logger.LogError(ex, logMessage);
            var result = ApiResult<bool>.Failure(errors);
            return await Task.FromResult(result);
        }
    }
}