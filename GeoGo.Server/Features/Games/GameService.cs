using GeoGo.Server.Data;
using GeoGo.Server.Data.Models;
using GeoGo.Server.Features.Games.Models;
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

        public async Task<bool> Update(int id, string title, string description, string userId)
        {
            var game = await this.data
                .Games
                .Where(g => g.Id == id && g.UserId == userId)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return false;
            }

            game.Title = title;
            game.Description = description;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GameListingServiceModel>> ByUser(string? userId) 
            => await this.data
                .Games
                .Where(g => g.UserId == userId)
                .Select(g => new GameListingServiceModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl
                })
                .ToListAsync();

        public async Task<GameDetailsServiceModel> Details(int id)
            => await this.data
                .Games
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsServiceModel
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    UserName = g.User.UserName
                })
                .FirstOrDefaultAsync();

    }
}
