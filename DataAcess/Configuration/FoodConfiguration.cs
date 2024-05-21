using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods");

            builder.Property(x=>x.ID)
                .IsRequired()
                .UseIdentityColumn(seed:DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED,increment:1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(7, 2);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x=>x.IsHomePage)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasKey(x => x.ID);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            builder.HasOne(x => x.FoodCategory)
                .WithMany(x => x.Foods)
                .HasForeignKey(x => x.FoodCategoryID);
        }
    }
}
