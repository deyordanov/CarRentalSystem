namespace CarRentalSystem.Infrastructure.Persistance.Configurations;

using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.Category;
using static Domain.Models.ModelConstants.Common;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(MaximumNameLength);

        builder
            .Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(MaximumDescriptionLength);
    }
}