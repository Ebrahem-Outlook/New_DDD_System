using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_DDD_System.Domain.Users;

namespace New_DDD_System.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "NewUsers_1");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
               .HasColumnName(nameof(User.FirstName))            
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.FirstName)
               .HasColumnName(nameof(User.FirstName))
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.LastName)
               .HasColumnName(nameof(User.LastName))
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.Email)
               .HasColumnName(nameof(User.Email))
               .HasMaxLength(255)
               .IsRequired();

        builder.HasIndex(user => user.Email).IsUnique();

        builder.Property(user => user.Password)
               .HasColumnName(nameof(User.Password))
               .HasMaxLength(255)
               .IsRequired();
    }
}
