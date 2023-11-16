using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Human.Core.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<UserPasswordResetToken> UserPasswordResetTokens { get; }
    DbSet<UserPermission> UserPermissions { get; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; }
    DbSet<Message> Messages { get; }
    DbSet<Post> Posts { get; }
    DbSet<PostTag> PostTags { get; }
    DbSet<Tag> Tags { get; }
    EntityEntry Attach(object entity);
    EntityEntry Add(object entity);
    EntityEntry Update(object entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
