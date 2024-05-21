
using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FacebookUrl)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.InstagramUrl)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.TwitterUrl)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.PositionID);
        }
    }
}
