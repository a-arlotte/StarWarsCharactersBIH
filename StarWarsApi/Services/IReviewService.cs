using StarWarsApi.Models;

namespace StarWarsApi.Services
{
    public interface IReviewService
    {
        Task<bool?> ReviewCharacter();
    }
}
