using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Infrastructure.Persistence.Configurations;

public sealed class VoteEntityConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey("UserId", "MessageId");

        builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.UpdatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.Weight).IsRequired();

        builder.Property<Guid>("UserId").IsRequired();
        builder.Property<Guid>("MessageId").IsRequired();
        builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId").IsRequired();
        builder.HasOne(x => x.Message).WithMany(x => x.Votes).HasForeignKey("MessageId").IsRequired();
    }

}