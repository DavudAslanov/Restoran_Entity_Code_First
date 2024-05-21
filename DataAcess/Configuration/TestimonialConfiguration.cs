
using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testmonial>
    {
        public void Configure(EntityTypeBuilder<Testmonial> builder)
        {

            builder.ToTable("Testimonials");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed:DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FeedBack)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.FirstName);
        }

       
    }
}
