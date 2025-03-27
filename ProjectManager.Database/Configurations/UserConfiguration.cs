using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id)
                .HasName("id");

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id");

            builder.Property(x => x.Login)
                .HasMaxLength(250)
                .HasColumnName("login");

            builder.Property(x => x.Password)
                .HasMaxLength(250)
                .HasColumnName("password");

            builder.Property(x => x.Email)
                .HasMaxLength(250)
                .HasColumnName("email");

            builder.HasMany(x => x.Projects)
                .WithOne(x => x.Owner);
        }
    }
}
