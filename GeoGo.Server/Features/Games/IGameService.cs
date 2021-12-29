namespace GeoGo.Server.Features.Games
{
    public interface IGameService
    {
        public Task<int> Create(string imageUrl, string title, string description, string userId);
    }
}
