using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post = Human.Domain.Models.Post;

namespace Human.Infrastructure.Persistence.Configurations;

public sealed class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.UpdatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");

        builder.Property(x => x.Subject).HasMaxLength(128).IsRequired();
        builder.Property<Guid>("InitialMessageId").IsRequired();
        builder.HasOne(x => x.InitialMessage).WithOne().HasForeignKey<Post>("InitialMessageId").IsRequired();
        builder.Navigation(x => x.InitialMessage).UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}