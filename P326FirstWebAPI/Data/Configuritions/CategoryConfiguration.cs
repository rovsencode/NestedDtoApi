using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P326FirstWebAPI.Models;

namespace FirstApi.Data.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property( c => c.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Description).HasMaxLength(50).IsRequired(true);
        }
    }
}
