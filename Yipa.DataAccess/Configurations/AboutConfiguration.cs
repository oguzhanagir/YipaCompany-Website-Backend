﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(800);
            builder.Property(x => x.ImagePath).IsRequired();
        }
    }
}
