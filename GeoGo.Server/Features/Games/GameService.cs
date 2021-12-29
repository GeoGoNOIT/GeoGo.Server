using GeoGo.Server.Data;
using GeoGo.Server.Data.Models;

namespace GeoGo.Server.Features.Games
{
    public class GameService: IGameService
    {
        private readonly GeoGoDbContext data;

        public GameService(GeoGoDbContext data) => this.data = data;

        public async Task<int> Create(string imageUrl, string title, string description, string userId)
        {
            var game = new Game()
            {
                Title = title,
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            this.data.Add(game);

            await this.data.SaveChangesAsync();

            return game.Id;
        }
    }
}
