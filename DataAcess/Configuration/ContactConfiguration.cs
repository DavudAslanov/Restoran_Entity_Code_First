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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(x=>x.ID)
                .IsRequired()
                .UseIdentityColumn(seed:DeafultConstantValue.DEFAULT_PRIMARY_KEY_SEED,increment:1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x=>x.Title) 
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x=>x.Message) 
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => new { x.Email, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Email_Deleted");


        }
    }
}
