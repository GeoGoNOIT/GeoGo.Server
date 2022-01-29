using GeoGo.Server.Data;
using GeoGo.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoGo.Server.Features.Games
{
    public class GameService: IGameService
    {
        private readonly GeoGoDbContext data;

        public GameService(GeoGoDbContext data) => this.data = data;

        public async Task<int> Create(string imageUrl, string title, string description, string? userId)
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

        public async Task<IEnumerable<GameListingResponseModel>> ByUser(string? userId) 
            => await this.data
                .Games
                .Where(g => g.UserId == userId)
                .Select(g => new GameListingResponseModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl
                })
                .ToListAsync();
    }
}
