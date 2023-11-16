using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Infrastructure.Persistence.Configurations;

public sealed class PostTagEntityConfiguration : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.HasKey(x => x.Id);

        builder.Property<Guid?>("PostId");
        builder.Property<Guid>("TagId").IsRequired();
        builder.HasOne(x => x.Post).WithOne().HasForeignKey<Message>("PostId");
        builder.HasOne(x => x.Tag).WithOne().HasForeignKey<Message>("UserId").IsRequired();
        builder.Navigation(x => x.Post).UsePropertyAccessMode(PropertyAccessMode.Property);
        builder.Navigation(x => x.Tag).UsePropertyAccessMode(PropertyAccessMode.Property);
    }

}