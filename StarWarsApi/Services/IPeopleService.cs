using StarWarsApi.Models;

namespace StarWarsApi.Services
{
    public interface IPeopleService
    {
        Task<List<People>> GetPeople();
    }
}
