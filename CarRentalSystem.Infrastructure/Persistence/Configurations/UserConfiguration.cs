namespace CarRentalSystem.Infrastructure.Persistence.Configurations;

using CarRentalSystem.Infrastructure.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private const string DealerId = "DealerId";
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Dealer)
            .WithOne()
            .HasForeignKey<User>(DealerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}