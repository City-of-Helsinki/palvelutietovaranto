using System;
using ServiceRegister.Application.Location;

namespace ServiceRegister.Application.Organization
{
    public interface IOrganization : IBasicInformation, IContactInformation, IVisitingAddress, IPostalAddress
    {
        Guid Id { get; }
        long NumericId { get; }
        bool IsSubOrganization { get; }
    }
}