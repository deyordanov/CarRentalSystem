namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Common;
using static ModelConstants.Category;

public class Category : Entity<int>
{
    internal Category(
        string name,
        string description)
    {
        this.Validate(name, description);
        
        this.Name = name;
        this.Description = description;
    }
    
    public string Name { get; }

    public string Description { get; }

    private void Validate(string name, string description)
    {
        Guard.ForStringLength<InvalidCarAdException>(
            name,
            MinimumNameLength,
            MaximumNameLength,
            nameof(this.Name));
        
        Guard.ForStringLength<InvalidCarAdException>(
            description,
            MinimumDescriptionLength,
            MaximumDescriptionLength,
            nameof(this.Description));
    }
}