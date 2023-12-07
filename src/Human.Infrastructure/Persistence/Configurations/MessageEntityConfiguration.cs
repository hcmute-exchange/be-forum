using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Infrastructure.Persistence.Configurations;

public sealed class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.UpdatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp");

        builder.Property(x => x.Body).IsRequired();
        builder.Property<Guid?>("PostId").IsRequired(false);
        builder.Property<Guid>("UserId").IsRequired();
        builder.HasOne(x => x.Post).WithMany().HasForeignKey("PostId");
        builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId").IsRequired();
        builder.HasGeneratedTsVectorColumn(
           p => p.SearchVector,
           "english",  // Text search config
           p => p.Body)  // Included properties
       .HasIndex(p => p.SearchVector)
       .HasMethod("GIN");
        // builder.Navigation(x => x.Post).UsePropertyAccessMode(PropertyAccessMode.Property);
        // builder.Navigation(x => x.User).UsePropertyAccessMode(PropertyAccessMode.Property);
    }

}