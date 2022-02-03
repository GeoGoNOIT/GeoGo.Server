namespace GeoGo.Server.Features.Games
{
    using Models;

    public interface IGameService
    {
        Task<int> Create(string imageUrl, string title, string description, string? userId);

        Task<bool> Update(int id, string title, string description, string userId);

        Task<bool> Delete(int id, string userId);

        Task<IEnumerable<GameListingServiceModel>> ByUser(string? userId);

        Task<GameDetailsServiceModel> Details(int id);
    }
}
