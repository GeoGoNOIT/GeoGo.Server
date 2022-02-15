using GeoGo.Server.Infrastructure.Services;

namespace GeoGo.Server.Features.Profiles
{
    using Models;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string? userId);

        Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string profilePhotoUrl, 
            string bio, 
            string location);
    }
}
