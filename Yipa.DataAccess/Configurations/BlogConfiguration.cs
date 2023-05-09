using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.PublicDate).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired();
        }
    }
}
