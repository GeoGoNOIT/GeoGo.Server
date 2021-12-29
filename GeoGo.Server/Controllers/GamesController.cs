using GeoGo.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoGo.Server.Controllers
{
    public class GamesController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGameRequestModel model)
        {

        }
    }
}
