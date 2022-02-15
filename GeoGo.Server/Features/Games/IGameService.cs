using GeoGo.Server.Infrastructure.Services;

namespace GeoGo.Server.Features.Games
{
    using Models;

    public interface IGameService
    {
        Task<int> Create(string imageUrl, string title, string description, string? userId);

        Task<Result> Update(int id, string title, string description, string userId);

        Task<Result> Delete(int id, string userId);

        Task<IEnumerable<GameListingServiceModel>> ByUser(string? userId);

        Task<GameDetailsServiceModel> Details(int id);
    }
}
