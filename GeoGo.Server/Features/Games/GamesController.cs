namespace GeoGo.Server.Features.Games
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Infrastructure.Services;

    using static Infrastructure.WebConstants;

    [Authorize]
    public class GamesController : ApiController
    {
        private readonly IGameService games;
        private readonly ICurrentUserService currentUser;
        
        public GamesController(
            IGameService games, 
            ICurrentUserService currentUser)
        {
            this.games = games;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<GameListingServiceModel>> Mine() 
            => await this.games.ByUser(this.currentUser.GetId());

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<GameDetailsServiceModel>> Details(int id) 
            => await this.games.Details(id);

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGameRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.games.Create(
                model.ImageUrl, 
                model.Title, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id, UpdateGameRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.games.Update(
                id, 
                model.Title, 
                model.Description, 
                userId);

            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var result = await this.games.Delete(id, userId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
