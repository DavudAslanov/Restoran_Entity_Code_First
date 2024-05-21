using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Rezervation>
    {
        public void Configure(EntityTypeBuilder<Rezervation> builder)
        {
            builder.ToTable("Reservations");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.CustomerName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ReservationDate)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.PeopleCount)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.Iscontacted)
                .HasDefaultValue(0);

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => new { x.Email, x.Deleted })
                .IsUnique();
        }
    }
}
