namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Options;

public class Options : ValueObject
{
    internal Options(
        bool hasClimateControl,
        int numberOfSeats,
        TransmissionType transmissionType)
    {
        this.Validate(numberOfSeats);
        
        this.ClimateControl = hasClimateControl;
        this.NumberOfSeats = numberOfSeats;
        this.TransmissionType = transmissionType;
    }
    
    public bool ClimateControl { get; }

    public int NumberOfSeats { get; }

    public TransmissionType TransmissionType { get; }

    private void Validate(int numberOfSeats)
        => Guard.AgainstOutOfRange<InvalidOptionsException>(
            numberOfSeats,
            MinimumNumberOfSeats,
            MaximumNumberOfSeats,
            nameof(this.NumberOfSeats));
}