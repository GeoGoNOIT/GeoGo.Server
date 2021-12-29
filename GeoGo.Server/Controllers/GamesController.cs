using GeoGo.Server.Data;
using GeoGo.Server.Data.Models;

namespace GeoGo.Server.Controllers
{
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cats;

    public class GamesController : ApiController
    {
        private readonly GeoGoDbContext data;

        public GamesController(GeoGoDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGameRequestModel model)
        {
            var userId = this.User.GetId();

            var game = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId,
            };

            this.data.Add(game);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), game.Id);
        }
    }
}
