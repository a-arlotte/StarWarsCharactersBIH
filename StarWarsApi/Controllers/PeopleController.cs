using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using StarWarsApi.Services;
using System;

namespace StarWarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;
    private readonly Api _apiSettings;
    private IPeopleService _peopleService;

    public PeopleController(ILogger<PeopleController> logger, IOptions<Api> options, IPeopleService peopleService)
    {
        _logger = logger;
        _apiSettings = options.Value;
        _peopleService = peopleService;
    }

    [HttpGet]
    public async Task<ApiResult<List<People>>> Get()
    {
        var transactionId = Guid.NewGuid().ToString();
        try
        {
            var people = await _peopleService.GetPeople();
            return ApiResult<List<People>>.SuccessResult(people);
        }
        catch (HttpRequestException ex)
        {
            var errors = new List<string>();
            errors.Add(ex.Message);
            var logMessage = $"TransactionId: {transactionId} Error getting data from endpoint {Endpoints.People}";
            errors.Add(logMessage);
            _logger.LogError(ex, logMessage);
            return ApiResult<List<People>>.Failure(errors);
        }
    }
}