using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Location;
using ServiceRegister.Application.Organization;

namespace ServiceRegister.Api.Organization
{
    internal class OrganizationMapper : OneWayMapper<IOrganization, Organization>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IOrganization, Organization>();
            Mapper.CreateMap<StreetAddress, Location.StreetAddress>();
            Mapper.CreateMap<PostOfficeBoxAddress, Location.PostOfficeBoxAddress>();
        }
    }
}