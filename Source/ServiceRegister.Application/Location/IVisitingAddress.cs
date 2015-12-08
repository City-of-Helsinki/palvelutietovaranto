namespace ServiceRegister.Application.Location
{
    public interface IVisitingAddress : IVisitingAddressQualifiers
    {
        StreetAddress VisitingAddress { get; }
    }
}
