using GeoGo.Server.Data.Models;
using GeoGo.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GeoGo.Server.Features.Profiles
{
    using Data;
    using Models;

    public class ProfileService : IProfileService
    {
        private readonly GeoGoDbContext data;

        public ProfileService(GeoGoDbContext data) => this.data = data;

        public async Task<ProfileServiceModel> ByUser(string? userId)
            => await this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileServiceModel
                {
                    Location = u.Profile.Location,
                    Bio = u.Profile.Bio,
                    ProfilePhotoUrl = u.Profile.ProfilePhotoUrl
                })
                .FirstOrDefaultAsync();

        public async Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string profilePhotoUrl, 
            string bio, 
            string location)
        {
            var user = await this.data
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return "User does not exist.";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }

            var result = await this.ChangeProfileEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            if (user.UserName != userName)
            {
                user.UserName = userName;
            }

            this.ChangeProfile(
                user.Profile,
                profilePhotoUrl, 
                bio, 
                location);

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeProfileEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "The provided email is already taken.";
                }

                user.Email = email;
            }

            return true;
        }

        private void ChangeProfile(
            Profile profile,
            string profilePhotoUrl,
            string bio,
            string location)
        {
            

            if (profile.ProfilePhotoUrl != profilePhotoUrl)
            {
                profile.ProfilePhotoUrl = profilePhotoUrl;
            }

            if (profile.Bio != bio)
            {
                profile.Bio = bio;
            }

            if (profile.Location != location)
            {
                profile.Location = location;
            }
        }
    }
}
