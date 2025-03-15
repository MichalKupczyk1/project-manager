using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Database.Entities;

namespace ProjectManager.Database.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");

            builder.HasKey(x => x.Id)
                .HasName("id");

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .HasColumnName("description");

            builder.Property(x => x.OwnerId)
                .HasColumnName("owner_id");

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.OwnerId);
        }
    }
}
