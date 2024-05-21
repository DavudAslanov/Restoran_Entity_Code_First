using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Configuration
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn(seed: DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
        }
    }
}
