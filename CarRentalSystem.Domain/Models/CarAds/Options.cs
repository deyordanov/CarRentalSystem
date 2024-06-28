namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Options;

public class Options : ValueObject
{
    private Options(
        bool hasClimateControl,
        int numberOfSeats)
    {
        this.HasClimateControl = hasClimateControl;
        this.NumberOfSeats = numberOfSeats;

        this.TransmissionType = null!;
    }
    
    internal Options(
        bool hasClimateControl,
        int numberOfSeats,
        TransmissionType transmissionType)
    {
        this.Validate(numberOfSeats);
        
        this.HasClimateControl = hasClimateControl;
        this.NumberOfSeats = numberOfSeats;
        this.TransmissionType = transmissionType;
    }
    
    public bool HasClimateControl { get; }

    public int NumberOfSeats { get; }

    public TransmissionType TransmissionType { get; }

    private void Validate(int numberOfSeats)
        => Guard.AgainstOutOfRange<InvalidOptionsException>(
            numberOfSeats,
            MinimumNumberOfSeats,
            MaximumNumberOfSeats,
            nameof(this.NumberOfSeats));
}