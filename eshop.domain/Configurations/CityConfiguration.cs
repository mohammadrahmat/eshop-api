using eshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eshop.domain.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(s => s.Id).Metadata.IsPrimaryKey();
            builder.Property(s => s.CityName).HasMaxLength(100);
            builder.Property(s => s.CountryId).Metadata.IsForeignKey();
        }
    }
}