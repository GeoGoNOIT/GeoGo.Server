using GeoGo.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GeoGo.Server.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<GeoGoDbContext>();

            dbContext?.Database.Migrate();
        }
    }
}
