using GeoGo.Server.Features.Games.Models;

namespace GeoGo.Server.Features.Games
{
    public interface IGameService
    {
        public Task<int> Create(string imageUrl, string title, string description, string? userId);

        public Task<bool> Update(int id, string title, string description, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<IEnumerable<GameListingServiceModel>> ByUser(string? userId);

        public Task<GameDetailsServiceModel> Details(int id);
    }
}
