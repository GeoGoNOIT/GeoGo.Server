using GeoGo.Server.Features.Games.Models;
using GeoGo.Server.Infrastructure.Extensions;

namespace GeoGo.Server.Features.Games
{
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class GamesController : ApiController
    {
        private readonly IGameService gameService;


        public GamesController(IGameService gameService) => this.gameService = gameService;
        
        [HttpGet]
        public async Task<IEnumerable<GameListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.gameService.ByUser(userId);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GameDetailsServiceModel>> Details(int id) 
            => await this.gameService.Details(id);

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

        [HttpPut]
        public async Task<ActionResult> Update(UpdateGameRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this.gameService.Update(
                model.Id, 
                model.Title, 
                model.Description, 
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
