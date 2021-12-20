using Microsoft.AspNetCore.Authorization;

namespace GeoGo.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    public class HomeController : ApiController
    {
        [Authorize]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}