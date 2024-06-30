namespace CarRentalSystem.Infrastructure.Persistance.Configurations;

using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.Common;

public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    private const string PrivateCarAdsSetterFieldName = "carAds";
    
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder
            .HasKey(d => d.Id);

        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(MaximumNameLength);

        builder
            .OwnsOne(d => d.PhoneNumber, pn =>
            {
                pn.WithOwner();

                pn.Property(p => p.Number);
            });
        
        builder
            .HasMany(d => d.CarAds)
            .WithOne()
            .Metadata
            .PrincipalToDependent!
            .SetField(PrivateCarAdsSetterFieldName);
    }
}