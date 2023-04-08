using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.DAL.Configurations;

internal class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        // foreign key
        builder.HasMany(x => x.Employees);
        
        // properties options
        builder.Property(x => x.JobTitle).IsRequired();
    }
}