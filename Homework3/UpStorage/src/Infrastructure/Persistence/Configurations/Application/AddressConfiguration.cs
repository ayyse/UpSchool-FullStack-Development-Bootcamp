﻿using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150);

            // District
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.District).HasMaxLength(50);

            // PostCode
            builder.Property(x => x.PostCode).IsRequired();
            builder.Property(x => x.PostCode).HasMaxLength(50);

            // AddressLine1
            builder.Property(x => x.AddressLine1).IsRequired();
            builder.Property(x => x.AddressLine1).HasMaxLength(1000);

            // AddressLine2
            builder.Property(x => x.AddressLine2).IsRequired(false);
            builder.Property(x => x.AddressLine2).HasMaxLength(1000);

            // AddressType
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.AddressType).HasConversion<int>(); // AddressType class'ında enum olan tipi db'ye int olarak eklenecek

            /* Common Fields */

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired(false);
            builder.Property(x => x.CreatedByUserId).HasMaxLength(100);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(100);

            // LastModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(100);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValueSql("0");
            builder.HasIndex(x => x.IsDeleted);

            // Relationships
            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId); // one(user) to many(address)

            builder.ToTable("Addresses");
        }
    }
}
