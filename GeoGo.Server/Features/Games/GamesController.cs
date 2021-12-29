using GeoGo.Server.Data;
using GeoGo.Server.Data.Models;

namespace GeoGo.Server.Features.Games
{
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : ApiController
    {
        private readonly IGameService gameService;


        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGameRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this.gameService.Create(
                model.ImageUrl, 
                model.Title, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }
    }
}
