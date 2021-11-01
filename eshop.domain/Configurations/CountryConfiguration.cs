using eshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eshop.domain.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(s => s.Id).Metadata.IsPrimaryKey();
            builder.Property(s => s.CountryCode).HasMaxLength(10).Metadata.IsUniqueIndex();
            builder.Property(s => s.CountryName).HasMaxLength(100);
        }
    }
}