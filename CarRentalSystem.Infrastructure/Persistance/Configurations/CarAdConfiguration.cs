namespace CarRentalSystem.Infrastructure.Persistance.Configurations;

using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.CarAd;

public class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
{
    private const string ManufacturerId = "ManufacturerId";
    private const string CategoryId = "CategoryId";
    
    public void Configure(EntityTypeBuilder<CarAd> builder)
    {
        builder
            .HasKey(ca => ca.Id);

        builder
            .HasOne(ca => ca.Manufacturer)
            .WithMany()
            .HasForeignKey(ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(ca => ca.Model)
            .IsRequired()
            .HasMaxLength(MaximumModelLength);

        builder
            .HasOne(ca => ca.Category)
            .WithMany()
            .HasForeignKey(CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(ca => ca.Image)
            .IsRequired();
        
        builder
            .Property(ca =>  ca.PricePerDay)
            .IsRequired()
            .HasPrecision(18, 2);

        builder
            .OwnsOne(ca => ca.Options, o =>
            {
                o.WithOwner();

                o.Property(op => op.NumberOfSeats);
                o.Property(op => op.ClimateControl);

                o.OwnsOne(op => op.TransmissionType, tt =>
                {
                    tt.WithOwner();

                    tt.Property(t => t.Value);
                });
            });

        builder
            .Property(ca => ca.IsAvailable)
            .IsRequired();
    }
}