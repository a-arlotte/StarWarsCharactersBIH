using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarWarsApi.Constants;
using StarWarsApi.Models;
using System;

namespace StarWarsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PeopleController> _logger;

    private readonly Api apiSettings;
    private readonly HttpClient _httpClient;

    public PeopleController(ILogger<PeopleController> logger, HttpClient httpClient, IOptions<Api> options)
    {
        _logger = logger;
        _httpClient = httpClient;
        apiSettings = options.Value;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var transactionId = Guid.NewGuid().ToString();
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Endpoints.People);
            response.EnsureSuccessStatusCode(); // throws if status code is not 2xx

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"TransactionId: {transactionId} Error getting data from endpoint {Endpoints.People}");
            return StatusCode(500, $"Error calling external API: {ex.Message}");
        }
    }
}