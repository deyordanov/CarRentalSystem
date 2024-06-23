namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;

public class TransmissionType : Enumeration
{
    private static readonly TransmissionType Manual = new TransmissionType(1, nameof(Manual));
    private static readonly TransmissionType Automatic = new TransmissionType(2, nameof(Automatic));
    
    private TransmissionType(int value) 
        : base(value) { }

    private TransmissionType(int value, string name) 
        : base(value, name) { }
}