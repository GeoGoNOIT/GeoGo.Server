namespace GeoGo.Server.Features.Games
{
    using Data;
    using GeoGo.Server.Data.Models;
    using Models;
    using Microsoft.EntityFrameworkCore;
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
                CreatorId = userId,
            };

            this.data.Add(game);

            await this.data.SaveChangesAsync();

            return game.Id;
        }

        public async Task<bool> Update(int id, string title, string description, string userId)
        {
            var game = await this.ByIdAndByUserId(id, userId);

            if (game == null)
            {
                return false;
            }

            game.Title = title;
            game.Description = description;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var game = await this.ByIdAndByUserId(id, userId);

            if (game == null)
            {
                return false;
            }

            this.data.Games.Remove(game);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GameListingServiceModel>> ByUser(string? userId) 
            => await this.data
                .Games
                .Where(g => g.CreatorId == userId)
                .OrderByDescending(g => g.CreatedOn)
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
                    CreatorId = g.CreatorId,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    UserName = g.Creator.UserName
                })
                .FirstOrDefaultAsync();

        private async Task<Game?> ByIdAndByUserId(int id, string userId) 
            => await this.data
                .Games
                .Where(g => g.Id == id && g.CreatorId == userId)
                .FirstOrDefaultAsync();
    }
}
