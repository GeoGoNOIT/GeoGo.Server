using GeoGo.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoGo.Server.Data
{
    public class GeoGoDbContext : IdentityDbContext<User>
    {
        public GeoGoDbContext(DbContextOptions<GeoGoDbContext> options)
            : base(options)
        {
        }
    }
}