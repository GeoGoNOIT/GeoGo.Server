using GeoGo.Server.Data.Models;
using GeoGo.Server.Data.Models.Base;
using GeoGo.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeoGo.Server.Data
{
    public class GeoGoDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public GeoGoDbContext(
            DbContextOptions<GeoGoDbContext> options, 
            ICurrentUserService currentUser)
            : base(options) 
            => this.currentUser = currentUser;

        public DbSet<Game> Games { get; set; }
        
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .HasQueryFilter(g => !g.IsDeleted)
                .HasOne(g => g.Creator)
                .WithMany(u => u.CreatedGames)
                .HasForeignKey(g => g.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasQueryFilter(g => !g.IsDeleted)
                .HasOne(g => g.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Location>()
                .HasQueryFilter(l => !l.IsDeleted)
                .HasOne(l => l.Address)
                .WithMany(a => a.Locations)
                .HasForeignKey(l => l.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Clue>()
                .HasQueryFilter(c => !c.IsDeleted)
                .HasOne(c => c.Riddle)
                .WithMany(r => r.Clues)
                .HasForeignKey(c => c.RiddleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Stage>()
                .HasQueryFilter(s => !s.IsDeleted)
                .HasOne(s => s.Riddle)
                .WithMany(r => r.Stages)
                .HasForeignKey(s => s.RiddleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Stage>()
                .HasQueryFilter(s => !s.IsDeleted)
                .HasOne(s => s.Location)
                .WithMany(l => l.Stages)
                .HasForeignKey(s => s.RiddleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Stage>()
                .HasQueryFilter(s => !s.IsDeleted)
                .HasOne(s => s.Game)
                .WithMany(g => g.Stages)
                .HasForeignKey(s => s.RiddleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Feedback>()
                .HasQueryFilter(f => !f.IsDeleted)
                .HasOne(f => f.Game)
                .WithMany(g => g.Feedbacks)
                .HasForeignKey(f => f.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Feedback>()
                .HasQueryFilter(f => !f.IsDeleted)
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation() 
            => this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    var userName = this.currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;

                            return;
                        }
                    }
                    
                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }
                });
    }
}